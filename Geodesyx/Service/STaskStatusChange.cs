using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Geodesyx;
using Oracle.ManagedDataAccess.Client;

namespace Geodesyx.Service
{
    public class STaskStatusChange : Service1, ITaskStatusChange
    {

        public int Insert(Models.DTO.TaskStatusChange input)
        {
            List<OracleParameter> parameters = new List<OracleParameter>();
            parameters.Add(new OracleParameter("task_status_id_old", input.old_status));
            parameters.Add(new OracleParameter("task_status_id_actual", input.new_status));
            parameters.Add(new OracleParameter("task_id", input.task_id));
            parameters.Add(new OracleParameter("change_date", DateTime.Now.ToString()));

            int res = ExecuteNonQuery("INSERT INTO system.task_status_change (task_status_change_id, task_status_id_old, task_status_id_actual, task_id, change_date) "
                                    + " VALUES (task_status_change_seq.NEXTVAL, :task_status_id_old, :task_status_id_actual, :task_id, :change_date)", parameters);
            if (res == 1)
                return SelectCurrentFromSequence("task_status_change_seq");
            else
                return -1;
        }

        /*
        public IEnumerable<Models.DTO.TaskStatusChange> SelectNewServices()  //новые задачи
        {
            List<Models.DTO.TaskStatusChange> requests = new List<Models.DTO.TaskStatusChange>();
            using (OracleConnection connection = new OracleConnection(Service1.CONNECTION_STRING))
            {
                connection.Open();  
                OracleCommand oraCommand = new OracleCommand("SELECT req.REQUEST_ID, req.REQUEST_NAME, req.DESCRIPTION FROM system.REQUEST  req "
                                                              + "right join system.REQUEST_STATUS_CHANGE  req_st on req.request_id = req_st.REQUEST_ID "
                                                              + "WHERE req_st.REQUEST_STATUS_ID_ACTUAL = 1", connection);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        var temp = new Models.DTO.TaskStatusChange();
                        temp.id = oraReader.GetInt32(0);
                        temp.task_note = oraReader.GetString(1);
                        temp.address_id = oraReader.GetInt32(2);
                        temp.service_id = oraReader.GetInt32(3);
                        requests.Add(temp);
                    }
            }
            return requests;
        }
        */
    }
}