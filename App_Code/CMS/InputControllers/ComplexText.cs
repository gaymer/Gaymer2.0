using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for ComplexText
/// </summary>
public abstract class ComplexText
    : AbstractInputController
{

    public ComplexText(int i)
        : base(i)
    {
        base.InputElementName = "ComplexText";
    }

}

