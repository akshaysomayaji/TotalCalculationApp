

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
 

 

using System.Web;

namespace DataObjects.AdoNet
{
    /// <summary>
    /// Manages all lower level ADO.NET data base access.
    /// </summary>
    /// <remarks>
    /// 
    /// This class handles all database access details and shields its complexity from its clients.
    /// </remarks>
    public static class Db
    {
        // Note: Static initializers are thread safe.
        // If this class had a static constructor then these static variables 
        // would need to be initialized there.
        private static readonly string dataProvider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);



        /*
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        private static readonly string connectionStringName = ConfigurationManager.AppSettings.Get("ConnectionStringName");
         * */


        public static byte[] GetDocumentBinaryDataNew(Int64 actualdocumentID)
        {
            byte[] returndocbinarydata;
            string filestreamconnstring = ConfigurationManager.ConnectionStrings["FileStreamDBConnectionString"].ConnectionString;

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = filestreamconnstring;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT DocData FROM CMSDocuments WHERE DocumentActualId = " + actualdocumentID.ToString();


                    connection.Open();

                    returndocbinarydata = (byte[])command.ExecuteScalar();

                }

                return returndocbinarydata;
            }
        }

        public static byte[] GetDocumentBinaryData(Int64 actualdocumentID)
        {
            byte[] returndocbinarydata;
            string filestreamconnstring = ConfigurationManager.ConnectionStrings["FileStreamDBConnectionString"].ConnectionString;

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = filestreamconnstring;

                using (var command = factory.CreateCommand())
                {

                    command.Connection = connection;
                    command.CommandText = "SELECT DocData.PathName() AS PathName FROM CMSDocuments WHERE DocumentActualId = " + actualdocumentID.ToString();

                    connection.Open();

                    string filepath = command.ExecuteScalar().ToString();

                    DbTransaction doctransaction = connection.BeginTransaction();
                    command.Transaction = doctransaction;
                    command.CommandText = "SELECT GET_FILESTREAM_TRANSACTION_CONTEXT()";

                    byte[] documentbinarydata = (byte[])command.ExecuteScalar();

                    System.Data.SqlTypes.SqlFileStream sqlfilestream = new System.Data.SqlTypes.SqlFileStream(filepath, documentbinarydata, System.IO.FileAccess.Read);
                    returndocbinarydata = new byte[sqlfilestream.Length];

                    sqlfilestream.Read(returndocbinarydata, 0, returndocbinarydata.Length);

                    sqlfilestream.Close();
                    command.Transaction.Commit();
                    connection.Close();

                }
                return returndocbinarydata;
            }
        }

        #region Fast data readers

        /// <summary>
        /// Fast read of individual item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="make"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static T Read<T>(string sql, Func<IDataReader, T> make, object[] parms = null, CommandType commandtype = CommandType.Text)
        {
            string cnstringName = Utility.RetrieveAppNameFromUrl(System.Web.HttpContext.Current.Request.Url.Host);
#if DEBUG
            if (cnstringName.StartsWith("192"))
            {
                cnstringName = ConfigurationManager.AppSettings.Get("ConnectionStringName");
            }
#endif
            string connectionStringValue = ConfigurationManager.ConnectionStrings[cnstringName] != null ? ConfigurationManager.ConnectionStrings[cnstringName].ConnectionString : "";

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionStringValue;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.CommandType = commandtype;
                    command.SetParameters(parms);  // Extension method

                    connection.Open();

                    T t = default(T);
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                        t = make(reader);

                    return t;
                }
            }
        }

        /// <summary>
        /// Fast read of list of items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="make"></param>
        /// <param name="parms"></param>
        /// <param name="commandtype"></param>
        /// <returns></returns>
        public static List<T> ReadList<T>(string sql, Func<IDataReader, T> make, object[] parms = null, CommandType commandtype = CommandType.Text)
        {

            string cnstringName;// = System.Web.HttpContext.Current.Request.Url.Host == null ? "": Utility.RetrieveAppNameFromUrl(System.Web.HttpContext.Current.Request.Url.Host);

            //if (cnstringName.StartsWith("192"))
            //{
            cnstringName = ConfigurationManager.AppSettings.Get("ConnectionStringName");
            //}

            string connectionStringValue = ConfigurationManager.ConnectionStrings[cnstringName] != null ? ConfigurationManager.ConnectionStrings[cnstringName].ConnectionString : "";

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionStringValue;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;

                    command.CommandType = commandtype;
                    command.SetParameters(parms);

                    connection.Open();

                    var list = new List<T>();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                        list.Add(make(reader));

                    return list;
                }
            }
        }

        /// <summary>
        /// Fast read of list of items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="make"></param>
        /// <param name="parms"></param>
        /// <param name="commandtype"></param>
        /// <returns></returns>
        public static List<T> ReadListFromOthers<T>(string sql, Func<IDataReader, T> make, object[] parms = null, CommandType commandtype = CommandType.Text, string connstring = "")
        {
            string newsconnstringname = ConfigurationManager.AppSettings[connstring].ToString();


            string connectionStringValue = ConfigurationManager.ConnectionStrings[newsconnstringname] != null ? ConfigurationManager.ConnectionStrings[newsconnstringname].ConnectionString : "";

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionStringValue;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;

                    command.CommandType = commandtype;
                    command.SetParameters(parms);

                    connection.Open();

                    var list = new List<T>();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                        list.Add(make(reader));

                    return list;
                }
            }
        }


        public static DataSet ReadMultipleRecordSet(string sql, object[] parms = null, CommandType commandtype = CommandType.Text)
        {
            DataSet result = new DataSet();
            string cnstringName;// = System.Web.HttpContext.Current.Request.Url.Host == null ? "": Utility.RetrieveAppNameFromUrl(System.Web.HttpContext.Current.Request.Url.Host);

            //if (cnstringName.StartsWith("192"))
            //{
            cnstringName = ConfigurationManager.AppSettings.Get("ConnectionStringName");
            //}

            string connectionStringValue = ConfigurationManager.ConnectionStrings[cnstringName] != null ? ConfigurationManager.ConnectionStrings[cnstringName].ConnectionString : "";


            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionStringValue;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;

                    command.CommandType = commandtype;
                    command.SetParameters(parms);

                    connection.Open();

                    System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
                    da.SelectCommand = (System.Data.SqlClient.SqlCommand)command;

                    da.Fill(result);

                    return result;
                }
            }


        }

        /// <summary>
        /// Gets a record count.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static int GetCount(string sql, object[] parms = null, CommandType commandtype = CommandType.Text)
        {
            return GetScalar(sql, parms, commandtype).AsInt();
        }

        /// <summary>
        /// Gets any scalar value from the database.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static object GetScalar(string sql, object[] parms = null, CommandType commandtype = CommandType.Text)
        {
            string cnstringName = Utility.RetrieveAppNameFromUrl(System.Web.HttpContext.Current.Request.Url.Host);
#if DEBUG
            if (cnstringName.StartsWith("192"))
            {
                cnstringName = "localhost";
            }
#endif
            string connectionStringValue = ConfigurationManager.ConnectionStrings[cnstringName] != null ? ConfigurationManager.ConnectionStrings[cnstringName].ConnectionString : "";


            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionStringValue;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.CommandType = commandtype;
                    command.SetParameters(parms);

                    connection.Open();
                    return command.ExecuteScalar();
                }
            }
        }

        #endregion

        #region Data update section

        /// <summary>
        /// Inserts an item into the database
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static long Insert(string sql, object[] parms = null, CommandType commandtype = CommandType.Text)
        {
            string cnstringName = Utility.RetrieveAppNameFromUrl(System.Web.HttpContext.Current.Request.Url.Host);
#if DEBUG
            if (cnstringName.StartsWith("192"))
            {
                cnstringName = "localhost";
            }
#endif
            string connectionStringValue = ConfigurationManager.ConnectionStrings[cnstringName] != null ? ConfigurationManager.ConnectionStrings[cnstringName].ConnectionString : "";


            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionStringValue;

                using (var command = factory.CreateCommand())
                {

                    command.Connection = connection;
                    command.SetParameters(parms);                     // Extension method 
                    command.CommandType = commandtype;
                    if (commandtype == CommandType.Text)
                    {
                        command.CommandText = sql.AppendIdentitySelect(); // Extension method
                    }
                    else
                    {
                        command.CommandText = sql;

                    }

                    connection.Open();

                    return command.ExecuteScalar().AsInt64();
                }
            }
        }

        /// <summary>
        /// Updates an item in the database
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        public static void Update(string sql, object[] parms = null, CommandType commandtype = CommandType.Text)
        {
            string cnstringName;// = System.Web.HttpContext.Current.Request.Url.Host == null ? "": Utility.RetrieveAppNameFromUrl(System.Web.HttpContext.Current.Request.Url.Host);
            cnstringName = ConfigurationManager.AppSettings.Get("ConnectionStringName");

            string connectionStringValue = ConfigurationManager.ConnectionStrings[cnstringName] != null ? ConfigurationManager.ConnectionStrings[cnstringName].ConnectionString : "";

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionStringValue;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandType = commandtype;
                    command.CommandText = sql;
                    command.SetParameters(parms);


                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletes an item from the database.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        public static void Delete(string sql, object[] parms = null, CommandType commandtype = CommandType.Text)
        {
            Update(sql, parms, commandtype);
        }

        #endregion

        #region Extension methods

        /// <summary>
        /// Extension method: Appends the db specific syntax to sql string 
        /// for retrieving newly generated identity (autonumber) value.
        /// </summary>
        /// <param name="sql">The sql string to which to append syntax.</param>
        /// <returns>Sql string with identity select.</returns>
        private static string AppendIdentitySelect(this string sql)
        {
            switch (dataProvider)
            {
                // Microsoft Access does not support multistatement batch commands
                case "System.Data.OleDb": return sql;
                case "System.Data.SqlClient": return sql + ";SELECT SCOPE_IDENTITY()";
                case "System.Data.OracleClient": return sql + ";SELECT MySequence.NEXTVAL FROM DUAL";
                default: return sql + ";SELECT @@IDENTITY";
            }
        }

        /// <summary>
        /// Extention method. Adds query parameters to command object.
        /// </summary>
        /// <param name="command">Command object.</param>
        /// <param name="parms">Array of name-value query parameters.</param>
        private static void SetParameters(this DbCommand command, object[] parms)
        {
            if (parms != null && parms.Length > 0)
            {
                // NOTE: Processes a name/value pair at each iteration
                for (int i = 0; i < parms.Length; i += 2)
                {
                    string name = parms[i].ToString();

                    // No empty strings to the database
                    if (parms[i + 1] is string && (string)parms[i + 1] == "")
                        parms[i + 1] = null;

                    // If null, set to DbNull
                    object value = parms[i + 1] ?? DBNull.Value;

                    var dbParameter = command.CreateParameter();
                    dbParameter.ParameterName = name;
                    dbParameter.Value = value;

                    command.Parameters.Add(dbParameter);
                }
            }
        }

        #endregion

        public static DataSet ReadMultipleRecordSet1(string sql, object[] parms = null, CommandType commandtype = CommandType.Text)
        {
            DataSet result = new DataSet();
            string cnstringName;// = System.Web.HttpContext.Current.Request.Url.Host == null ? "": Utility.RetrieveAppNameFromUrl(System.Web.HttpContext.Current.Request.Url.Host);
#if DEBUG
            //if (cnstringName.StartsWith("192"))
            //{
            cnstringName = ConfigurationManager.AppSettings.Get("ConnectionStringName");
            //}
#endif
            string connectionStringValue = ConfigurationManager.ConnectionStrings["localhost"] != null ? ConfigurationManager.ConnectionStrings["localhost"].ConnectionString : "";


            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionStringValue;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;

                    command.CommandType = commandtype;
                    command.SetParameters(parms);

                    connection.Open();

                    System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
                    da.SelectCommand = (System.Data.SqlClient.SqlCommand)command;

                    da.Fill(result);

                    return result;
                }
            }


        }
    }
}
 