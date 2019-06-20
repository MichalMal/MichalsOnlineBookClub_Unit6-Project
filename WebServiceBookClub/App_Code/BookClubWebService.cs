using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;



//  Michal Malujlo - ZHCL2Z3T1
//  C# UNIT 6 PROJECT 2




/// <summary>
/// This is the WebService that is used for the backend of the website
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class BookClubWebService : System.Web.Services.WebService
{
    public BookClubWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    public void Logging(string text)
    {
        Stream s = File.Open(AppDomain.CurrentDomain.BaseDirectory + @"\" + "logs.txt", FileMode.OpenOrCreate);//writes to base directory
        s.Close();
        StreamWriter writer = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + @"\" + "logs.txt");
        writer.WriteLine(text);
        writer.Close();
    }

    OleDbConnection conn;

    // Method used to execute query which has no result: INSERT,DELETE,UPDATE
    public bool ExecuteCommand(String query)
    {
        try
        {
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            cmd.ExecuteReader();
            // Returning true indicates success.
            return true;
        }
        catch (OleDbException odbe)
        {
            // Returning false indicates failure.
            Logging("Error: " + odbe);
            return false;
        }
    }

    // Method which executes a query and returns the result (if any).
    public OleDbDataReader ExecuteQuery(String query)
    {
        try
        {
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            OleDbDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        catch (OleDbException odbe)
        {
            Logging("Error: " + odbe);
            return null;
        }
    }

    // Method which creates a database connection and opens it.
    public void ConnectToDatabase()
    {
        try
        {
            string connString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={HttpContext.Current.Request.PhysicalApplicationPath}BookClubDB.mdb";
            conn = new OleDbConnection(connString);
            conn.Open();
            Logging("Connected to DB");
        }
        catch (OleDbException ex)
        {
            Logging("DID NOT CONNECT!");
            Logging(ex.StackTrace);// this reports to the console whats happening with the connection
        }
    }

    // Method which disconnects from the database.
    public void DisconnectDatabase()
    {
        Logging("Disconnected from DB");
        conn.Close();
    }

    public bool CheckUser(string email)
    {
        string checkqueryString = $"SELECT * FROM [ClubUsers] WHERE Email = '{email}'";
        ConnectToDatabase();
        OleDbDataReader emailRead = ExecuteQuery(checkqueryString);
        if (emailRead == null | !emailRead.HasRows)
        {
            Logging("No Users Found");
            return false;
        }
        Logging("User Has Been Found");

        return true;

    }

    [WebMethod(EnableSession = true)]
    public string RegisterNewUser(string firstName, string lastName, string email, string dob, string country, string securityBookQuestion, string gender, string pwd, string cpwd)
    {
        string returnString;
        if (CheckUser(email))
        {
            Logging("User Has Been Claimed");
            returnString = "Email Username has already been claimed!";
        }
        else if (pwd != cpwd)
        {
            Logging("Passwords Dont Match");
            returnString = "Passwords Do Not Match";
        }
        else
        {

            // Construct a query string using the values from the text boxes.
            string queryString = ($"INSERT INTO ClubUsers(firstName, lastName, email, dateOfBirth, country, securityFavBookQuestion, gender, [password]) VALUES ('{firstName}', '{lastName}', '{email}', '{dob}', '{country}', '{securityBookQuestion}', '{gender}', '{pwd}')");
            Logging(queryString);
            ConnectToDatabase();

            // Check for matches.
            Session["AuthUser"] = email;
            bool dbReader = ExecuteCommand(queryString);
            returnString = "Your Profile Has Been Created";

            DisconnectDatabase();
        }
        return returnString;
    }

    [WebMethod(EnableSession = true)]
    public string LogInUser(string email, string pwd, bool rememberMe)
    {
        string queryString = $"SELECT * FROM [ClubUsers] WHERE Email = '{email}' AND StrComp([Password], {pwd}, 0) = 0";
        // the password is not case sense because of database
        Logging($"Trying to Log In using : {queryString}     as the query");

        ConnectToDatabase();
        OleDbDataReader authentication = ExecuteQuery(queryString);

        if (authentication != null && authentication.HasRows)
        {


            Logging("User Has Succeeded in logging in");
            Session["AuthUser"] = email;

            DisconnectDatabase();
            return "User Logged in successfully";

        }

        DisconnectDatabase();
        // Display the error message
        Logging("failed to log in");
        return "Incorrect Username or password!";

    }

    [WebMethod]
    public string ForgotPasswordSubmission()
    {
        return "Password Rest to password";
    }

    [WebMethod(EnableSession = true)]
    public DataTable FetchUser()
    {

        Logging($"The session variable should be an email of {(string)Session["AuthUser"]}");


        string queryString = $"SELECT * FROM [ClubUsers] WHERE Email = '{(string)Session["AuthUser"]}'";
        ConnectToDatabase();

        // Creates an empty DataSet.
        DataSet ds = new DataSet();

        // Creates a DataAdapter that queries the database.
        OleDbDataAdapter dba = new OleDbDataAdapter(queryString, conn);

        // DataSet is filled with the data retrieved by the DataAdapter query.
        dba.Fill(ds, "ClubUsers");

        DataTable dt = ds.Tables["ClubUsers"];


        DisconnectDatabase();

        return dt;
    }

    [WebMethod(EnableSession = true)]
    public string EditUser(string firstName, string lastName, string email, string dob, string country, string securityBookQuestion, string gender)
    {
        string returnString;
        ConnectToDatabase();
        if (CheckUser(email) && (string)Session["AuthUser"] != email)
        {
            Logging("User Has Been Claimed");
            returnString = "Email Username has already been claimed!";
        }
        else
        {
            // Construct a query string using the values from the text boxes.
            string queryString = ($"UPDATE ClubUsers SET firstName = '{firstName}', lastName = '{lastName}', email = '{email}', dateOfBirth = '{dob}', country = '{country}', gender = '{gender}' WHERE email = '{(string)Session["AuthUser"]}';");
            Logging(queryString);

            // Check for matches.
            Session["AuthUser"] = email;
            bool dbReader = ExecuteCommand(queryString);
            returnString = "Your Profile Has Been Updated";

        }
        DisconnectDatabase();
        return returnString;
    }

    [WebMethod(EnableSession = true)]
    public DataTable FetchBooks()
    {
        string queryString = $"SELECT * FROM [Books]";
        ConnectToDatabase();

        // Creates an empty DataSet.
        DataSet ds = new DataSet();

        // Creates a DataAdapter that queries the database.
        OleDbDataAdapter dba = new OleDbDataAdapter(queryString, conn);

        // DataSet is filled with the data retrieved by the DataAdapter query.
        dba.Fill(ds, "Books");

        DataTable dt = ds.Tables["Books"];
        DisconnectDatabase();

        return dt;
    }

    [WebMethod(EnableSession = true)]
    public void BookSession(int bookID)
    {
        Session["BookID"] = bookID;
    }

    [WebMethod(EnableSession = true)]
    public DataTable FetchBook()
    {
        try
        {

            string queryString = $"SELECT * FROM [Books] WHERE BID = {Session["BookID"].ToString()}";
            ConnectToDatabase();

            DataSet ds = new DataSet();

            // Creates a DataAdapter that queries the database.
            OleDbDataAdapter dba = new OleDbDataAdapter(queryString, conn);

            // DataSet is filled with the data retrieved by the DataAdapter query.
            dba.Fill(ds, "Books");

            DataTable dt = ds.Tables["Books"];

            DisconnectDatabase();
            return dt;

        }
        catch
        {
            DataTable dt = null;
            return dt;
        }


    }

    [WebMethod(EnableSession = true)]
    public string GetRating()
    {
        string queryString = $"SELECT [rating] FROM [Reviews] WHERE Book = {Session["BookID"].ToString()}";
        ConnectToDatabase();
        OleDbDataReader result = ExecuteQuery(queryString);
        List<int> intList = new List<int>();
        if (result != null)
        {
            // Read the next item.
            while
              (result.Read())
            {
                // Add the current record’s name column.
                intList.Add(Convert.ToInt32(result["rating"]));
            }
        }
        double avRating;
        if (intList != null & intList.Any())
        {
            avRating = intList.Average();
        }
        else
        {
            avRating = 0;
        }

        return GetStars(avRating);
    }

    [WebMethod]
    public string GetStars(double starNum)
    {
        string ratingString = "";
        for (int i = 0; i < 5; i++)
        {
            if (starNum > i)
            {
                ratingString += "<span style=\"font-size: 40px\" class=\"glyphicon glyphicon-star\"></span>";
            }
            else
            {
                ratingString += "<span style=\"font-size: 40px\" class=\"glyphicon glyphicon-star-empty\"></span>";
            }
        }
        return ratingString;
    }

    [WebMethod(EnableSession = true)]
    public DataSet FetchReviews()
    {
        string queryString = $"SELECT [rating],[ratingDescription] FROM [Reviews] WHERE book = {Session["BookID"].ToString()}";
        Logging(queryString);
        ConnectToDatabase();

        DataSet ds = new DataSet();

        // Creates a DataAdapter that queries the database.
        OleDbDataAdapter dba = new OleDbDataAdapter(queryString, conn);

        // DataSet is filled with the data retrieved by the DataAdapter query.
        dba.Fill(ds, "Reviews");

        // DataTable dt = ds.Tables["Reviews"];

        DisconnectDatabase();

        return ds;
    }

    [WebMethod(EnableSession = true)]
    public bool CheckReviews()
    {
        bool endpoint = false;
        try
        {
            Logging($"User session is: {Session["AuthUser"].ToString()}. And book session is: {Session["BookID"].ToString()}");
            string userID = FetchUser().Rows[0]["UID"].ToString();
            string queryString = $"SELECT * FROM [Reviews] WHERE book = {Session["BookID"].ToString()} AND user = {userID}";
            ConnectToDatabase();
            OleDbDataReader reviewCheck = ExecuteQuery(queryString);
            if (reviewCheck != null & reviewCheck.HasRows)
            {
                Logging("User Has Reviewed");
                endpoint = true;
            }
            else
            {
                Logging("User Has Not Reviewed(no Rows)");
                endpoint = false;
            }
            DisconnectDatabase();
        }
        catch (Exception exc)
        {

            Logging("Something Went wrong :" + exc.ToString());
            endpoint = true;
        }
        Logging("endpoint is :" + endpoint.ToString());
        return endpoint;
    }

    [WebMethod(EnableSession = true)]
    public string CreateNewReview(string description, string rating)
    {
        string userID = FetchUser().Rows[0]["UID"].ToString();
        string queryString = ($"INSERT INTO [Reviews] ([user], [book], [rating], [ratingDescription]) VALUES ({userID}, {Session["BookID"].ToString()}, {rating}, \"{description}\")");
        Logging(queryString);
        ConnectToDatabase();
        string confirmation;
        // Check for matches.
        if (ExecuteCommand(queryString))
        {
            confirmation = "Review Submitted";
            Logging("User with ID: " + userID + "   Rated book with book ID: " + Session["BookID"].ToString() + "  with a rating of " + rating);
        }
        else
        {
            confirmation = "Review Failed";
        }
        DisconnectDatabase();
        return confirmation;
    }

    [WebMethod]
    public string SubmitNewBook(string bookName, string author, string description)
    {
        string queryString = ($"INSERT INTO [Books] ([bookName], [author], [description]) VALUES ('{bookName}', '{author}', \"{description}\")");

        Logging(queryString);
        ConnectToDatabase();
        string confirmation;
        // Check for matches.
        if (ExecuteCommand(queryString))
        {
            confirmation = "Book Submitted";
        }
        else
        {
            confirmation = "Book Failed to Submit";
        }
        DisconnectDatabase();
        return confirmation;
    }
}