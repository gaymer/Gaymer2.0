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
        GaymerLINQDataContext db = new GaymerLINQDataContext();
        LoginLib login = new LoginLib();
        var user = (from a in db.Users
                    where a.UID == login.GetUserID()
                    select new
                    {
                        Uid = a.UID,
                        Uname = a.Username,   
                        Role = a.RoleID,
                        Firstname = a.UserAbout.FirstName,
                        Lastname = a.UserAbout.LastName,
                        Avatar = "",
                        AboutMe = "",
                        Birthdate = a.UserAbout.Birthdate,
                        Sex = a.UserAbout.Gender,
                        Living = ""
                    }).FirstOrDefault();

        // Henter ut brukerens rolle fra databasen. 

        var userRole = (from UserInRoles in db.UserInRoles
                        where UserInRoles.UserRole == user.Role  //Finner "rett" bruker i UserInRole. 
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
        
        //MyAvatar.ImageUrl = "~Style/Avatar/" + user.Avatar;
        MyAvatar.AlternateText = user.Uname + " Avatar";

        AboutMeTxt.Text = user.AboutMe;

        UsersNameTxt.Text = user.Firstname + " " + user.Lastname;
        UserAgeTxt.Text = AgeYr(user.Birthdate).ToString();
        UserSexTxt.Text = user.Sex == null ? "Undefined" : user.Sex == true ? "Woman" : "Man";
        UserLivingPlaceTxt.Text = user.Living;
        if (lblRolle.Text=="Administrator")
        {
            AdminPanel.Visible = true; 
        }


        //Finne alle venner/relasjoner

        Dictionary<String, object> parameter = new Dictionary<string, object>();
        parameter.Add("@UserID", login.GetUserID());
        
        DataTable dt = ManageDB.query(@"
            SELECT [User].Username
            FROM [User],UserRelation
            WHERE UserRelation.UserId = @UserID
                AND [User].UID = UserRelation.RelatedUserId
            ",parameter,debug:true);

        FriendView.DataSource = dt;
        FriendView.DataBind();



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

}