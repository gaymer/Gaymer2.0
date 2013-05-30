using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for SimpleText
/// </summary>
public class SimpleText
    : AbstractInputController
{
    private TextBox tbValue { set; get; }
    private TextBox tbLabel { set; get; }

    public SimpleText(int i)
        : base(i)
    {
        base.InputElementName = "SimpleText";
        tbValue = new TextBox();
        tbLabel = new TextBox();
    }


    private string GetValueValue(int inputDataId)
    {
        var param = new Dictionary<string, object> {{"@inputDataId", inputDataId}};
        return ManageDB.GetFirstValueFromQuery<string>(@"
                SELECT  Value
                FROM    InputDataSimpleText
                WHERE   id = @inputDataId
            ", param, debug: true);
    }

    private string GetLabelValue(int inputDataId)
    {
        var param = new Dictionary<string, object> {{"@inputDataId", inputDataId}};
        return ManageDB.GetFirstValueFromQuery<string>(@"
                SELECT  Label
                FROM    InputDataSimpleText
                WHERE   id = @inputDataId
            ", param, debug: true);
    }


    public override void AddEdit(Panel panel, int contentId = -1, int inputDataId = -1)
    {
        if (inputDataId > 0) // If -1 the content is to be created and has no values in DB
        {
            tbLabel.Text = GetLabelValue(inputDataId);
            tbValue.Text = GetValueValue(inputDataId);
        }

        GenericContent.AddHtmlToPanel("<div>", panel);
        GenericContent.AddHtmlToPanel("SimpleLabel: ", panel);
        panel.Controls.Add(tbLabel);

        GenericContent.AddHtmlToPanel("<br />", panel);

        GenericContent.AddHtmlToPanel("SimpleValue: ", panel);
        panel.Controls.Add(tbValue);
        GenericContent.AddHtmlToPanel("</div>", panel);
    }

    public override void AddDisplay(Panel panel, int contentId, int inputDataId)
    {
        var p = new Dictionary<string, object> {{"@InputDataId", inputDataId}};
        string CSSclassName = ManageDB.GetFirstValueFromQuery<string>(@"
                SELECT      eic.CSSclass
                FROM        ElementInContent AS eic INNER JOIN
                            InputDataSimpleText AS idt ON eic.Id = idt.ElementInContentId
                WHERE       (idt.id = @InputDataId)
            ", p);

        Label lblLabel = new Label();
        lblLabel.CssClass = CSSclassName + "_label";
        lblLabel.Text = GetLabelValue(inputDataId);

        Label lblValue = new Label();
        lblValue.CssClass = CSSclassName + "_value";
        lblValue.Text = GetLabelValue(inputDataId);

        GenericContent.AddHtmlToPanel("<div id=\"inputElementData_" + inputDataId + "\">", panel);
        panel.Controls.Add(lblLabel);
        GenericContent.AddHtmlToPanel("<br />", panel);
        panel.Controls.Add(lblValue);
        GenericContent.AddHtmlToPanel("</div>", panel);

    }

    public override void SaveInputFromEdit(Panel panel, int contentId, int inputDataId)
    {
        throw new NotImplementedException();
    }

    public override void SaveInputFromCreate(Panel panel, int contentType)
    {
        throw new NotImplementedException();
    }
}