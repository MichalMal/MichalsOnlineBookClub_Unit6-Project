using ServiceReferenceBookClub;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class bookView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BookClubWebServiceSoapClient ws = new BookClubWebServiceSoapClient();
        DataTable bookDetails = ws.FetchBook();
        bookNameTitle.Text = bookDetails[].ToString;
    }
}