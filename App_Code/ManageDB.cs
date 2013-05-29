using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using System.Data.SqlClient;


    public class ManageDB
    {
        private const string ConnectionStringName = "gaymerdbConnectionString";

        static SqlConnection _dbConnection;
        static bool _isInitialized = false;


        static private SqlConnection OpenConnection()
        {
            _dbConnection.Open();
            return _dbConnection;
        }

        static private void Init()
        {
            _dbConnection = new SqlConnection();
            _dbConnection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
            _isInitialized = true;
        }


        static private void CloseConnection()
        {
            _dbConnection.Close();
        }




        /// <summary>
        /// Returns a DataTable containing the results of the query (SELECT-statement only)
        /// Remember to put brackets around table names (e.g. "SELECT * FROM [tableName]")
        /// </summary>
        /// <param name="sqlString">The SQL</param>
        /// <param name="parameterList">Pass a Dictionary of parameters to use in SQL-string. Will be added through the SqlCommand.Parameters.Add()-method</param>
        /// <param name="readOnly">The returned DataTable will be read-only or not. Default value is true</param>
        /// <returns></returns>
        public static DataTable query(string sqlString, Dictionary<string, object> parameterList=null, bool readOnly = true, bool debug = false)
        {
            if (sqlString == string.Empty) return null;

            DataTable returnTable = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (!_isInitialized) Init();
                sqlCommand = new SqlCommand(sqlString, _dbConnection);

                if (parameterList != null)         // If parameters: add them
                {
                    foreach (KeyValuePair<string,object> parameter in parameterList)                    
                        sqlCommand.Parameters.AddWithValue(parameter.Key.StartsWith("@")? parameter.Key : "@" + parameter.Key, parameter.Value);
                    
                }
                
                returnTable = new DataTable();
                OpenConnection();

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
                CloseConnection();
                if (sqlCommand != null) sqlCommand.Dispose();
            }
            return returnTable;
        }

        /// <summary>
        /// Returns the number of affected rows from the Non-Query (UPDATE-, INSERT- or DELETE-statement only)
        /// </summary>
        /// <param name="sqlString">The SQL</param>
        /// <param name="parameterList">Pass a List of SqlParameters to use in SQL-string. Will be added through the SqlCommand.Parameters.Add()-method</param>
        /// <param name="debug">Whether or not to throw exceptions from inside this method</param>
        /// <returns></returns>
        static public int nonQuery(string sqlString, Dictionary<string, object> parameterList=null, bool debug = false)
        {
            if (sqlString == "") return 0;

            int numberOfRows = 0;

            SqlCommand sqlCommand = null;

            try
            {
                if (!_isInitialized) Init();
                sqlCommand = new SqlCommand(sqlString, _dbConnection);

                if (parameterList != null)         // If parameters: add them
                {
                    foreach (KeyValuePair<string, object> parameter in parameterList)
                        sqlCommand.Parameters.AddWithValue(parameter.Key.StartsWith("@") ? parameter.Key : "@" + parameter.Key, parameter.Value);
                }
                OpenConnection();

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
                CloseConnection();
                if (sqlCommand != null) sqlCommand.Dispose();
            }
            return numberOfRows;

        }

        /// <summary>
        /// Returns a boolean true or false on whether or not the user has a given role.
        /// </summary>
        /// <param name="roleId">Role to test for</param>
        /// <param name="userId">User to test on</param>
        /// <returns></returns>
        public static bool UserHasRole(int roleId, int userId)
        {

            if (roleId < 1 || userId < 1) return false;

            var parameters = new Dictionary<string, object>
                {
                    {"@roleId", roleId},
                    {"@userId", userId}
                };

            DataTable dt = query(@"
                SELECT       Role.Role
                FROM         UserInRole 
                             INNER JOIN
                             Role ON UserInRole.inRoleID = @roleId
                             INNER JOIN
                             [User] ON UserInRole.inUserID = [User].UID AND [User].UID = @userId
                ", parameters);

            return (dt.Rows.Count >= 1);
        }




        /// <summary>
        /// Returns a boolean true or false on whether or not the user has a given permission.
        /// </summary>
        /// <param name="permissionUniqueString">Permission to test for on the form "ContentTypeUniqueString_PermissionString"</param>
        /// <param name="userId">User to test on</param>
        /// <returns></returns>
        public static bool UserHasPermission(string permissionUniqueString, int userId)
        {

            if (permissionUniqueString==String.Empty || userId < 1) return false;

            var parameters = new Dictionary<string, object>
                {
                    {"@permissionUniqueString", permissionUniqueString},
                    {"@userId", userId}
                };

            DataTable dt = query(@"
                    SELECT      COUNT(*) AS Antall
                    FROM        PermissionToRole AS pr INNER JOIN
                                Permission AS p ON pr.PermissionId = p.PermissionId INNER JOIN
                                Role AS r ON pr.RoleId = r.RoleID INNER JOIN
                                UserInRole AS ur ON r.RoleID = ur.inRoleID INNER JOIN
                                [User] AS u ON ur.inUserID = u.UID
                    WHERE       (p.PermissionUniqueString = @permissionUniqueString) AND (u.UID = @userId)
                ", parameters);

            int numberOfPermissions;
            Int32.TryParse(dt.Rows[0]["Antall"].ToString(), out numberOfPermissions); 

            return (numberOfPermissions > 0);
        }


        /// <summary>
        /// Returns a List of types T from a query returning a SINGLE column.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">SQL-string</param>
        /// <param name="parameters">Dictionary of string,object of parameters</param>
        /// <param name="debug">When false the query will not throw exceptions</param>
        /// <returns>Returns a List of types T from a query returning a SINGLE column, or null if more than one column</returns>
        public static List<T> GetSingleColumnResultAsList<T>(string sql, Dictionary<string, object> parameters = null, bool debug = false)
        {
            DataTable dt = query(sql, parameters, debug);

            if (dt==null || dt.Columns.Count > 1) return null;

            return (from DataRow row in dt.Rows select (T) row[0]).ToList(); // LINQ-ekvivalent for koden under (R#-hjelp)


            //var retList = new List<T>();

            //foreach (DataRow row in dt.Rows)
            //{
            //    retList.Add((T)row[0]);
            //}

            //return retList;
        }

        public static T GetFirstValueFromQuery<T>(string sql, Dictionary<string, object> parameters = null, bool debug = false)
        {
            DataTable dt = query(sql, parameters, debug);

            if (dt == null || dt.Rows.Count < 1 || dt.Columns.Count < 1) return default(T); // return null

            return (T)dt.Rows[0][0];
        }
    }


