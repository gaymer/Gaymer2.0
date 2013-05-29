using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class User_Normal : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void FillData()
    {
        LoginLib login = new LoginLib();

        string userIdString = Request.QueryString["UserId"];
        int userID;
        if (!Int32.TryParse(userIdString, out userID))
        {
            userID = login.GetUserID();
        }

        GaymerLINQDataContext db = new GaymerLINQDataContext();
            
            var user = (from a in db.Users
                        where a.UID == userID
                        select new
                        {
                            Uid = a.UID,
                            Uname = a.Username,                        
                            Firstname = a.UserAbout.FirstName,
                            Lastname = a.UserAbout.LastName,
                            Avatar = a.Avatar,
                            AboutMe = "",
                            Birthdate = a.UserAbout.Birthdate,
                            Sex = a.UserAbout.Gender,
                            Living = ""
                        }).FirstOrDefault();


            // Henter ut brukerens rolle fra databasen. 

            var userRole = (from UserInRoles in db.UserInRoles
                            from Roles in db.Roles
                            where UserInRoles.inUserID == user.Uid && UserInRoles.inRoleID == Roles.RoleID   //Finner "rett" bruker i UserInRole. 
                            select new
                            {
                                URole = UserInRoles.inRoleID

                            }).FirstOrDefault();

            var rolle = (from Roles in db.Roles
                         where Roles.RoleID == userRole.URole
                         select new
                         {
                             BrukerRolle = Roles.Role1
                         }).FirstOrDefault();

            lblRolle.Text = rolle.BrukerRolle;
            Username.Text = user.Uname;


            //if (user.Avatar == null)
            //{
            //    MyAvatar.ImageUrl = "~/Style/Images/mario.jpg"; // Hvis bruker ikke har satt et bilde 
            //} 

            MyAvatar.ImageUrl = "~/user/ViewAvatar.aspx?uid=" + userID;                    
            MyAvatar.AlternateText = user.Uname + " Avatar";

            AboutMeTxt.Text = user.AboutMe;

            UsersNameTxt.Text = user.Firstname + " " + user.Lastname;
            UserAgeTxt.Text = AgeYr(user.Birthdate).ToString();
            UserSexTxt.Text = user.Sex == null ? "Undefined" : user.Sex == true ? "Woman" : "Man";
            UserLivingPlaceTxt.Text = user.Living;

            //Finne alle venner/relasjoner

            Dictionary<String, object> parameter = new Dictionary<string, object>();
            parameter.Add("@UserID", userID);

            DataTable dt = ManageDB.query(@"
            SELECT [User].Username, [User].UID
            FROM [User],UserRelation
            WHERE UserRelation.UserId = @UserID
                AND [User].UID = UserRelation.RelatedUserId
            ", parameter, debug: true);

            FriendView.DataSource = dt;
            FriendView.DataBind();
            
            if (userID == login.GetUserID())
                FriendRequestbtn.Visible = false;

            //DataRow finnRad = dt.Rows.Find(userIdString);

            //if (userID == login.GetUserID()||finnRad!=null)
            //    FriendRequestbtn.Visible = false;
          
    }
    private int AgeYr(DateTime? Bdate)
    {
        if (Bdate == null)
        {
            return 0;
        }
        else
        {
            DateTime date = Bdate.Value;
            int arteller;
            DateTime now = DateTime.UtcNow;
            if ((int)now.Month <= date.Month)
            {
                if ((int)now.Day <= date.Day)
                    arteller = -1;
                else
                    arteller = 0;
            }
            else
                arteller = 0;

            return now.Year - date.Year + arteller;
        }
    }

    protected void finnVennerbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("/User/vennesok.aspx");
    }

}