using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Geodesyx;
using Oracle.ManagedDataAccess.Client;

namespace Geodesyx.Service
{

    public class SRequestStatusChange : Service1, IRequestStatusChange
    {
        public int Insert(Models.DTO.RequestStatusChange input)
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