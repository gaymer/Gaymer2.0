using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using System;
using System.Data;
using System.Data.SqlClient;

using Gaymer.Classes;

public partial class CMS_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // DataTable dt = Gaymer.Classes.ManageDB.query("SELECT * FROM User");

        //Output.Text = "Det er " + dt.Rows.Count.ToString() + " brukere i databasen.";

        Output.Text = "Det er brukere i databasen.";


        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["gaymerdbConnectionString"].ConnectionString;

        // Provide the query string with a parameter placeholder.
        string queryString = "SELECT UID, Username, Mail, Password FROM User";

        // Specify the parameter value.
        //int paramValue = 5;

        // Create and open the connection in a using block. This
        // ensures that all resources will be closed and disposed
        // when the code exits.
        using (SqlConnection connection =
        new SqlConnection(connectionString))
        {
            // Create the Command and Parameter objects.
            SqlCommand command = new SqlCommand(queryString, connection);
            //command.Parameters.AddWithValue("@pricePoint", paramValue);

            // Open the connection in a try/catch block.
            // Create and execute the DataReader, writing the result
            // set to the console window.
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                //while (reader.Read())
                //{
                //    Output.Text = reader[0].ToString() + " " + reader[1].ToString() + " :: " + reader[2].ToString() + " #" + reader[3].ToString();
                //}
                //reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Database error (Query): " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }



        }
    }
}