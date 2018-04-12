using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Web.Configuration;

namespace Geodesyx
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.

    /// <summary>
    /// Сервис взаимодействия с БД
    /// </summary>
    public class Service1 : IService1
    {
        public static string CONNECTION_STRING = "User Id=is_user;Password=is_user;Data Source=(DESCRIPTION=" +
                                                    "(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
                                                    "(CONNECT_DATA=(SID=XE)));";
        public static string sss = WebConfigurationManager.AppSettings[""];

        public string DoWork()
        {
            string fullName = "";
            using (OracleConnection connection = new OracleConnection(CONNECTION_STRING))
            {
                DataSet ds = new DataSet();
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT * FROM system.service ", connection);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                {
                    while (oraReader.Read())
                    {
                        fullName += oraReader.GetValue(0);
                        fullName += oraReader.GetValue(1);
                        fullName += oraReader.GetValue(2);
                        fullName += oraReader.GetValue(3);
                    }
                }
                else
                {
                    fullName = "No Rows Found";
                }
            }
            return fullName;
        }
    }

    public class Request : IRequest
    {
        public IEnumerable<Models.DTO.Request> SelectAll()
        {
            List<Models.DTO.Request> requests = new List<Models.DTO.Request>();
            using (OracleConnection connection = new OracleConnection(Service1.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT * FROM system.request ", connection);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)                
                    while (oraReader.Read())
                    {
                        var temp = new Models.DTO.Request();
                        temp.id = oraReader.GetInt32(0);
                        temp.name = oraReader.GetString(1);
                        temp.description = oraReader.GetString(2);
                        temp.requestStatusChange = oraReader.GetInt32(3);
                        requests.Add(temp);
                        /*
                        requests.Add(new Models.Request(
                                (int)oraReader.GetInt32(0), 
                                (string)oraReader.GetString(1),
                                (string)oraReader.GetString(2),
                                new Models.OrderStatusChange(oraReader.GetInt32(3))
                            )
                        );    
                        */
                    }                
            }
            return requests;
        }

        public Models.DTO.Request Select(int id)
        {
            Models.DTO.Request request = new Models.DTO.Request();
            using (OracleConnection connection = new OracleConnection(Service1.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT * FROM system.request WHERE request_id=:id", connection);
                oraCommand.Parameters.Add("id", id);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        var temp = new Models.DTO.Request();
                        temp.id = oraReader.GetInt32(0);
                        temp.name = oraReader.GetString(1);
                        temp.description = oraReader.GetString(2);
                        temp.requestStatusChange = oraReader.GetInt32(3);
                        request = temp;
                    }
            }
            return request;
        }

        public int Insert(int id, string name, string desc, int orderStatusChange)
        {
            int count = 0;
            Models.DTO.Request request = new Models.DTO.Request();
            using (OracleConnection connection = new OracleConnection(Service1.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("INSERT INTO system.request (request_id, request_name, description, request_status_change_id) "
                                                            + "VALUES (:id, :name, :desc, :orderStatusChange);", connection);
                oraCommand.Parameters.Add("id", id);
                oraCommand.Parameters.Add("name", name);
                oraCommand.Parameters.Add("desc", desc);
                oraCommand.Parameters.Add("orderStatusChange", orderStatusChange);
                count = oraCommand.ExecuteNonQuery();
            }
            return count;
        }

        public int Update(int id = -1, string name = null, string desc = null, int orderStatusChange = -1)
        {
            int count = 0;
            Models.DTO.Request request = new Models.DTO.Request();
            using (OracleConnection connection = new OracleConnection(Service1.CONNECTION_STRING))
            {
                if (id == -1)
                    return 0;
                string query = "UPDATE system.request SET request_id = :id";
                if (name != null)
                    query += ", request_name = :name";
                if (desc != null)
                    query += ", description = :desc";
                if (orderStatusChange != -1)
                    query += ", request_status_change_id = :orderStatusChange";
                connection.Open();
                OracleCommand oraCommand = new OracleCommand(query + " WHERE request_id=:id;", connection);
                oraCommand.Parameters.Add("id", id);
                oraCommand.Parameters.Add("name", name);
                oraCommand.Parameters.Add("desc", desc);
                oraCommand.Parameters.Add("orderStatusChange", orderStatusChange);
                count = oraCommand.ExecuteNonQuery();
            }
            return count;
        }
    }

    public class Address : IAddress
    {
        public Models.DTO.Address Select(int id)
        {
            var request = new Models.DTO.Address();
            using (OracleConnection connection = new OracleConnection(Service1.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT * FROM system.address WHERE address_id=:id", connection);
                oraCommand.Parameters.Add("id", id);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        request.id = oraReader.GetInt32(0);
                        request.X = oraReader.GetFloat(1);
                        request.Y = oraReader.GetFloat(2);
                        request.address_name = oraReader.GetString(3);
                    }
            }
            return request;
        }

        public int Insert(int id, string name, string desc, int orderStatusChange)
        {
            int count = 0;
            Models.DTO.Request request = new Models.DTO.Request();
            using (OracleConnection connection = new OracleConnection(Service1.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("INSERT INTO system.address (request_id, request_name, description, request_status_change_id) "
                                                            + "VALUES (:id, :name, :desc, :orderStatusChange);", connection);
                oraCommand.Parameters.Add("id", id);
                oraCommand.Parameters.Add("name", name);
                oraCommand.Parameters.Add("desc", desc);
                oraCommand.Parameters.Add("orderStatusChange", orderStatusChange);
                count = oraCommand.ExecuteNonQuery();
            }
            return count;
        }

        public int Update(int id = -1, string name = null, string desc = null, int orderStatusChange = -1)
        {
            int count = 0;
            Models.DTO.Request request = new Models.DTO.Request();
            using (OracleConnection connection = new OracleConnection(Service1.CONNECTION_STRING))
            {
                if (id == -1)
                    return 0;
                string query = "UPDATE system.request SET request_id = :id";
                if (name != null)
                    query += ", request_name = :name";
                if (desc != null)
                    query += ", description = :desc";
                if (orderStatusChange != -1)
                    query += ", request_status_change_id = :orderStatusChange";
                connection.Open();
                OracleCommand oraCommand = new OracleCommand(query + " WHERE request_id=:id;", connection);
                oraCommand.Parameters.Add("id", id);
                oraCommand.Parameters.Add("name", name);
                oraCommand.Parameters.Add("desc", desc);
                oraCommand.Parameters.Add("orderStatusChange", orderStatusChange);
                count = oraCommand.ExecuteNonQuery();
            }
            return count;
        }
    }

}
