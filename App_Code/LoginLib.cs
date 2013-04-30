using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class LoginLib : System.Web.UI.Page
{
    GaymerLINQDataContext db = new GaymerLINQDataContext();
    public bool LoginUser(string Username, string Password)
    {
        //Thomas magic Labda LINQ fetch
        string Salt = db.Users.First(k => k.Username == Username).Salt;
        byte[] bytee = System.Text.Encoding.Default.GetBytes(Password+Salt);

        string hash = Convert.ToBase64String(new System.Security.Cryptography.SHA1CryptoServiceProvider().ComputeHash(bytee));

        var LoginTest = (from a in db.Users
                         where a.Username == Username && a.Password == hash
                         select a).FirstOrDefault();
        
        if (LoginTest != null)
        {

            Random rand = new Random();
            string s1 = rand.Next(10000, 99999).ToString();
            byte[] b1 = System.Text.Encoding.Default.GetBytes(Password + s1);
            string p1 = Convert.ToBase64String(new System.Security.Cryptography.SHA1CryptoServiceProvider().ComputeHash(b1));

            LoginTest.Salt = s1;
            LoginTest.Password = p1;
            //Bruker finnes, fortsett login

            //Make a login session ID to place in cookie so that the user can be verified on every page
            string LoginSessionID = CreateSessionID(LoginTest.UID);
            LoginTest.LoginSession = LoginSessionID;
            MakeCookie(LoginSessionID);
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch
            {
                //Databasen tryna
                return false;
            }
        }
        else
        {
            //Bruker finnes ikke
            return false;
        }
    }
    public string GetCookie()
    {
        string Cookie = "";
        try
        {
            Cookie = Server.HtmlEncode(HttpContext.Current.Request.Cookies["GaymerLoginID"].Value);
        }
        catch { }
        return Cookie;
    }
    public bool IsUserLoggedIn()
    {
        var Login = (from a in db.Users
                     where a.LoginSession == GetCookie()
                     select a).FirstOrDefault();
        if (Login != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public int GetUserID()
    {
        return (from a in db.Users
                     where a.LoginSession == GetCookie()
                     select a.UID).FirstOrDefault();
    }
    public void CreateNewCookie()
    {
        var Login = (from a in db.Users
                     where a.LoginSession == GetCookie()
                     select a).FirstOrDefault();

        string LoginSessionID = CreateSessionID(Login.UID);
        Login.LoginSession = LoginSessionID;
        MakeCookie(LoginSessionID);
        try
        {
            db.SubmitChanges();
        }
        catch
        {
        }
    }
    public string CreateSessionID(int UserID)
    {
        string tmp = Convert.ToBase64String(new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(System.Text.Encoding.Default.GetBytes(DateTime.Now.Ticks.ToString() + UserID.ToString())));
           tmp.Replace("+","");
           return tmp;
    }
    public void MakeCookie(string LoginSessionID)
    {
        //Create Cookie
        HttpContext.Current.Response.Cookies["GaymerLoginID"].Value = LoginSessionID;
        HttpContext.Current.Response.Cookies["GaymerLoginID"].Expires = DateTime.UtcNow.AddDays(10);
    }
    public void LogOut()
    {
        HttpContext.Current.Response.Cookies["GaymerLoginID"].Value = "";
        HttpContext.Current.Response.Cookies["GaymerLoginID"].Expires = DateTime.UtcNow;
    }
}

