using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using System.Data.SqlClient;


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
        /// Remember to put brackets around table names (e.g. "SELECT * FROM [tableName]")
        /// </summary>
        /// <param name="sqlString">The SQL</param>
        /// <param name="readOnly">The returned DataTable will be read-only or not. Default value is true</param>
        /// <returns></returns>
        static public DataTable query(string sqlString, bool readOnly=true, bool debug=false)
        {
            if (sqlString == "") return null;

            DataTable returnTable = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (!isInitialized) init();
                sqlCommand = new SqlCommand(sqlString, dbConnection);
                returnTable = new DataTable();
                openConnection();

                if (readOnly)   // DataTable's Load()-method adds read-only values: TODO: is this correct?
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    returnTable.Load(reader);       // Adds rows. Result: read-only
                    reader.Close();
                }
                else            // SqlDataAdapter's Fill()-method executes query and fill values.
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    adapter.Fill(returnTable);      // Fill table from start. Result: NOT read-only
                    adapter.Dispose();
                }

            }
            catch (Exception e)
            {
                if (debug)
                    throw new Exception("Database error (Query): " + e.ToString());
                else
                    return null;
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
        static public int nonQuery(string sqlString, bool debug=false)
        {
            if (sqlString == "") return 0;

            int numberOfRows = 0;

            SqlCommand sqlCommand = null;

            try
            {
                if (!isInitialized) init();
                sqlCommand = new SqlCommand(sqlString, dbConnection);
                openConnection();

                numberOfRows = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                if (debug)
                    throw new Exception("Database error (NonQuery): " + e.ToString());
                else
                    return -1;
            }
            finally
            {
                closeConnection();
                sqlCommand.Dispose();
            }
            return numberOfRows;

        }




    }
