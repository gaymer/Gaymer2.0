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






        if (content == null && contentId > 0) FailToLoad();


        AddHTML("// START GENERIC CONTENT: ");

        for (int i = 0; i < content.InputElementTypeList.Count; i++)
        {
            Panel addedPanel = new Panel();
            AbstractInputController myInput = getInputObject(content.InputElementTypeList[i], contentId);
            if (isEdit)
            {
                myInput.AddEdit(addedPanel, contentId, content.InputElementDataList[i]);
                SaveContentButton.Visible = true;
            }
            else if (isCreate)
            {
                myInput.AddCreate(addedPanel);
                SaveContentButton.Visible = true;
            }
            else
            {
                myInput.AddDisplay(addedPanel, contentId, content.InputElementDataList[i]);
                SaveContentButton.Visible = false;
            }

            GenericContentPanel.Controls.Add(addedPanel);
        }

        AddHTML("// END GENERIC CONTENT");

    }


    private AbstractInputController getInputObject(int inputElementId, int contentId=-1)
    {
        var parameters = new Dictionary<string, object>();
        parameters.Add("@InputElementId", inputElementId);

        string inputName = (ManageDB.GetSingleColumnResultAsList<string>(@"
                SELECT      Name
                FROM        InputElement
                WHERE       InputElementId = @InputElementId
            ", parameters, debug: true))[0];

        return getInputObject(inputName, contentId);


        return null;
    }

    private AbstractInputController getInputObject(string inputName, int contentId)
    {
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
    }

    protected void SaveContent_Click(object sender, EventArgs e)
    {
        bool isCreate   = (!string.IsNullOrEmpty(Request.QueryString["create"]) && Request.QueryString["create"] == "1");
        bool isEdit     = (!string.IsNullOrEmpty(Request.QueryString["edit"]) && Request.QueryString["edit"] == "1");

        if (isEdit)
        {
            int contentId;
            if (!Int32.TryParse(Request.QueryString["content"], out contentId)) FailToLoad();

            var p = new Dictionary<string, object>();
            p.Add("@ContentId", contentId);
            string sql = @"
                    SELECT eic.InputElementId, ie.
                    FROM ElementInContent eic, DynamicContent dct, InputElement ie
                    WHERE eic.ContentTypeId = dct.ContentType
                      AND dct.DynamicContentId = @ContentId
                ";

            List<int> dataList = ManageDB.GetSingleColumnResultAsList<int>(sql, p);

          //  AbstractInputController input = 

            int i = 0;

            foreach (var c in GenericContentPanel.Controls)
            {
                if (c.GetType() == typeof(Panel))
                {

                    i++;
                }
            }


        }

        if (isCreate)
        {
            int contentTypeId;
            if (!Int32.TryParse(Request.QueryString["type"], out contentTypeId)) FailToLoad();

            var p = new Dictionary<string, object>();
            p.Add("@contentTypeId", contentTypeId);
            string sql = @"
                    SELECT 
                ";

            List<int> dataList = ManageDB.GetSingleColumnResultAsList<int>(sql, p);




            foreach (var c in GenericContentPanel.Controls)
            {
                if (c.GetType() == typeof(Panel))
                {

                }
            }
        }






    }
}