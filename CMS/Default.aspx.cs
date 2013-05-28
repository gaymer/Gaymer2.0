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
        string qsContentIdString = Request.QueryString["content"];
        qsContentIdString = string.IsNullOrEmpty(qsContentIdString)? null: qsContentIdString;
        int contentId;

        if (!Int32.TryParse(qsContentIdString, out contentId))
        {
            Response.Redirect("/CMS/Default.aspx?Content=1");
        }

        GenericContent content = GenericContent.getContent(contentId);




        AddHTML("Before content <br />");

        foreach (int inputElementId in content.InputElementTypeList)
        {
            AbstractInputController myInput = new SimpleText(contentId);
            myInput.AddEdit(GenericContentPanel,1);
        }

        AddHTML("<br /> After content");

    }


    private AbstractInputController getInputObject(int inputElementId)

}