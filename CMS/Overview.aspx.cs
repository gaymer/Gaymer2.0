using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class CMS_Overview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["view"] != null)
        {
            switch (Request["view"].ToLower())
            {
                case "permission":
                    FillPermissions();
                    break;
                case "role":
                    FillRoles();
                    break;
                case "user":
                    FillUsers();
                    break;
                case "contenttype":
                    FillContentTypes();
                    break;
                case "inputelement":
                    FillInputElements();
                    break;
                case "inputs":
                    FillInputDataElements();
                    break;
                default:
                    FillDefault();
                    break;
            }
        }
        else
        {
            FillDefault();
        }


        gvOverview.DataBind();
        lblNumberOfRows.Text = gvOverview.Rows.Count.ToString() + " rader:";
    }

    private void FillInputDataElements()
    {
        gvOverview.DataSource = ManageDB.query(@"
            SELECT        idt.ElementInContentId, idt.Value, idt.Label
            FROM          DynamicContentType AS dct INNER JOIN
                              ElementInContent AS eic ON dct.DynamicContentTypeId = eic.ContentTypeId INNER JOIN
                              InputDataSimpleText AS idt ON eic.Id = idt.ElementInContentId
            ORDER BY eic.Weight
        ", debug: true);

    }


    private void FillDefault()
    {
        FillPermissions();
    }

    private void FillInputElements()
    {
        gvOverview.DataSource = ManageDB.query(@"
            SELECT  *
            FROM    InputElement
        ",debug:true);
    }

    private void FillContentTypes()
    {
        gvOverview.DataSource = ManageDB.query(@"
            SELECT  *
            FROM    DynamicContentType
            ORDER BY Name
        ", debug: true);
    }

    private void FillUsers()
    {
        gvOverview.DataSource = ManageDB.query(@"
            SELECT  *
            FROM    [User]
            ORDER BY Username
        ", debug: true);
    }

    private void FillRoles()
    {
        gvOverview.DataSource = ManageDB.query(@"
            SELECT  *
            FROM    Role
            ORDER BY Role
        ", debug: true);
    }

    private void FillPermissions()
    {
        gvOverview.DataSource = ManageDB.query(@"
            SELECT  *
            FROM    Permission
            ORDER BY PermissionUniqueString
        ", debug: true);
    }
}