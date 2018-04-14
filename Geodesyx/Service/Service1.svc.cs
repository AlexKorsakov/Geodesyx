using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Web.Configuration;
using System.Reflection;

namespace Geodesyx
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.

    /// <summary>
    /// Сервис взаимодействия с БД
    /// </summary>
    public class Service1 : IService1
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
                finally { connection.Close();  }
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







    /*
    public class Universal : IUniversal
    {
        public void Insert<T>(out int result, ref T DTO, List<object> Parameters, string table)
        {
            int count = 0;
            string query = "INSERT INTO " + table;
            try
            {
                using (OracleConnection connection = new OracleConnection(Service1.CONNECTION_STRING))
                {
                    connection.Open();
                    OracleCommand oraCommand = new OracleCommand("INSERT INTO " + table + " (request_id, request_name, description, request_status_change_id) "
                                                                + " VALUES (request_seq.NEXTVAL, :req_name, :descript, :orderStatusChange)", connection);
                    
                    //oraCommand.Parameters.Add("req_name", OracleDbType.Varchar2).Value = name;
                    //oraCommand.Parameters.Add("descript", OracleDbType.Varchar2).Value = desc;
                    //oraCommand.Parameters.Add("orderStatusChange", OracleDbType.Decimal).Value = orderStatusChange;
                    

                    count = oraCommand.ExecuteNonQuery();
                }
                result = count;
            }
            catch (OracleException ex)
            {

                result = 0;
            }
        }

        public void ExcecuteQuery(string query, IEnumerable<OracleParameter> param = null, string connectionString = null)
        {
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
                catch (OracleException) { return; }
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                }
                finally { connection.Close(); }
            }
        }
    }
    */
}
