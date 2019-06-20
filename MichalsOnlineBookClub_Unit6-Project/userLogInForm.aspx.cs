using ServiceReferenceBookClub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logInForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["LoggedIn"] != null && Request.Cookies["LoggedIn"].Value == "true")
        {
            Response.Redirect("~/");
        }
    }

    protected void UserLoginSubmit(object sender, EventArgs e)
    {
        BookClubWebServiceSoapClient ws = new BookClubWebServiceSoapClient();
        string loginCheck = ws.LogInUser(email.Value, pwd.Value, rememberMe.Checked);
        if (loginCheck == "User Logged in successfully")
        {
            HttpCookie loggedInCookie = new HttpCookie("LoggedIn", "true");
            Response.Cookies.Add(loggedInCookie);
            Response.Redirect("~/profileView.aspx");
        } else
        {
            messageBox.Visible = true;
            messageBox.InnerHtml = loginCheck;
        }
    }
}