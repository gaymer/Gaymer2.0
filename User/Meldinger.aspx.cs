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

        LoginLib login = new LoginLib();
        int useID = login.GetUserID();

        Dictionary<String, object> parameter = new Dictionary<string, object>();
        parameter.Add("@UserID", useID);

        DataTable dt = ManageDB.query(@"
        SELECT Text,Time,Read
        FROM PrivateMessage
        WHERE [From]=@UserID AND [To]=@klikkID", parameter, debug: true);

        PrivateMessage pm = new PrivateMessage();

        //if (pm.Text == "Friend request")
        //{
        //    MeldingerGV.
        //}
        
    }
    protected void MeldBrukere_SelectedIndexChanged(object sender, EventArgs e)
    {
        throw new Exception("heihei"); 
        
    }
    protected void MeldBrukere_RowCommand(object sender, GridViewCommandEventArgs e)
    {
            throw new Exception("Wakakakakakakaaa" + e.CommandName); 
    }
}