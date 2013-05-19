using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GenericContent
/// </summary>
public class GenericContent
{

    const Type defaultGenericContentType = typeof(SimpleText);

    AbstractInputController controller;

	public GenericContent(Type type=null)
    {
        if ((!type.GetNestedTypes().Contains(typeof(AbstractInputController))) || type==null )
            this.controller = (AbstractInputController)System.Activator.CreateInstance(defaultGenericContentType);
        else
            this.controller = (AbstractInputController)System.Activator.CreateInstance(type);

	}
}
