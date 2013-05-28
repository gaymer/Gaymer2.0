using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

using System.Reflection;

/// <summary>
/// Summary description for GenericContent
/// </summary>
public class GenericContent
{

    public int ContentId { get; private set; }
    public int ContentType { get; private set; }
    public int Author { get; private set; }
    public DateTime CreateTime { get; private set; }
    public DateTime UpdateTime { get; private set; }

    static Type defaultGenericContentType = typeof(SimpleText);

    public List<AbstractInputController> ControllerList = new List<AbstractInputController>();

    public static GenericContent getContent(int contentId)
    {
        Dictionary<string, object> parameterList = new Dictionary<string, object>();
        parameterList.Add("ContentId", contentId);

        DataTable dt = ManageDB.query(@"
                SELECT * 
                FROM DynamicContent 
                WHERE DynamicContentId=@ContentId
            ", parameterList);

        if (dt==null || dt.Rows.Count<1)
            return null;

        int contentType = (int)dt.Rows[0]["ContentType"];
        DateTime createTime = (DateTime)dt.Rows[0]["CreateTime"];
        DateTime updateTime = (DateTime)dt.Rows[0]["UpdateTime"];
        int author = (int)dt.Rows[0]["Author"];


        return new GenericContent(contentId, contentType, createTime, updateTime, author);
    }

    public GenericContent(int contentId, int contentType, DateTime createTime, DateTime updateTime, int author)
    {
        this.ContentId = contentId;
        this.ContentType = contentType;
        this.CreateTime = createTime;
        this.UpdateTime = updateTime;
        this.Author = author;

        var parameters = new Dictionary<string, object>();
        parameters.Add("@ContentTypeId",contentType);

        List<int> inputList = ManageDB.GetSingleColumnResultAsList<int>(@"
            SELECT       ie.InputElementId
            FROM         DynamicContentType AS dct INNER JOIN
                         ElementInContent AS eic ON dct.DynamicContentTypeId = eic.ContentTypeId INNER JOIN
                         InputElement AS ie ON eic.InputElementId = ie.InputElementId
            WHERE        (dct.DynamicContentTypeId = @ContentTypeId)
        ", parameters);



    }

}
