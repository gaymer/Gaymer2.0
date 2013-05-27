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

    public String Value { get; set; }
    
    public abstract void insertEdit(PlaceHolder ph);

    public abstract Control getControl();
    

	public AbstractInputController()

	{
        Value = "BaseClass";
	}
}