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

    public AbstractInputController controller;

    public static GenericContent getContent(int contentId)
    {
        Dictionary<string, object> parameterList = new Dictionary<string, object>();
        parameterList.Add("ContentId", contentId);

        DataTable dt = ManageDB.query(@"
                SELECT * 
                FROM DynamicContent 
                WHERE DynamicContentId=@ContentId
            ", parameterList);

        if (dt==null)
            return null;

        int contentType = (int)dt.Rows[0].ItemArray[1];
        DateTime createTime = (DateTime)dt.Rows[0].ItemArray[2];
        DateTime updateTime = (DateTime)dt.Rows[0].ItemArray[3];
        int author = (int)dt.Rows[0].ItemArray[4];


        return new GenericContent(contentId, contentType, createTime, updateTime, author);
    }

    public GenericContent(int contentId, int contentType, DateTime createTime, DateTime updateTime, int author)
    {
        this.ContentId = contentId;
        this.ContentType = contentType;
        this.CreateTime = createTime;
        this.UpdateTime = updateTime;
        this.Author = author;
    }





	public GenericContent(Type type=null)
    {

        if (type == null || !type.IsSubclassOf(typeof(AbstractInputController)))
            this.controller = (AbstractInputController)System.Activator.CreateInstance(defaultGenericContentType);
        else
            this.controller = (AbstractInputController)System.Activator.CreateInstance(type);

	}
}
