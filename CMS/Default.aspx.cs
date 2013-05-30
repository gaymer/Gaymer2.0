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

    /// <summary>
    /// Redirects to a predestined location.
    /// </summary> 
    private void FailToLoad()
    {
        Response.Redirect("/CMS/Default.aspx?Content=1");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string qsContentIdString = Request.QueryString["content"];
        string qsContentTypeIdString = Request.QueryString["type"];
        string qsEditString = Request.QueryString["edit"];
        string qsCreateString = Request.QueryString["create"];

        bool isEdit = (!string.IsNullOrEmpty(qsEditString) && qsEditString == "1");
        bool isCreate = (!string.IsNullOrEmpty(qsCreateString) && qsCreateString == "1");

        qsContentIdString = string.IsNullOrEmpty(qsContentIdString) ? null : qsContentIdString;
        qsContentTypeIdString = string.IsNullOrEmpty(qsContentTypeIdString) ? null : qsContentTypeIdString;
        
        int contentId;
        int contentTypeId;

        GenericContent content = null;

        if (Int32.TryParse(qsContentIdString, out contentId))                   // Display/Edit
        {
            content = GenericContent.GetContent(contentId);
        } 
        else if (Int32.TryParse(qsContentTypeIdString, out contentTypeId))      // Create
        {
            content = new GenericContent(contentTypeId);
        }
        else
        {
            FailToLoad();
        }






        if (content == null && contentId>0) FailToLoad();


        AddHTML("// START GENERIC CONTENT: ");

        for (int i = 0; i < content.InputElementTypeList.Count; i++)
        {
            AbstractInputController myInput = getInputObject(content.InputElementTypeList[i], contentId);
            if (isCreate)
                myInput.AddCreate(GenericContentPanel);
            else if (isEdit)
                myInput.AddEdit(GenericContentPanel, contentId, content.InputElementDataList[i]);
            else
                myInput.AddDisplay(GenericContentPanel, contentId, content.InputElementDataList[i]);
        }

        AddHTML("// END GENERIC CONTENT");

    }


    private AbstractInputController getInputObject(int inputElementId, int contentId)
    {
        var parameters = new Dictionary<string, object>();
        parameters.Add("@InputElementId", inputElementId);

        string inputName = (ManageDB.GetSingleColumnResultAsList<string>(@"
                SELECT      Name
                FROM        InputElement
                WHERE       InputElementId = @InputElementId
            ", parameters, debug: true))[0];

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