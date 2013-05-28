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

    public override void AddEdit(Panel panel, int contentId)
    {
        GenericContent.AddHtmlToPanel("<div>", panel);
        GenericContent.AddHtmlToPanel("SimpleLabel: ", panel);
        panel.Controls.Add(tbLabel);

        GenericContent.AddHtmlToPanel("<br />", panel);

        GenericContent.AddHtmlToPanel("SimpleValue: ", panel);
        panel.Controls.Add(tbValue);
        GenericContent.AddHtmlToPanel("</div>", panel);
    }

    public override void AddDisplay(Panel panel, int contentId)
    {
        throw new NotImplementedException();
    }

    public override void SaveInput(Panel panel, int contentId)
    {
        throw new NotImplementedException();
    }
}