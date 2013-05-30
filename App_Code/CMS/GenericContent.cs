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

    public List<int> InputElementTypeList = new List<int>();
    public List<int> InputElementDataList = new List<int>();
//    public List<AbstractInputController> ControllerList = new List<AbstractInputController>();

    public static GenericContent GetContent(int contentId)
    {
        var parameterList = new Dictionary<string, object> {{"ContentId", contentId}};

        DataTable dt = ManageDB.query(@"
                SELECT * 
                FROM DynamicContent 
                WHERE DynamicContentId=@ContentId
            ", parameterList);

        if (dt==null || dt.Rows.Count<1)
            return null;

        int contentType = (int) dt.Rows[0]["ContentType"];
        DateTime? createTime = (dt.Rows[0]["CreateTime"]) as DateTime?;
        DateTime? updateTime = (dt.Rows[0]["UpdateTime"]) as DateTime?;
        int author = (int)dt.Rows[0]["Author"];


        return new GenericContent(contentId, contentType, createTime, updateTime, author);
    }

    public GenericContent(int contentType)
    {
        this.InputElementTypeList = GenerateInputElementTypeList(contentType);
    }

    static List<int> GenerateInputElementTypeList(int contentType)
    {
        var parameters = new Dictionary<string, object>();
        parameters.Add("@ContentTypeId", contentType);
        return ManageDB.GetSingleColumnResultAsList<int>(@"
            SELECT       ie.InputElementId
            FROM         DynamicContentType AS dct INNER JOIN
                             ElementInContent AS eic ON dct.DynamicContentTypeId = eic.ContentTypeId INNER JOIN
                             InputElement AS ie ON eic.InputElementId = ie.InputElementId
            WHERE        (dct.DynamicContentTypeId = @ContentTypeId)
            ORDER BY     eic.Weight
        ", parameters);
    }

    static List<int> GenerateInputElementDataList(int contentType, int contentId)
    {
        var parameters = new Dictionary<string, object>();
        parameters.Add("@ContentTypeId", contentType);
        parameters.Add("@ContentId", contentId);
        return ManageDB.GetSingleColumnResultAsList<int>(@"
            SELECT        idt.Id
            FROM          DynamicContentType AS dct INNER JOIN
                              ElementInContent AS eic ON dct.DynamicContentTypeId = eic.ContentTypeId INNER JOIN
                              InputDataSimpleText AS idt ON eic.Id = idt.ElementInContentId
            WHERE         (idt.ContentId = @ContentId)
            ORDER BY      eic.Weight
        ", parameters);
    }

    public GenericContent(int contentId, int contentType, DateTime? createTime, DateTime? updateTime, int author)
    {
        this.ContentId = contentId;
        this.ContentType = contentType;
        this.CreateTime = createTime;
        this.UpdateTime = updateTime;
        this.Author = author;


        this.InputElementTypeList = GenerateInputElementTypeList(contentType);

        this.InputElementDataList = GenerateInputElementDataList(contentType,contentId);



    }

    public static void AddHtmlToPanel(string htmlString, Panel panel)
    {
        if (panel != null) panel.Controls.Add(new LiteralControl(htmlString));
    }

}
