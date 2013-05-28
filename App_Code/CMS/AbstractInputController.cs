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
    public int InputDataId { get; protected set; }


    public abstract void AddEdit(Panel panel, int contentId);
    public abstract void AddDisplay(Panel panel, int contentId);
    public abstract void SaveInput(Panel panel, int contentId);


    public void AddCreate(Panel panel)
    {
        AddEdit(panel, -1);
    }


    protected AbstractInputController(int id)
    {
        InputDataId = id;
        InputElementName = "BaseClass";
	}
}