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
        Output.Text += contentA.ControllerList[0].Value.ToString() + "<br />";
        //Output.Text += contentB.controller.Value + "<br />";
        //Output.Text += contentC.controller.Value + "<br />";

        GenericContent content = GenericContent.getContent(1);

        Output.Text += (content!=null)? content.ToString() + "<br />": "";
        
        const string defaultUserID = "1";
        const string defaultRoleID = "1";
        string userId = Request["userId"];
        string roleId = Request["roleId"];
        int userIdInt, roleIdInt;


        userId = (!Int32.TryParse(userId, out userIdInt) || string.IsNullOrEmpty(userId)) ? defaultUserID : userId;
        roleId = (!Int32.TryParse(roleId, out roleIdInt) || string.IsNullOrEmpty(roleId)) ? defaultRoleID : roleId;
        
        if (ManageDB.UserHasRole(roleIdInt, userIdInt))
        {
            Output.Text += "Brukeren har rollen.";
        }
        else
        {
            Output.Text += "Brukeren har ikke rollen.";
        }
    //    Output.Text = NumberOfAddedRows + " rader lagt til i tabellen.";

    }
}