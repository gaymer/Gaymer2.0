using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class User_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
        protected void RegisterBtn_Click(object sender, EventArgs e)
    {
        string Username = RegUsernameBox.Text;
        string Email = RegEmailBox.Text;
        string REmail = RegREmailBox.Text;
        string Password = RegPasswordBox.Text;
        string RPassword = RegRPasswordBox.Text;
        if (Email != REmail)
        {
            RegError.Text = "Email don't match";
        }
        else if (Password != RPassword)
        {
            RegError.Text = "Password don't match";
        }
        else
        {
            GaymerLINQDataContext db = new GaymerLINQDataContext();
            //Sjekk om email eller username eksisterer
            var UsernameTest = (from a in db.Users
                                where a.Username == Username
                                select a).FirstOrDefault();
            var EmailTest = (from a in db.Users
                             where a.Mail == Email
                             select a).FirstOrDefault();

            if (UsernameTest == null && EmailTest == null)
            {
                //klar for registrering
                User use = new User();
                use.Username = Username;
                use.Mail = Email;

                Random rand = new Random();
                string salt = rand.Next(10000, 99999).ToString();
                byte[] bytee = System.Text.Encoding.Default.GetBytes(Password + salt);

                string hash = Convert.ToBase64String(new System.Security.Cryptography.SHA1CryptoServiceProvider().ComputeHash(bytee));

                use.Salt = salt;
                use.Password = hash;
                use.RoleID = 2;

                db.Users.InsertOnSubmit(use);

                try
                {
                    db.SubmitChanges();
                    RegError.Text = "You are now registered";
                }
                catch
                {
                    RegError.Text = "General database error";
                }
                finally
                {
                    db.Dispose();
                }
            }
            else if (UsernameTest != null && EmailTest != null)
            {

            }
            else if (UsernameTest != null)
            {

            }
            else if (EmailTest != null)
            {

            }
        }
    }
    private void ReadUserLINQ()
    {
        GaymerLINQDataContext db = new GaymerLINQDataContext();

        var result = (from a in db.Users
                      select a).FirstOrDefault();
        result.Username = "nytt navn";
        db.SubmitChanges();

    }
    private bool isUser(int ID)
    {
        return true;
    }
    private void ReadUserSQL()
    {
        string queryString = "SELECT * FROM dbo.[User];";
        using (SqlConnection connection = new SqlConnection(
                   "Data Source=mssql1.cloudsites.gearhost.com;Initial Catalog=gaymerdb;Persist Security Info=True;User ID=gaymerdb;Password=hSyOl042"))
        {
            SqlCommand command = new SqlCommand(
                queryString, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                string result = "";
                while (reader.Read())
                {

                    result = (String.Format("{0}, {1}",
                        reader[0], reader[1]));
                }
                RegError.Text = result;
            }
            catch
            {
                RegError.Text = "Fail";
            }
            finally
            {
                reader.Close();
            }
        }
    }
}
