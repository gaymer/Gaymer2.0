using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ListContentTypes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void DataList1_CancelCommand(object source, DataListCommandEventArgs e)
    {
        DataList1.EditItemIndex = -1;
        DataList1.DataBind();
    }

    protected void DataList1_EditCommand(object source, DataListCommandEventArgs e)
    {
        DataList1.EditItemIndex = e.Item.ItemIndex;
        DataList1.DataBind();
    }

    protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
    {
        String dcti_s = DataList1.DataKeys[e.Item.ItemIndex].ToString();
        int dcti = -1;
        if (!Int32.TryParse(dcti_s, out dcti)) 
        {
            return;
        }
        String newName = ((TextBox)e.Item.FindControl("ct_name")).Text;

        Dictionary<string, object> dict = new Dictionary<string, object>();
        dict.Add("@dcti", dcti);
        dict.Add("@newName", newName);

        string q = "UPDATE DynamicContentType SET name=@newName WHERE DynamicContentTypeId=@dcti";
        ManageDB.query(q, dict);

        DataList1.EditItemIndex = -1;
        DataList1.DataBind();
    }
}