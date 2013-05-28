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

    public SimpleText()
        : base()
    {
        base.InputElementName = "SimpleText";
        tbValue = new TextBox();
        tbLabel = new TextBox();
    }

    public override void AddEdit(Panel panel)
    {
        throw new NotImplementedException();
    }

    public override void AddDisplay(Panel panel)
    {
        throw new NotImplementedException();
    }
}