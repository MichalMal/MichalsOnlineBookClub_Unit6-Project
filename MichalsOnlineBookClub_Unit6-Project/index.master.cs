using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _default : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void UserLogOut(object sender, EventArgs e)
    {
        if (Response.Cookies["LoggedIn"] != null)
        {
            HttpCookie loggedInCookie = new HttpCookie("LoggedIn", "false");
            Response.SetCookie(loggedInCookie);

            Response.Redirect("Default.aspx");
        }
    }
}
