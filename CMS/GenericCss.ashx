<%@ WebHandler Language="C#" Class="GenericCssHandler" %>

using System;
using System.Collections.Generic;
using System.Web;

public class GenericCssHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/css";
        context.Response.Write("/* Dynamic CSS: */");

        int dynamicContentId;
        if (!Int32.TryParse(context.Request.QueryString["contenttype"], out dynamicContentId))
        {
            context.Response.Write("/* #Error A : no contenttype */");
            return;
        }
        
        var parameters = new Dictionary<string, object>{{"@DynamicContentId", dynamicContentId}};
        string cssString = ManageDB.GetSingleValueFromQuery<string>(@"
                SELECT  CssFileContent
                FROM    DynamicContentType
                WHERE   DynamicContentTypeId = @DynamicContentId
            ", parameters);

        if (string.IsNullOrEmpty(cssString))
        {
            context.Response.Write("/* #Error B : no css */");
            return;
        }

        context.Response.Write(cssString);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}