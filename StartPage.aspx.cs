using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _StartPage : System.Web.UI.Page
{
    LoginLib login = new LoginLib();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (login.IsUserLoggedIn())
        {
            Response.Redirect("/User/UserPage.aspx");
        }
    }
    protected void LogInBtn_Click(object sender, EventArgs e)
    {
        string username = LogUsernameBox.Text;
        string password = LogPasswordBox.Text;
        if (login.LoginUser(username, password) == true)
        {
            Response.Redirect("/User/UserPage.aspx");
        }
        else
        {
            // Ikke logget inn prøv igjen
        }

    }
    protected void Regbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("/user/Register.aspx");
    }
}