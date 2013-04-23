using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using Gaymer.Classes;

public partial class CMS_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = Gaymer.Classes.ManageDB.query("SELECT * FROM User");

        //Output.Text = "Det er " + dt.Rows.Count.ToString() + " brukere i databasen.";
        
        Output.Text = "Det er brukere i databasen.";

        
    }
}