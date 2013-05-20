using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Reflection;

/// <summary>
/// Summary description for GenericContent
/// </summary>
public class GenericContent<T> 
    where T : AbstractInputController
{

    static Type defaultGenericContentType = typeof(SimpleText);

    public AbstractInputController controller;


    

	public void genericMethod<T>(Type type=null) 
        where T : AbstractInputController
    {

        //if (type == null || (type is AbstractInputController))
        //    this.controller = (AbstractInputController)System.Activator.CreateInstance(defaultGenericContentType);
        //else
        //    this.controller = (AbstractInputController)System.Activator.CreateInstance(type);

	}

	public GenericContent(Type type=null)
    {
        Type thisType = this.GetType();

        bool areEqual = thisType.Equals(type);

        if ( areEqual )
            throw new Exception("Sweet! " + type.ToString());

        if (type is T)
            throw new Exception("Whaat? " + type.ToString());



        if (type == null || !(type.GetType() is T))
            this.controller = (AbstractInputController)System.Activator.CreateInstance(defaultGenericContentType);
        else
            this.controller = (T)System.Activator.CreateInstance(type);

	}
}
