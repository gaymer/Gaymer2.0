using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Meldinger2 : System.Web.UI.Page
{
    public LoginLib login;

    protected void Page_Load(object sender, EventArgs e)
    {
       login = new LoginLib();
       int BrukerTall = 6; 
    }
}