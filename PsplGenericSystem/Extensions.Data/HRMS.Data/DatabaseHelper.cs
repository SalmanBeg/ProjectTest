using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.IO;
using System.Xml;
using System.Web.Security;
using System.Reflection;
namespace HRMS.Data
{
    public class DatabaseHelper : IDisposable
    {

        #region Class Level variables

        private string strConnectionString;
        private DbConnection objConnection;
        private DbCommand objCommand;
        private DbProviderFactory objFactory = null;
        private bool boolHandleErrors;
        private string strLastError;
        private bool boolLogError;
        private string strLogFile;
        private string ConnectionStringHnalder;
        private Dictionary<string, object> pOutputValues = new Dictionary<string, object>();


        private List<SqlParameter> pParameters = new List<SqlParameter>();
       // private SqlConnection pConn;
        public enum QueryType { QueryString, StoredProc }
        #endregion

        #region Constants

        #endregion

        #region Constructors/Destructors

        public DatabaseHelper(string connectionstring, Providers provider)
        {
            strConnectionString = connectionstring;
            switch (provider)
            {
                case Providers.SqlServer:
                    objFactory = SqlClientFactory.Instance;
                    break;
                case Providers.OleDb:
                    objFactory = OleDbFactory.Instance;
                    break;
                case Providers.ODBC:
                    objFactory = OdbcFactory.Instance;
                    break;
                case Providers.ConfigDefined:
                    string providername = "";
                    if (connectionstring == "")
                    {
                        if (!string.IsNullOrEmpty(ConnectionStringHnalder))
                            connectionstring = ConnectionStringHnalder;
                        else
                        {
                            //Get connection information
                            GetConnectionInfoFromConfig(ref strConnectionString, ref providername);
                            ConnectionStringHnalder = strConnectionString;
                        }
                    }
                    else
                    {
                        ConnectionStringHnalder = connectionstring;
                        providername = ConfigurationManager.ConnectionStrings["HRMSConnection"].ProviderName;
                    }
                    switch (providername)
                    {
                        case "System.Data.SqlClient":
                            objFactory = SqlClientFactory.Instance;
                            break;
                        case "System.Data.OleDb":
                            objFactory = OleDbFactory.Instance;
                            break;
                        case "System.Data.Odbc":
                            objFactory = OdbcFactory.Instance;
                            break;
                    }
                    break;

            }
            objConnection = objFactory.CreateConnection();
            objCommand = objFactory.CreateCommand();

            objConnection.ConnectionString = strConnectionString;
            objCommand.Connection = objConnection;

        }

        public DatabaseHelper(string connectionstring)
            : this(connectionstring, Providers.ConfigDefined)
        {
        }

        public DatabaseHelper()
            : this("", Providers.ConfigDefined)
        {
        }

        #endregion

        #region Properties

        public bool HandleErrors
        {
            get
            {
                return boolHandleErrors;
            }
            set
            {
                boolHandleErrors = value;
            }
        }

        public string LastError
        {
            get
            {
                return strLastError;
            }
        }

        public bool LogErrors
        {
            get
            {
                return boolLogError;
            }
            set
            {
                boolLogError = value;
            }
        }

        public string LogFile
        {
            get
            {
                return strLogFile;
            }
            set
            {
                strLogFile = value;
            }
        }

        #endregion

        #region Methods (Public)

        public int AddParameter(string name, object value)
        {
            DbParameter p = objFactory.CreateParameter();
            p.ParameterName = name;
            p.Value = value;
            return objCommand.Parameters.Add(p);
        }

        public void ClearParameters()
        {
            objCommand.Parameters.Clear();
        }

        public int AddParameter(string name, object value, System.Data.ParameterDirection parameterDirection)
        {
            DbParameter p = objFactory.CreateParameter();
            p.ParameterName = name;
            p.Value = value;
            p.Direction = parameterDirection;
            return objCommand.Parameters.Add(p);
        }

        public int AddParameter(DbParameter parameter)
        {
            return objCommand.Parameters.Add(parameter);
        }

        //Saves output parameter values for future use.
        private void SaveOutputValues()
        {
            pOutputValues.Clear();
            foreach (DbParameter param in objCommand.Parameters)
            {
                if (param.Direction == ParameterDirection.Output)
                {
                    pOutputValues[param.ParameterName.Trim().ToLower()] = param.Value;
                }
            }
        }

        /// <summary>
        /// Returns the value of a specified parameter in the parameter collection.
        /// </summary>
        /// <param name="paramName">The name of the parameter whose value should be returned.</param>
        /// <returns>An Object containing the value of the specified parameter.</returns>
        public object GetParameterValue(string paramName)
        {
            paramName = paramName.Trim();

            if (!paramName.StartsWith("@"))
            {
                paramName = "@" + paramName;
            }

            return pOutputValues[paramName.Trim().ToLower()];
        }

        public DbCommand Command
        {
            get
            {
                return objCommand;
            }
        }

        public void BeginTransaction()
        {
            if (objConnection.State == System.Data.ConnectionState.Closed)
            {
                objConnection.Open();
            }
            objCommand.Transaction = objConnection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            objCommand.Transaction.Commit();
            objConnection.Close();
        }

        public void RollbackTransaction()
        {
            objCommand.Transaction.Rollback();
            objConnection.Close();
        }

        public int ExecuteNonQuery(string spName, ref bool executionSucceeded)
        {
            return ExecuteNonQuery(spName, CommandType.StoredProcedure, ConnectionState1.CloseOnExit, ref executionSucceeded);
        }

        public int ExecuteNonQuery(string query, CommandType commandtype, ref bool executionSucceeded)
        {
            return ExecuteNonQuery(query, commandtype, ConnectionState1.CloseOnExit, ref executionSucceeded);
        }

        public int ExecuteNonQuery(string query, CommandType commandtype, ConnectionState1 ConnectionState, ref bool executionSucceeded)
        {
            objCommand.CommandText = query;
            objCommand.CommandType = commandtype;

            int i = -1;
            try
            {
                if (objConnection.State == System.Data.ConnectionState.Closed)
                {
                    objConnection.Open();
                }
                i = objCommand.ExecuteNonQuery();
                executionSucceeded = true;
            }
            catch (Exception ex)
            {
                executionSucceeded = false;
                HandleExceptions(ex);
            }
            finally
            {
                //objCommand.Parameters.Clear();
                if (ConnectionState == ConnectionState1.CloseOnExit)
                {
                    objConnection.Close();
                }
                SaveOutputValues();
            }

            return i;
        }

        public object ExecuteScalar(string spName, ref bool executionSucceeded)
        {
            return ExecuteScalar(spName, CommandType.StoredProcedure, ConnectionState1.CloseOnExit, ref executionSucceeded);
        }
        public object Transaction_ExecuteScalar(string spName, ref bool executionSucceeded)
        {
            return Transaction_ExecuteScalar(spName, CommandType.StoredProcedure, ConnectionState1.CloseOnExit, ref executionSucceeded);
        }

        public object ExecuteScalar(string query, CommandType commandtype, ref bool executionSucceeded)
        {
            return ExecuteScalar(query, commandtype, ConnectionState1.CloseOnExit, ref executionSucceeded);
        }

        public object ExecuteScalar(string query, CommandType commandtype, ConnectionState1 ConnectionState1, ref bool executionSucceeded)
        {
            objCommand.CommandText = query;
            objCommand.CommandType = commandtype;
            object o = null;
            try
            {
                if (objConnection.State == System.Data.ConnectionState.Closed)
                {
                    objConnection.Open();
                }
                o = objCommand.ExecuteScalar();
                executionSucceeded = true;
            }
            catch (Exception ex)
            {
                executionSucceeded = false;
                HandleExceptions(ex);
            }
            finally
            {
                //objCommand.Parameters.Clear();
                if (ConnectionState1 == ConnectionState1.CloseOnExit)
                {
                    objConnection.Close();
                }
                SaveOutputValues();
            }

            return o;
        }

        public object Transaction_ExecuteScalar(string query, CommandType commandtype, ConnectionState1 ConnectionState1, ref bool executionSucceeded)
        {
            objCommand.CommandText = query;
            objCommand.CommandType = commandtype;
            object o = null;
            try
            {
                if (objConnection.State == System.Data.ConnectionState.Closed)
                {
                    objConnection.Open();
                }
                o = objCommand.ExecuteScalar();
                executionSucceeded = true;
            }
            catch (Exception ex)
            {
                executionSucceeded = false;
                HandleExceptions(ex);
            }
            finally
            {
                //objCommand.Parameters.Clear();
                //if (ConnectionState1 == ConnectionState1.CloseOnExit)
                //{
                //    objConnection.Close();
                //}
                SaveOutputValues();
            }

            return o;
        }

        public DbDataReader ExecuteReader(string spName, ref bool executionSucceeded)
        {
            return ExecuteReader(spName, CommandType.StoredProcedure, ConnectionState1.CloseOnExit, ref executionSucceeded);
        }

        public DbDataReader ExecuteReader(string query, CommandType commandtype, ref bool executionSucceeded)
        {
            return ExecuteReader(query, commandtype, ConnectionState1.CloseOnExit, ref executionSucceeded);
        }

        public DbDataReader ExecuteReader(string query, CommandType commandtype, ConnectionState1 ConnectionState1, ref bool executionSucceeded)
        {
            objCommand.CommandText = query;
            objCommand.CommandType = commandtype;
            DbDataReader reader = null;
            try
            {
                if (objConnection.State == System.Data.ConnectionState.Closed)
                {
                    objConnection.Open();
                }
                if (ConnectionState1 == ConnectionState1.CloseOnExit)
                {
                    reader = objCommand.ExecuteReader(CommandBehavior.CloseConnection);
                }
                else
                {
                    reader = objCommand.ExecuteReader();
                }
                executionSucceeded = true;
                SaveOutputValues();
            }
            catch (Exception ex)
            {
                executionSucceeded = false;
                HandleExceptions(ex);
            }
            finally
            {
                //objCommand.Parameters.Clear();
            }

            return reader;
        }

        public IDataReader GetRelation(string parent, string child, string weak, string parentid, string parentIDinChildTable, string ChildTableID, string ChildTableIDinWeekTable)
        {
            IDataReader dr = null;
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();

            oDatabaseHelper.AddParameter("@parent", parent);
            oDatabaseHelper.AddParameter("@child", child);
            oDatabaseHelper.AddParameter("@weak", weak);

            oDatabaseHelper.AddParameter("@parentID", parentid);
            oDatabaseHelper.AddParameter("@parentIDinChildTable", parentIDinChildTable);

            oDatabaseHelper.AddParameter("@weakParentID", ChildTableID);
            oDatabaseHelper.AddParameter("@weakchildID", ChildTableIDinWeekTable);

            bool status = false;
            dr = oDatabaseHelper.ExecuteReader("sp_GetRelation", ref status);
            return dr;
        }




        public DataSet ExecuteDataSet(string spName, ref bool executionSucceeded)
        {
            return ExecuteDataSet(spName, CommandType.StoredProcedure, ConnectionState1.CloseOnExit, ref executionSucceeded);
        }

        public DataSet ExecuteDataSet(string query, CommandType commandtype, ref bool executionSucceeded)
        {
            return ExecuteDataSet(query, commandtype, ConnectionState1.CloseOnExit, ref executionSucceeded);
        }

        public DataSet ExecuteDataSet(string query, CommandType commandtype, ConnectionState1 ConnectionState1, ref bool executionSucceeded)
        {
            DbDataAdapter adapter = objFactory.CreateDataAdapter();
            objCommand.CommandText = query;
            objCommand.CommandType = commandtype;
            adapter.SelectCommand = objCommand;
            DataSet ds = new DataSet();
            try
            {
                adapter.Fill(ds);
                executionSucceeded = true;
                SaveOutputValues();
            }
            catch (Exception ex)
            {
                executionSucceeded = false;
                HandleExceptions(ex);
            }
            finally
            {
                //objCommand.Parameters.Clear();
                if (ConnectionState1 == ConnectionState1.CloseOnExit)
                {
                    if (objConnection.State == System.Data.ConnectionState.Open)
                    {
                        objConnection.Close();
                    }
                }
            }
            return ds;
        }
        public int Transaction_ExecuteNonQuery(string spName, ref bool executionSucceeded)
        {
            return Transaction_ExecuteNonQuery(spName, CommandType.StoredProcedure, ConnectionState1.CloseOnExit, ref executionSucceeded);
        }
        public int Transaction_ExecuteNonQuery(string query, CommandType commandtype, ref bool executionSucceeded)
        {
            return Transaction_ExecuteNonQuery(query, commandtype, ConnectionState1.CloseOnExit, ref executionSucceeded);
        }
        public int Transaction_ExecuteNonQuery(string query, CommandType commandtype, ConnectionState1 ConnectionState, ref bool executionSucceeded)
        {
            objCommand.CommandText = query;
            objCommand.CommandType = commandtype;

            int i = -1;
            try
            {
                if (objConnection.State == System.Data.ConnectionState.Closed)
                {
                    objConnection.Open();
                }
                i = objCommand.ExecuteNonQuery();
                executionSucceeded = true;
            }
            catch (Exception ex)
            {
                executionSucceeded = false;
                HandleExceptions(ex);
            }
            finally
            {

                SaveOutputValues();
            }

            return i;
        }
        public DbDataReader Transaction_ExecuteReader(string spName, ref bool executionSucceeded)
        {
            return ExecuteReader(spName, CommandType.StoredProcedure, ConnectionState1.KeepOpen, ref executionSucceeded);
        }

        public DbDataReader Transaction_ExecuteReader(string query, CommandType commandtype, ref bool executionSucceeded)
        {
            return ExecuteReader(query, commandtype, ConnectionState1.KeepOpen, ref executionSucceeded);
        }
        public DbDataReader Transaction_ExecuteReader(string query, CommandType commandtype, ConnectionState1 ConnectionState1, ref bool executionSucceeded)
        {
            objCommand.CommandText = query;
            objCommand.CommandType = commandtype;
            DbDataReader reader = null;
            try
            {
                if (objConnection.State == System.Data.ConnectionState.Closed)
                {
                    objConnection.Open();
                }
                if (ConnectionState1 == ConnectionState1.CloseOnExit)
                {
                    reader = objCommand.ExecuteReader(CommandBehavior.CloseConnection);
                }
                else
                {
                    reader = objCommand.ExecuteReader();
                }
                executionSucceeded = true;
                SaveOutputValues();
            }
            catch (Exception ex)
            {
                executionSucceeded = false;
                HandleExceptions(ex);
            }
            finally
            {

            }

            return reader;
        }
        public void Dispose()
        {
            objConnection.Close();
            objConnection.Dispose();
            objCommand.Dispose();
        }

        #endregion



        #region Methods (Private)

        private void GetConnectionInfoFromConfig(ref string strConnectionString, ref string providername)
        {

            strConnectionString = ConfigurationManager.ConnectionStrings["HRMSConnection"].ConnectionString;
            providername = "System.Data.SqlClient";

        }

        private void HandleExceptions(Exception ex)
        {
            if (LogErrors)
            {
                WriteToLog(ex.Message);
            }
            if (HandleErrors)
            {
                strLastError = ex.Message;
            }
            else
            {
                throw ex;
            }
        }

        private void WriteToLog(string msg)
        {
            StreamWriter writer = File.AppendText(LogFile);
            writer.WriteLine(DateTime.Now.ToString() + " - " + msg);
            writer.Close();
        }

        private static void AssignParameterValues(DbParameter[] commandParameters, object[] parameterValues)
        {
            if ((commandParameters == null) || (parameterValues == null))
            {
                // Do nothing if we get no data
                return;
            }

            // We must have the same number of values as we pave parameters to put them in
            if (commandParameters.Length != parameterValues.Length)
            {
                throw new ArgumentException("Parameter count does not match Parameter Value count.");
            }

            // Iterate through the SqlParameters, assigning the values from the corresponding position in the 
            // value array
            for (int i = 0, j = commandParameters.Length; i < j; i++)
            {
                // If the current array value derives from IDbDataParameter, then assign its Value property
                if (parameterValues[i] is IDbDataParameter)
                {
                    IDbDataParameter paramInstance = (IDbDataParameter)parameterValues[i];
                    if (paramInstance.Value == null)
                    {
                        commandParameters[i].Value = DBNull.Value;
                    }
                    else
                    {
                        commandParameters[i].Value = paramInstance.Value;
                    }
                }
                else if (parameterValues[i] == null)
                {
                    commandParameters[i].Value = DBNull.Value;
                }
                else
                {
                    commandParameters[i].Value = parameterValues[i];
                }
            }
        }

        #endregion
    }

    public enum Providers
    {
        SqlServer, OleDb, ODBC, ConfigDefined
    }

    public enum ConnectionState1
    {
        KeepOpen, CloseOnExit
    }
    public enum Gender
    {
        Select,
        Female,
        Male
    }
}
