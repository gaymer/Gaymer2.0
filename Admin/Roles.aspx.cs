using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Roles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginLib login = new LoginLib();
        if (!login.requirePermission(Permissions.Gaymer_Manage_Roles)) Response.Redirect("~/StartPage.aspx", true);
    }
}