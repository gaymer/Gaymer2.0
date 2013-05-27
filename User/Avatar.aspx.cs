using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Avatar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void avatarbtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.Fileuploade.HasFile)
            {
                this.Fileuploade.SaveAs(Server.MapPath("~") + "Style/Images/" + this.Fileuploade.FileName);
                AvatarImg.ImageUrl = Server.MapPath("~") + "Style/Images/" + this.Fileuploade.FileName;
                
            }
            else
                errorlbl.Text += "Fil ikke lastet opp";
        }
        catch(Exception exc)
        {
            throw new Exception(exc.Message);
        }
        
    }
    
}