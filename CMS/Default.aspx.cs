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
    protected void Page_Load(object sender, EventArgs e)
    {

        GenericContent contentA = new GenericContent(typeof(SimpleText));
        //GenericContent contentB = new GenericContent(typeof(ComplexText));
        //GenericContent contentC = new GenericContent(typeof(ComplexText2));

        Output.Text += "<br />";
        Output.Text += contentA.controller.Value + "<br />";
        //Output.Text += contentB.controller.Value + "<br />";
        //Output.Text += contentC.controller.Value + "<br />";

        GenericContent content = GenericContent.getContent(1);

        Output.Text += content.ToString() + "<br />";
        
        string defaultUserID = "1";
        string defaultRoleID = "1";
        string userId = Request["userId"];
        string roleId = Request["roleId"];
        int userIdInt, roleIdInt;


        userId = (!Int32.TryParse(userId, out userIdInt) || userId == "" || userId == null) ? defaultUserID : userId;
        roleId = (!Int32.TryParse(roleId, out roleIdInt) || roleId == "" || roleId == null) ? defaultRoleID : roleId;

        if (ManageDB.userHasRole(roleIdInt, userIdInt))
        {
            Output.Text += "Brukeren har rollen.";
        }
        else
        {
            Output.Text += "Brukeren har ikke rollen.";
        }
        //Output.Text = numberOfAddedRows + " rader lagt til i tabellen.";

    }
}