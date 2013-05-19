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
        base.Value = "ComplexText";
	}

    public override void insertEdit(System.Web.UI.WebControls.PlaceHolder ph)
    {
        ph.Controls.Add(new Control());
    }
}