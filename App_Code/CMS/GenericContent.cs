using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for GenericContent
/// </summary>
public class GenericContent
{

    public int ContentId { get; private set; }
    public int ContentType { get; private set; }
    public int Author { get; private set; }
    public DateTime? CreateTime { get; private set; }
    public DateTime? UpdateTime { get; private set; }

    static Type defaultGenericContentType = typeof(SimpleText);

    public List<int> InputElementTypeList;
    public List<int> InputElementDataList;

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

        int contentType = (int) dt.Rows[0]["ContentType"];
        DateTime? createTime = (dt.Rows[0]["CreateTime"] ?? (DateTime?)null) as DateTime?;
        DateTime? updateTime = (dt.Rows[0]["UpdateTime"] ?? (DateTime?)null) as DateTime?;
        int author = (int)dt.Rows[0]["Author"];


        return new GenericContent(contentId, contentType, createTime, updateTime, author);
    }

    public GenericContent(int contentId, int contentType, DateTime? createTime, DateTime? updateTime, int author)
    {
        this.ContentId = contentId;
        this.ContentType = contentType;
        this.CreateTime = createTime;
        this.UpdateTime = updateTime;
        this.Author = author;

        var parameters = new Dictionary<string, object>();
        parameters.Add("@ContentTypeId",contentType);

        this.InputElementTypeList = ManageDB.GetSingleColumnResultAsList<int>(@"
            SELECT       ie.InputElementId
            FROM         DynamicContentType AS dct INNER JOIN
                             ElementInContent AS eic ON dct.DynamicContentTypeId = eic.ContentTypeId INNER JOIN
                             InputElement AS ie ON eic.InputElementId = ie.InputElementId
            WHERE        (dct.DynamicContentTypeId = @ContentTypeId)
            ORDER BY     eic.Weight
        ", parameters);


        this.InputElementDataList = ManageDB.GetSingleColumnResultAsList<int>(@"
            SELECT        idt.ElementInContentId
            FROM          DynamicContentType AS dct INNER JOIN
                              ElementInContent AS eic ON dct.DynamicContentTypeId = eic.ContentTypeId INNER JOIN
                              InputDataSimpleText AS idt ON eic.Id = idt.ElementInContentId
            WHERE         (idt.ContentId = 1)
            ORDER BY      eic.Weight
        ", parameters);



    }

    public static void AddHtmlToPanel(string htmlString, Panel panel)
    {
        if (panel != null) panel.Controls.Add(new LiteralControl(htmlString));
    }

}
