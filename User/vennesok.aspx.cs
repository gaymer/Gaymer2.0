﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_vennesok : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void finnvenner(string search)
    {
                
        ManageDB db = new ManageDB();
        Dictionary<String, object> parameter = new Dictionary<string, object>();
        parameter.Add("@userNameSearch",search);

        DataTable dt = ManageDB.query(@"
        SELECT [User].Username
        FROM [User]
        WHERE [User].Username LIKE %@userNameSearch
        ",parameter);

        sokResult.DataSource = dt;
        sokResult.DataBind();
    }

    protected void sokbtn_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(soktxt.Text))
        {
            finnvenner(soktxt.Text);
            sokerrorlbl.Text="";
        }
        else
            sokerrorlbl.Text = "Tomt søk";

    }
}