using ServiceReferenceBookClub;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class bookView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BookClubWebServiceSoapClient ws = new BookClubWebServiceSoapClient();
        try
        {
            DataTable bookDetails = ws.FetchBook();
            bookNameTitle.Text = bookDetails.Rows[0]["bookName"].ToString();
            bookAuthorTitle.Text = bookDetails.Rows[0]["author"].ToString();
            averageStarRating.InnerHtml = ws.GetRating();
            bookDescriptionText.Text = bookDetails.Rows[0]["description"].ToString();

            DataSet listReviews = ws.FetchReviews();
            reviewsRepeter.DataSource = listReviews;
            reviewsRepeter.DataBind();

        }
        catch (Exception exe)
        {
            Debug.WriteLine("Bug was: " + exe);
            Response.Redirect("~/");
        }
    }

    protected void SubmitNewBook(object sender, EventArgs e)
    {
        BookClubWebServiceSoapClient ws = new BookClubWebServiceSoapClient();
        string reviewCheck = ws.CreateNewReview(rewiewDescription.Value, reviewRating.Value);
        messageBox.Visible = true;
        messageBox.InnerHtml = reviewCheck;
    }

    protected bool CheckUserForReviews()
    {
        BookClubWebServiceSoapClient ws = new BookClubWebServiceSoapClient();
        return ws.CheckReviews();
    }

    protected string CreateStarsReview(object rate)
    {
        BookClubWebServiceSoapClient ws = new BookClubWebServiceSoapClient();
        return ws.GetStars(Convert.ToDouble(rate));
    }
}