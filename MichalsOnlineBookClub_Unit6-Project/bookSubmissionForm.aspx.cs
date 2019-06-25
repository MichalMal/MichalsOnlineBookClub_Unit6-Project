using ServiceReferenceBookClub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class bookSubmissionForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SubmitNewBook(object sender, EventArgs e)
    {
        BookClubWebServiceSoapClient ws = new BookClubWebServiceSoapClient();
        string newBookCheck = ws.SubmitNewBook(bookName.Value, author.Value, bookDescription.Value);
        messageBox.Visible = true;
        messageBox.InnerHtml = newBookCheck;
    }
}