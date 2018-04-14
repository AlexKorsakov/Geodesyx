using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Geodesyx;
using Oracle.ManagedDataAccess.Client;

namespace Geodesyx.Service
{

    public class SRequest : Service1, IRequest
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
                        requests.Add(temp);
                    }
            }
            return requests;
        }       //все заявки

        public IEnumerable<Models.DTO.Request> SelectNewRequests()  //новые заявки
        {
            List<Models.DTO.Request> requests = new List<Models.DTO.Request>();
            using (OracleConnection connection = new OracleConnection(Service1.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT req.REQUEST_ID, req.REQUEST_NAME, req.DESCRIPTION FROM system.REQUEST  req "
                                                              +  "right join system.REQUEST_STATUS_CHANGE  req_st on req.request_id = req_st.REQUEST_ID " 
                                                              +  "WHERE req_st.REQUEST_STATUS_ID_ACTUAL = 1", connection);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        var temp = new Models.DTO.Request();
                        temp.id = oraReader.GetInt32(0);
                        temp.name = oraReader.GetString(1);
                        temp.description = oraReader.GetString(2);
                        requests.Add(temp);
                    }
            }
            return requests;
        }

        public Models.DTO.Request Select(int id)    //конкретная заявка
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
                        request = temp;
                    }
            }
            return request;
        }

        public int Insert(Models.DTO.Request input)  
        {
            List<OracleParameter> parameters = new List<OracleParameter>();
            parameters.Add(new OracleParameter("req_name", input.name));
            parameters.Add(new OracleParameter("descript", input.description));

            int res = ExecuteNonQuery("INSERT INTO system.request (request_id, request_name, description) "
                                    + " VALUES (request_seq.NEXTVAL, :req_name, :descript)", parameters);
            if (res == 1)
                return SelectCurrentFromSequence("request_seq");
            else
                return -1;
        }

        public int Update(int id = -1, string name = null, string desc = null)
        {
            int count = 0;
            Models.DTO.Request request = new Models.DTO.Request();
            using (OracleConnection connection = new OracleConnection(Service1.CONNECTION_STRING))
            {
                if (id == -1)
                    return 0;
                string query = "UPDATE system.request SET";
                if (name != null)
                    query += ", request_name = :name";
                if (desc != null)
                    query += ", description = :desc";
                connection.Open();
                OracleCommand oraCommand = new OracleCommand(query + " WHERE request_id=:id;", connection);
                oraCommand.Parameters.Add("id", id);
                oraCommand.Parameters.Add("name", name);
                oraCommand.Parameters.Add("desc", desc);
                count = oraCommand.ExecuteNonQuery();
            }
            return count;
        }

    }
}