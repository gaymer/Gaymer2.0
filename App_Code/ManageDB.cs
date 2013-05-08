using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using System.Data.SqlClient;


namespace Gaymer.Classes
{

    public class ManageDB
    {

        


        static string connectionStringName = "gaymerdbConnectionString";
        //static ManageDB theInstance;
        //public static ManageDB Instance
        //{
        //    get
        //    {
        //        if (!isInitialized)
        //            theInstance = new ManageDB();

        //        return theInstance;
        //    }
        //}

        static SqlConnection dbConnection;
        static bool isInitialized = false;

        //private ManageDB()
        //{
        //    dbConnection = new SqlConnection();
        //    dbConnection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        //    isInitialized = true;
        //}


        static private SqlConnection openConnection()
        {
            dbConnection.Open();
            return dbConnection;
        }

        static private void init()
        {
            dbConnection = new SqlConnection();
            dbConnection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            isInitialized = true;
        }


        static private void closeConnection()
        {
            dbConnection.Close();
        }

        /// <summary>
        /// Returns a DataTable containing the results of the query (SELECT-statement only)
        /// </summary>
        /// <param name="sqlString">The SQL</param>
        /// <returns></returns>
        static public DataTable query(string sqlString)
        {
            if (sqlString == "") return null;

            DataTable returnTable = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (!isInitialized) init();
                //dbConnection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
                sqlCommand = new SqlCommand(sqlString, dbConnection);
                returnTable = new DataTable();
           
                
                openConnection();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                returnTable.Load(reader);
                reader.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Database error (Query): " + e.ToString());
            }
            finally
            {
                closeConnection();
                sqlCommand.Dispose();
            }
            return returnTable;
        }

        /// <summary>
        /// Returns the number of affected rows from the Non-Query (UPDATE-, INSERT- or DELETE-statement only)
        /// </summary>
        /// <param name="sqlString">The SQL</param>
        /// <returns></returns>
        static public int nonQuery(string sqlString)
        {
            if (sqlString == "") return 0;

            int numberOfRows = 0;

            SqlCommand sqlCommand = null;

            try
            {
                if (!isInitialized) init();
                //dbConnection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
                sqlCommand = new SqlCommand(sqlString, dbConnection);


                openConnection();
                numberOfRows = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Database error (NonQuery): " + e.ToString());
            }
            finally
            {
                closeConnection();
                sqlCommand.Dispose();
            }
            return numberOfRows;

        }

        public static bool userHasRole(int roleId, int userId)
        {
            bool returnValue = false;

            if (roleId < 1 || userId < 1) return false;


            DataTable dt = Gaymer.Classes.ManageDB.query(@"
            SELECT       Role.Role
            FROM         UserInRole 
                         INNER JOIN
                         Role ON UserInRole.inRoleID = " + roleId + @"
                         INNER JOIN
                         [User] ON UserInRole.inUserID = [User].UID AND [User].UID = " + userId + @"
            ORDER BY [User].UID
        ");

            returnValue = (dt.Rows.Count < 1) ? false : true;

            return returnValue;
        }


    }
}
