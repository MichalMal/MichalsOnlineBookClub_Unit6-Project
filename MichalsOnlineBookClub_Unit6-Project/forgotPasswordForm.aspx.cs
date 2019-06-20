using ServiceReferenceBookClub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class forgotPasswordForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["LoggedIn"] != null && Request.Cookies["LoggedIn"].Value == "true")
        {
            Response.Redirect("~/");
        }
    }

    protected void UserResetPassword(object sender, EventArgs e)
    {
        BookClubWebServiceSoapClient ws = new BookClubWebServiceSoapClient();
        string submissionResponce = ws.ForgotPasswordSubmission();

        Response.Redirect("~/");
    }
}