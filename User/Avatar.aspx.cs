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
        if (this.Fileuploade.HasFile)
        {

            LoginLib Log = new LoginLib();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@ImgBody", ConvertImageToByteArray(this.Fileuploade));
            parameters.Add("@UID", Log.GetUserID());
            int i = ManageDB.nonQuery("UPDATE [User] SET Avatar =@ImgBody WHERE UID= @UID", parameters);

            if (i != 0)
            {            
                AvatarImg.ImageUrl = "/User/ViewAvatar.aspx?uid=" + Log.GetUserID();
            }
            else
                errorlbl.Text += "Fil ikke lastet opp";
        }
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
