using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OracleWcfService;
using Oracle.ManagedDataAccess.Client;
using DTOlib;

namespace OracleWcfService
{
    public class STaskStatusChange : OracleWcfService, ITaskStatusChange
    {

        public int Insert(TaskStatusChange input)
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

        public IEnumerable<TaskStatusChange> Select(List<int> ids)
        {
            var list = new List<TaskStatusChange>();
            foreach (var item in ids)
            {
                int id = item;
                using (OracleConnection connection = new OracleConnection(OracleWcfService.CONNECTION_STRING))
                {
                    connection.Open();
                    OracleCommand oraCommand = new OracleCommand("SELECT * "
                                                                  + "FROM system.TASK_STATUS_CHANGE WHERE TASK_ID = :id", connection);
                    oraCommand.Parameters.Add("id", id);
                    OracleDataReader oraReader = oraCommand.ExecuteReader();
                    if (oraReader.HasRows)
                        while (oraReader.Read())
                        {
                            var temp = new TaskStatusChange();
                            temp.id = oraReader.GetInt32(0);
                            temp.old_status = oraReader.GetValue(1) == DBNull.Value ? temp.old_status = null : (int)oraReader.GetInt32(1);
                            temp.new_status = oraReader.GetValue(2) == DBNull.Value ? temp.new_status = null : (int)oraReader.GetInt32(2);
                            temp.task_id = oraReader.GetInt32(3);
                            temp.change_date = oraReader.GetDateTime(4);
                            list.Add(temp);
                        }
                }
            }
            return list;
        }
        
        public IEnumerable<TaskStatusChange> SelectNewTasks()  //новые задачи
        {
            List<TaskStatusChange> requests = new List<TaskStatusChange>();
            using (OracleConnection connection = new OracleConnection(OracleWcfService.CONNECTION_STRING))
            {
                connection.Open();  
                OracleCommand oraCommand = new OracleCommand("SELECT t.TASK_ID, tsc.TASK_STATUS_ID_ACTUAL, tsc.TASK_STATUS_ID_OLD, tsc.CHANGE_DATE  "
                                                              + "FROM system.TASK  t join system.TASK_STATUS_CHANGE  tsc on t.TASK_ID = tsc.TASK_ID "
                                                              + "WHERE t.TASK_ID IN(SELECT tsc.TASK_ID from system.TASK_STATUS_CHANGE tsc "
                                                              + "GROUP BY tsc.TASK_ID HAVING MAX(tsc.TASK_STATUS_ID_ACTUAL) =1) ", connection);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        var temp = new TaskStatusChange();
                        temp.id = oraReader.GetInt32(0);
                        temp.new_status = oraReader.GetValue(1) == DBNull.Value ? temp.new_status = null : (int)oraReader.GetInt32(1);
                        temp.old_status = oraReader.GetValue(2) == DBNull.Value ? temp.old_status = null : (int)oraReader.GetInt32(2);
                        temp.change_date = oraReader.GetDateTime(3);
                        requests.Add(temp);
                    }
            }
            return requests;
        }
        
    }
}