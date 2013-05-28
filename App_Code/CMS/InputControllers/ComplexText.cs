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

    public ComplexText()
    {
        base.InputElementName = "ComplexText";
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


public class ComplexText2
    : ComplexText
{

    public ComplexText2()
    {
        base.InputElementName = "ComplexText2";
    }

}