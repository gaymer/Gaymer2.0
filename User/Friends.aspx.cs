using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Friends : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Normal.FillData();
    }
    //public void FillData()
    //{
    //    GaymerLINQDataContext db = new GaymerLINQDataContext();
     
    //    var user = (from a in db.Users
                   
    //                select new
    //                {
    //                    Uid = a.UID,
    //                    Uname = a.Username,
    //                    Role = a.RoleID,
    //                    Firstname = a.UserAbout.FirstName,
    //                    Lastname = a.UserAbout.LastName,
    //                    Avatar = "",
    //                    AboutMe = "",
    //                    Birthdate = a.UserAbout.Birthdate,
    //                    Sex = a.UserAbout.Gender,
    //                    Living = ""
    //                }).FirstOrDefault();
        
    //}
}