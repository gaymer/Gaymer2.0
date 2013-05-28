using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using System.Data.SqlClient;


public partial class CMS_Default : System.Web.UI.Page
{

    public void AddHTML(string htmlString)
    {
        if (GenericContentPanel != null) GenericContentPanel.Controls.Add(new LiteralControl(htmlString));
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        AbstractInputController myInput = new SimpleText();

        AddHTML("Wakakakakakaka");
    }
}