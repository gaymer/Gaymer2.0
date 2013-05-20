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
    public SimpleText()
        : base()
    {
        base.Value = "SimpleText";
    }

    public override void insertEdit(PlaceHolder ph)
    {
        ph.Controls.Add(new Control());
    }

    public override Control getControl()
    {
        throw new NotImplementedException();
    }
}