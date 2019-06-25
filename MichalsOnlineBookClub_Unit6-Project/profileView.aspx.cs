using ServiceReferenceBookClub;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class profileView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["LoggedIn"] == null || Request.Cookies["LoggedIn"] != null && Request.Cookies["LoggedIn"].Value == "false")
        {
            Response.Redirect("~/userLogInForm.aspx");
        }
        else
        {
            try
            {
                BookClubWebServiceSoapClient ws = new BookClubWebServiceSoapClient();
                DataTable userDetails = ws.FetchUser();
                fName.Value = userDetails.Rows[0]["firstName"].ToString();
                lName.Value = userDetails.Rows[0]["lastName"].ToString();
                email.Value = userDetails.Rows[0]["email"].ToString();
                country.Value = userDetails.Rows[0]["country"].ToString();
                favouriteBook.Value = userDetails.Rows[0]["securityFavBookQuestion"].ToString();
                dob.Value = userDetails.Rows[0]["dateOfBirth"].ToString();



                // TODO: repeter for all the reviews for this account maybe????


            }
            catch
            {
                HttpCookie loggedInCookie = new HttpCookie("LoggedIn", "false");
                Response.SetCookie(loggedInCookie);
                BookClubWebServiceSoapClient ws = new BookClubWebServiceSoapClient();
                Response.Redirect("~/");
            }
        }
    }

    protected void UserEditSubmit(object sender, EventArgs e)
    {
        BookClubWebServiceSoapClient ws = new BookClubWebServiceSoapClient();
        string editUserCheck = ws.EditUser(fName.Value, lName.Value, email.Value, dob.Value, country.Value, favouriteBook.Value, gender.SelectedValue);
        messageBox.Visible = true;
        messageBox.InnerHtml = editUserCheck;
    }
}