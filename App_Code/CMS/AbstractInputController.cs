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

    public string InputElementName { get; protected set; }
    public int InputDataId { get; protected set; }

    public abstract void AddEdit(Panel panel, int contentId=-1, int inputDataId=-1);
    public abstract void AddDisplay(Panel panel, int contentId, int inputDataId);
    public abstract void SaveInput(Panel panel, int contentId);

    public void AddCreate(Panel panel)
    {
        AddEdit(panel);
    }


    protected AbstractInputController(int contentId)
    {
        InputDataId = contentId;
        InputElementName = "BaseClass";
	}
}