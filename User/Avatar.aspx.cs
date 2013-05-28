using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;

public partial class User_Avatar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void avatarbtn_Click(object sender, EventArgs e)
    {

        Dictionary<string,object> parameters = new Dictionary<string,object>();
        parameters.Add("@ImgBody",ConvertImageToByteArray(this.Fileuploade));
        int i = ManageDB.nonQuery("UPDATE [User] SET Avatar =@ImgBody",parameters);

        if(i!=0)
                errorlbl.Text += "Bilde";
        else
                errorlbl.Text += "Fil ikke lastet opp";



        //GaymerLINQDataContext db = new GaymerLINQDataContext();
        //User use = new User();
        //System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();

        //try
        //{
        //    if (this.Fileuploade.HasFile)
        //    {
        //        this.Fileuploade.SaveAs(Server.MapPath("~") + "Style/Images/" + this.Fileuploade.FileName);
        //        AvatarImg.ImageUrl = "/Style/Images/" + this.Fileuploade.FileName;
        //        use.Avatar = new System.Data.Linq.Binary(encoding.GetBytes("/Style/Images/" + this.Fileuploade.FileName));
        //        db.Users.InsertOnSubmit(use); 
        //    }
        //    else
        //        errorlbl.Text += "Fil ikke lastet opp";
        //}
        //catch(Exception exc)
        //{
        //    throw new Exception(exc.Message);
        //}
        //db.Dispose();
        
    }

    protected void tilbake_Click(object sender, EventArgs e)
    {

        Response.Redirect("/user/UserPage.aspx");
    }

    private byte[] ConvertImageToByteArray(FileUpload fuImage)
    {
        byte[] ImageByteArray;
        try
        {
            MemoryStream ms = new MemoryStream(fuImage.FileBytes);
            ImageByteArray = ms.ToArray();
            return ImageByteArray;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}