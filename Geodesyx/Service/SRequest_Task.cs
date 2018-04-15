using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Geodesyx;
using Oracle.ManagedDataAccess.Client;

namespace Geodesyx.Service
{
    public class SRequest_Task : Service1, IRequest_Task
    {
        public int Insert(Models.DTO.Request_Task input)
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