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

    private void FailToLoad()
    {
        Response.Redirect("/CMS/Default.aspx?Content=1");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string qsContentIdString = Request.QueryString["content"];
        qsContentIdString = string.IsNullOrEmpty(qsContentIdString)? null: qsContentIdString;
        int contentId;

        if (!Int32.TryParse(qsContentIdString, out contentId))
        {
            FailToLoad();
        }

        GenericContent content = GenericContent.getContent(contentId);




        AddHTML("Before content <br />");

        if (content == null)
        {
            FailToLoad();
        }
        else
        {
            foreach (int inputElementId in content.InputElementTypeList) // Test for null implemented earlier in code
            {
                AbstractInputController myInput = getInputObject(inputElementId, contentId);
                myInput.AddEdit(GenericContentPanel, contentId);
            }
        }

        AddHTML("<br /> After content");

    }


    private AbstractInputController getInputObject(int inputElementId, int contentId)
    {
        var parameters = new Dictionary<string, object>();
        parameters.Add("@InputElementId", inputElementId);

        string inputName = (ManageDB.GetSingleColumnResultAsList<string>(@"
                SELECT      Name
                FROM        InputElement
                WHERE       InputElementId = @InputElementId
            ", parameters, debug:true))[0];

        if (string.IsNullOrEmpty(inputName))
            return null;

        switch (inputName)
        {
            case "simpletext":
                return new SimpleText(contentId);
                break;
            default:
                throw new Exception("/cms/default#A1");
                break;
        }

        return null;
    }

}