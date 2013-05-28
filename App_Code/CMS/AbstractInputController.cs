using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for AbstractInputController 
/// </summary>
public abstract class AbstractInputController
{

    public String InputElementName { get; protected set; }


    public abstract void AddEdit(Panel panel);
    public abstract void AddDisplay(Panel panel);


    protected AbstractInputController()

	{
        InputElementName = "BaseClass";
	}
}