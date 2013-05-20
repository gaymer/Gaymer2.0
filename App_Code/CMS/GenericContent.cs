using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Reflection;

/// <summary>
/// Summary description for GenericContent
/// </summary>
public class GenericContent
{

    static Type defaultGenericContentType = typeof(SimpleText);

    public AbstractInputController controller;



	public GenericContent(Type type=null)
    {

        if (type == null || !type.IsSubclassOf(typeof(AbstractInputController)))
            this.controller = (AbstractInputController)System.Activator.CreateInstance(defaultGenericContentType);
        else
            this.controller = (AbstractInputController)System.Activator.CreateInstance(type);

	}
}
