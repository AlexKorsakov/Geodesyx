using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Web.Configuration;
using System.Reflection;

namespace OracleWcfService
{
    public class OracleWcfService : IOracleWcfService
    {
        public static string CONNECTION_STRING = "User Id=system;Password=master;Data Source=(DESCRIPTION=" +
                                                    "(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
                                                    "(CONNECT_DATA=(SID=XE)));";
        public static string sss = WebConfigurationManager.AppSettings[""];
        public static string Exception = null;

        public int ExecuteNonQuery(string query, IEnumerable<OracleParameter> param = null, string connectionString = null)
        {
            if (connectionString == null)
                connectionString = CONNECTION_STRING;
            using (OracleConnection connection = new OracleConnection(connectionString))
            using (OracleCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = query;
                if (param != null)
                    foreach (OracleParameter ora in param)
                        cmd.Parameters.Add(ora);
                try
                {
                    connection.Open();
                }
                catch (OracleException) { return 0; }
                try
                {
                    cmd.ExecuteNonQuery();
                    return 1;
                }
                catch (OracleException e) { return 0; }
                finally { connection.Close(); }
            }
        }

        public int SelectCurrentFromSequence(string sequence_name, string connectionString = null)  //Текущее значение последовательности
        {
            int result = -1; ;
            if (connectionString == null)
                connectionString = CONNECTION_STRING;
            using (OracleConnection connection = new OracleConnection(connectionString))
            using (OracleCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = "SELECT " + sequence_name + ".CURRVAL FROM DUAL";
                try
                {
                    connection.Open();
                }
                catch (OracleException) { return result; }
                try
                {
                    OracleDataReader oraReader = cmd.ExecuteReader();
                    if (oraReader.HasRows)
                        while (oraReader.Read())
                        {
                            result = oraReader.GetInt32(0);
                        }
                    return result;
                }
                catch (OracleException e)
                {
                    return -1;
                }
                finally { connection.Close(); }
            }
        }

    }
}
