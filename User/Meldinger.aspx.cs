using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Meldinger : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       VenstreFill();
    }

    public void VenstreFill()
    {
        //Finner brukere som har sendt "deg" meldinger

        LoginLib login = new LoginLib();
        int useID = login.GetUserID();

        Dictionary<String, object> parameter = new Dictionary<string, object>();
        parameter.Add("@UserID", useID);

        DataTable dt = ManageDB.query(@"
            SELECT [User].Username,PrivateMessage.[Read]
            FROM PrivateMessage,[User]
            WHERE PrivateMessage.[To] = @UserID
               AND   PrivateMessage.[From] = [User].UID
            ", parameter, debug: true);

        MeldBrukere.DataSource = dt;
        MeldBrukere.DataBind();

    }

    public void HoyreFill()
    {
        //Viser meldinger fra valgt bruker 

        
    }
    protected void MeldBrukere_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow rad = MeldingerGV.SelectedRow;
        
    }
}