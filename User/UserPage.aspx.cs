using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Brukerside : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginLib login = new LoginLib();

        if (!IsPostBack)
        {
            //Full Callback
            if (!login.IsUserLoggedIn())
            {
                Response.Redirect("/StartPage.aspx");
            }
            else
            {
                Normal.FillData();
            }
        }
        else
        {
            //Async Callback
        }
         
        int qUserId;
        string userIdString = Request.QueryString["UserId"];
        Int32.TryParse(userIdString, out qUserId);

        ModifySelf.Visible = false;
        if (ManageDB.UserHasPermission("Gaymer_EditUser", login.GetUserID()) || login.GetUserID() != qUserId)
        {
            ModifySelf.Visible = true;
        }
        
    }
    protected void ModifySelf_Click(object sender, EventArgs e)
    {
        if (ModifySelf.Text == "Modify")
        {
            Normal.Visible = false;
            Modify.Visible = true;
            ModifySelf.Text = "Save";

            Modify.FillData();
        }
        else if (ModifySelf.Text == "Save")
        {
            Modify.SaveData();
            Normal.Visible = true;
            Modify.Visible = false;
            ModifySelf.Text = "Modify";
            Normal.FillData();
        }
    }
}