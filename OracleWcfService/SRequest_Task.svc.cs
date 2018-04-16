using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using DTOlib;

namespace OracleWcfService
{
    public class SRequest_Task : OracleWcfService, IRequest_Task
    {
        public List<int> SelectTasksID(int brigade)
        {
            var list = new List<int>();
            using (OracleConnection connection = new OracleConnection(OracleWcfService.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT TASK_ID FROM system.REQUEST_TASK WHERE BRIGADE_ID = :id", connection);
                oraCommand.Parameters.Add("id", brigade);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                        list.Add(oraReader.GetInt32(0));
            }
            return list;
        }

        public int Insert(Request_Task input)
        {
            List<OracleParameter> parameters = new List<OracleParameter>();
            parameters.Add(new OracleParameter("task_id", input.task_id));
            parameters.Add(new OracleParameter("request_id", input.request_id));
            parameters.Add(new OracleParameter("brigade_id", input.brigade_id));

            int res = ExecuteNonQuery("INSERT INTO system.request_task (request_task_id, task_id, request_id, brigade_id) "
                                    + " VALUES (request_task_seq.NEXTVAL, :task_id, :request_id, :brigade_id)", parameters);
            if (res == 1)
                return SelectCurrentFromSequence("request_task_seq");
            else
                return -1;
        }
    }
}
