using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Roles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginLib login = new LoginLib();
        if (!login.hasPermission(Permissions.Gaymer_Manage_Roles)) Response.Redirect("~/StartPage.aspx", true);

        string q;
        DataTable dt;

        if (!IsPostBack)
        {
            q = "SELECT [RoleID], [Role] FROM [Role] ORDER BY [Role]";
            dt = ManageDB.query(q);
            RoleList.DataSource = dt;
            RoleList.DataBind();
        }

        dt = getDataTableWithPermissionValues();
        rendreNewView(dt);
    }

    private DataTable getDataTableWithPermissionValues()
    {
        int rid;
        if (!Int32.TryParse(RoleList.SelectedValue, out rid))
        {
            throw new Exception("Value in RoleList (Dropdownlist) is not number? Why?");
        }

        Label l = new Label();
        l.Text = "<br />" + rid;
        panel.Controls.Add(l);

        var dict = new Dictionary<string, object>();
        dict.Add("@rid", rid);
        string q = @"
            SELECT  Permission.PermissionId, 
                    Permission.Label, 
                    Permission.PermissionUniqueString, 
                    CAST(CASE WHEN PermissionToRole.RoleId = @rid THEN 1 ELSE 0 END AS bit) AS enabled
            FROM Permission LEFT OUTER JOIN PermissionToRole 
            ON Permission.PermissionId = PermissionToRole.PermissionId AND PermissionToRole.RoleId = @rid
            ORDER BY Permission.PermissionUniqueString";

        l = new Label();
        l.Text = "<br />" + rid + " - " + dict["@rid"] + " - " + IsPostBack.ToString();
        panel.Controls.Add(l);

        DataTable dt = new DataTable();

        SqlConnection _dbConnection = new SqlConnection();
        _dbConnection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["gaymerdbConnectionString"].ConnectionString;
        _dbConnection.Open();
        SqlCommand sqlCommand = new SqlCommand(q, _dbConnection);
        sqlCommand.Parameters.Add("@rid", rid);
        SqlDataReader reader = sqlCommand.ExecuteReader();
        dt.Load(reader);       // Adds rows. Result: read-only
        reader.Close();

        return dt;
    }

    private void rendreNewView(DataTable dt)
    {
        CheckBox cb;
        foreach (DataRow row in dt.Rows)
        {
            //<asp:CheckBox ID="CheckBox1" runat="server" />
            cb = new CheckBox();
            cb.ID = "pid_" + ((int)row["PermissionId"]).ToString() + "_" + RoleList.SelectedValue;
            cb.Text = (string)row["Label"] + " (" + (string)row["PermissionUniqueString"] + ") " + IsPostBack.ToString() + " !!! " + ((bool)row["enabled"]).ToString();
            if ((bool)row["enabled"])
            {
                cb.Checked = true;
            }
            else
            {
                cb.Checked = false;
            }
            panel.Controls.Add(cb);

            Label l = new Label();
            l.Text = "<br /> |||" + Request.Params["pid_" + ((int)row["PermissionId"]).ToString()] + "|||";
            panel.Controls.Add(l);
        }

        Button btnSave = new Button();
        btnSave.Text = "Save " + RoleList.SelectedValue;
        btnSave.Click += new EventHandler(this.Savebtn_Click);
        panel.Controls.Add(btnSave);
    }

    protected void Savebtn_Click(object sender, EventArgs e)
    {

        string q = "";

        var dict = new Dictionary<string, object>();
        int pid;

        int rid;
        if (!Int32.TryParse(RoleList.SelectedValue, out rid))
        {
            Response.Redirect("~/RID", true);
        }
        dict.Add("@rid", rid);
        dict.Add("@pid", -1);


        q = "DELETE FROM PermissionToRole WHERE RoleId=@rid";
        if (ManageDB.nonQuery(q, dict, debug: true) < 1)
        {
            // TODO: Handle this error
        }


        foreach (Control c in panel.Controls)
        {

            if (c.GetType() != typeof(CheckBox))
            {
                q = "Next";
                continue;
            }

            if (((CheckBox)c).Checked)
            {

                string s = c.ID.Split('_')[1];
                if (!Int32.TryParse(s, out pid))
                {
                    Response.Redirect("~/CID/" + c.ID, true);
                }
                dict["@pid"] = pid;

                q = "INSERT INTO PermissionToRole (PermissionId, RoleId) VALUES (@pid, @rid)";
                if (ManageDB.nonQuery(q, dict, debug: true) < 1)
                {
                    // TODO: Handle this error

                }
            }
        }

        Label l = new Label();
        l.Text = "<br />" + q;
        panel.Controls.Add(l);
    }
    protected void RoleList_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
}