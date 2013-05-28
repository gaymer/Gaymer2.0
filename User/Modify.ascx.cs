using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Modify : System.Web.UI.UserControl
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
                        Uname = a.Username,
                        Firstname = a.UserAbout.FirstName,
                        Lastname = a.UserAbout.LastName,
                        Avatar = a.Avatar,
                        AboutMe = "",
                        Birthdate = a.UserAbout.Birthdate,
                        Sex = a.UserAbout.Gender,
                        Living = ""
                    }).FirstOrDefault();

        Username.Text = user.Uname;

        //MyAvatar.ImageUrl = 
        MyAvatar.AlternateText = user.Uname + " Avatar";

        AboutMeTxt.Text = user.AboutMe;

        UserFirstName.Text = user.Firstname;
        UserLastName.Text = user.Lastname;
        if (user.Birthdate.HasValue)
        {
            UserAgeTxtBox.Text = user.Birthdate.Value.Year + "-" + user.Birthdate.Value.Month + "-" + user.Birthdate.Value.Day;
        }

        if (user.Sex == null)
        {
            GenderList.SelectedValue = "null";
        }
        else if (user.Sex == true)
        {
            GenderList.SelectedValue = "true";
        }
        else
        {
            GenderList.SelectedValue = "false";
        }

        UserLivingPlaceTxtBox.Text = user.Living;
    }
    public void SaveData()
    {
        string AboutMe = AboutMeTxt.Text;
        string fName = UserFirstName.Text;
        string lName = UserLastName.Text;
        DateTime? BirthDate = Birthdate(UserAgeTxtBox.Text);
        bool? sex = GenderConvert(GenderList.SelectedValue);
        string Livingplace = UserLivingPlaceTxtBox.Text;

        GaymerLINQDataContext db = new GaymerLINQDataContext();
        LoginLib login = new LoginLib();

        var user = (from a in db.Users
                   where a.UID == login.GetUserID()
                   select a).FirstOrDefault();

        
        if (user.AbID == null)
        {
            UserAbout about = new UserAbout();
            
            about.Birthdate = BirthDate;
            about.FirstName = fName;
            about.LastName = lName;
            about.Gender = sex;
            about.Location = Livingplace;

            about.Users.Add(user);
            db.UserAbouts.InsertOnSubmit(about);
        }
        else
        {
            var about = (from a in db.UserAbouts
                         where a.AbID == user.AbID
                         select a).FirstOrDefault();

            about.Birthdate = BirthDate;
            about.FirstName = fName;
            about.LastName = lName;
            about.Gender = sex;
            about.Location = Livingplace;
        }

        try
        {
            db.SubmitChanges();
        }
        catch (Exception ab)
        {
            Response.Redirect("UserPage.aspx?db_feil");
        }
    }
    private DateTime? Birthdate(string date)
    {
        string[] tmp = date.Split('-');
        if (tmp.Length == 3)
            return new DateTime(int.Parse(tmp[0]), int.Parse(tmp[1]), int.Parse(tmp[2]));
        else
            return null;
    }
    private bool? GenderConvert(string sex)
    {
        if (sex == "null")
            return null;
        else if (sex == "false")
            return false;
        else
            return true;
    }

    protected void RedAvatarbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("/user/Avatar.aspx");
    }
}