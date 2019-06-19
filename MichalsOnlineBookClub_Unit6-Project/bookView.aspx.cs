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


            /// TODO : Configure the Repeter here

        }
        catch (Exception exe)
        {
            Debug.WriteLine("Bug was: " + exe);
            Response.Redirect("Default.aspx");
        }
    }
}