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

    int getVisitedUserId()
    {
         string userIdString = Request.QueryString["UserId"];
        int userID;
        if (!Int32.TryParse(userIdString, out userID))
        {
            return -1;
        }
        return userID;
    }

    public void FillData()
    {
        LoginLib login = new LoginLib();
        
        int userID = getVisitedUserId();

        if (userID < 0)
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


            if (userID == login.GetUserID() || isFriend(login.GetUserID(), userID))
                FriendRequestbtn.Visible = false;
    }

    private bool isFriend(int loggedInUserId, int visitedUserId)
    {
        var p = new Dictionary<string, object>();
        p.Add("@UserId", loggedInUserId);
        p.Add("@VisitUserId", visitedUserId);

        DataTable dt = ManageDB.query(@"
                SELECT  RelationId
                FROM    UserRelation
                WHERE   UserId = @UserId
                 AND    RelatedUserId = @VisitUserId
            ", p, debug:true);

        return (dt.Rows.Count > 0);

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

    protected void FriendRequestbtn_Click(object sender, EventArgs e)
    {
        SendRequest(getVisitedUserId());
        FriendRequestbtn.Text = "Request sendt";
        
    }

    public void SendRequest(int userID)
    {

        if (userID < 0)
        {
            // FEIL
        }

        LoginLib login = new LoginLib();

        int visitedUserId = -1;

        if (userID != login.GetUserID())
        {
            visitedUserId = userID;
        }
        GaymerLINQDataContext db = new GaymerLINQDataContext();

        var meldinger = (from pm in db.PrivateMessages
                         where pm.From == login.GetUserID()
                         select pm).FirstOrDefault();
       

        PrivateMessage pmeld = new PrivateMessage();

        pmeld.From = login.GetUserID();
        pmeld.To = visitedUserId;
        pmeld.Text = "Friend request";
        
    }
}
