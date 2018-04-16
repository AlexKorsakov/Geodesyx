using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OracleWcfService;
using Oracle.ManagedDataAccess.Client;
using DTOlib;

namespace OracleWcfService
{

    public class SRequestStatusChange : OracleWcfService, IRequestStatusChange
    {
        public int Insert(RequestStatusChange input)
        {
            List<OracleParameter> parameters = new List<OracleParameter>();
            parameters.Add(new OracleParameter("request_status_id_old", input.old_status));
            parameters.Add(new OracleParameter("request_status_id_actual", input.new_status));
            parameters.Add(new OracleParameter("request_id", input.request_id));
            parameters.Add(new OracleParameter("change_date", DateTime.Now.ToString()));

            int res = ExecuteNonQuery("INSERT INTO system.request_status_change (request_status_change_id, request_status_id_old, request_status_id_actual, request_id, change_date) "
                                         + " VALUES (request_status_change_seq.NEXTVAL, :request_status_id_old, :request_status_id_actual, :request_id, :change_date)", parameters);
            if (res == 1)
                return SelectCurrentFromSequence("request_status_change_seq");
            else
                return -1;
        }

        public IEnumerable<RequestStatusChange> Select(List<int> ids)
        {
            var requests = new List<RequestStatusChange>();
            foreach (var item in ids)
            {
                int id = item;
                using (OracleConnection connection = new OracleConnection(OracleWcfService.CONNECTION_STRING))
                {
                    connection.Open();
                    OracleCommand oraCommand = new OracleCommand("SELECT * "
                                                                  + "FROM system.REQUEST_STATUS_CHANGE WHERE REQUEST_ID = :id", connection);
                    oraCommand.Parameters.Add("id", id);
                    OracleDataReader oraReader = oraCommand.ExecuteReader();
                    if (oraReader.HasRows)
                        while (oraReader.Read())
                        {
                            var temp = new RequestStatusChange();
                            temp.id = oraReader.GetInt32(0);
                            temp.old_status = null;
                            temp.old_status = oraReader.GetValue(1) == DBNull.Value ? temp.old_status = null : (int)oraReader.GetInt32(1);
                            temp.new_status = oraReader.GetValue(2) == DBNull.Value ? temp.new_status = null : (int)oraReader.GetInt32(2);
                            temp.change_date = oraReader.GetDateTime(3);
                            temp.request_id = oraReader.GetInt32(4);
                            requests.Add(temp);
                        }
                }
            }
            return requests;
        }

        public RequestStatusChange SelectLastStatus(int id)    //конкретная заявка
        {
            var request = new RequestStatusChange();
            using (OracleConnection connection = new OracleConnection(OracleWcfService.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT req.REQUEST_ID, req_st.REQUEST_STATUS_ID_ACTUAL, req_st.REQUEST_STATUS_ID_OLD FROM system.REQUEST  req"
                                                               + " join system.REQUEST_STATUS_CHANGE  req_st on req.request_id = req_st.REQUEST_ID"
                                                               + " WHERE req.REQUEST_ID = :id AND req.REQUEST_ID IN(SELECT req_st.REQUEST_ID from system.REQUEST_STATUS_CHANGE req_st"
                                                               + " GROUP BY req_st.REQUEST_ID HAVING MAX(req_st.REQUEST_STATUS_ID_ACTUAL) = 1)", connection);
                oraCommand.Parameters.Add("id", id);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        var temp = new RequestStatusChange();
                        temp.request_id = oraReader.GetInt32(0);
                        temp.new_status = oraReader.GetValue(1) == DBNull.Value ? temp.old_status = null : (int)oraReader.GetInt32(1);
                        temp.old_status = oraReader.GetValue(2) == DBNull.Value ? temp.new_status = null : (int)oraReader.GetInt32(2);
                        request = temp;
                    }
            }
            return request;
        }

        public int Select(string query, IEnumerable<OracleParameter> param = null, string connectionString = null)
        {
            int result = -1; ;
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