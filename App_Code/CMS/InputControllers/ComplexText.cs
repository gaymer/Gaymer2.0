using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for ComplexText
/// </summary>
public class ComplexText
    : AbstractInputController
{

    public ComplexText(int i)
        : base(i)
    {
        base.InputElementName = "ComplexText";
    }

    public override void AddEdit(Panel panel, int contentId)
    {
        throw new NotImplementedException();
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

