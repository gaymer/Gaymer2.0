using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class User_ViewAvatar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public override void ProcessRequest(HttpContext context)
    {

        context.Response.ContentType = "Image/jpeg";

        if (context.Request.QueryString["uid"] != null)
        {
            try
            {
                int uid = 0;
                uid = Convert.ToInt32(context.Request.QueryString["uid"]);
                byte[] byteArray = GetImageFromDB(uid);

                if (byteArray == null)
                {
                    return;
                }

                MemoryStream memoryStream = new MemoryStream(byteArray, false);            
                System.Drawing.Image imgFromGB = System.Drawing.Image.FromStream(memoryStream);
                imgFromGB.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
               
            }
            catch (ArgumentException aex)
            {
                //throw new Exception("The file received from the Map Server is not a valid jpeg image", aex);
            }
        }
    }

    private byte[] GetImageFromDB(int uid)
    {
        var parameters = new Dictionary<string, object>();
        parameters.Add("@uid", uid);

        List<byte[]> byteList = ManageDB.GetSingleColumnResultAsList<byte[]>(@"
            SELECT avatar FROM [User] WHERE UID = @uid
        ", parameters, debug:true);

        if (byteList == null) return null;

        if (byteList.Count < 0) return null;


        if (byteList[0] == null) return null;

        return byteList[0];
    }
    
}