using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginLib login = new LoginLib();
        if (login.IsUserLoggedIn())
        {
            LogOutBtn.Visible = true;
            LogOutBtn.Enabled = true;

            //Must run last for logged in users on every page, meaning before this block closes
            //login.CreateNewCookie();
        }
        else
        {
            LogOutBtn.Visible = false;
            LogOutBtn.Enabled = false;
        }

    }
    protected void LogOut_Click(object sender, EventArgs e)
    {
        LoginLib login = new LoginLib();
        login.LogOut();
        Response.Redirect("/");
    }
}
