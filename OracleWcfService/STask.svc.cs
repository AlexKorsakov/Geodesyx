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

    public class STask : OracleWcfService, ITask
    {
        public IEnumerable<Task> SelectTasks(List<int> ids)
        {
            var list = new List<Task>();
            foreach (var item in ids)
            {
                int id = item;
                using (OracleConnection connection = new OracleConnection(OracleWcfService.CONNECTION_STRING))
                {
                    connection.Open();
                    OracleCommand oraCommand = new OracleCommand("SELECT tsk.TASK_ID, tsk.NOTE, tsk.ADDRESS_ID, tsk.SERVICE_ID "
                                                                  + "FROM system.task  tsk right join system.task_STATUS_CHANGE tsk_st on tsk.TASK_ID = tsk_st.TASK_ID "
                                                                  + "WHERE tsk_st.TASK_ID = :id", connection);
                    oraCommand.Parameters.Add(":id", id);
                    OracleDataReader oraReader = oraCommand.ExecuteReader();
                    if (oraReader.HasRows)
                        while (oraReader.Read())
                        {
                            var temp = new Task();
                            temp.id = oraReader.GetInt32(0);
                            temp.task_note = oraReader.GetString(1);
                            temp.address_id = oraReader.GetInt32(2);
                            temp.service_id = oraReader.GetInt32(3);
                            list.Add(temp);
                        }
                }
            }
            return list;
        }

        public IEnumerable<Task> SelectNewTasks()  //новые задачи
        {
            List<Task> requests = new List<Task>();
            using (OracleConnection connection = new OracleConnection(OracleWcfService.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT tsk.TASK_ID, tsk.NOTE, tsk.ADDRESS_ID, tsk.SERVICE_ID "
                                                              + "FROM system.task  tsk right join system.task_STATUS_CHANGE tsk_st on tsk.TASK_ID = tsk_st.TASK_ID "
                                                              + "WHERE tsk_st.TASK_STATUS_ID_ACTUAL = 1", connection);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        var temp = new Task();
                        temp.id = oraReader.GetInt32(0);
                        temp.task_note = oraReader.GetString(1);
                        temp.address_id = oraReader.GetInt32(2);
                        temp.service_id = oraReader.GetInt32(3);
                        requests.Add(temp);
                    }
            }
            return requests;
        }

        public List<int> SelectTaskIDs_ByStatus(int status_id)  //новые задачи
        {
            var ids = new List<int>();
            using (OracleConnection connection = new OracleConnection(OracleWcfService.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT tsc.TASK_ID from system.TASK_STATUS_CHANGE tsc "
                                                            + "GROUP BY TASK_ID having MAX(tsc.TASK_STATUS_ID_ACTUAL) = :id", connection);
                oraCommand.Parameters.Add("id", status_id);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                        ids.Add(oraReader.GetInt32(0));
            }
            return ids;
        }

        public int Insert(Task input)
        {
            List<OracleParameter> parameters = new List<OracleParameter>();
            parameters.Add(new OracleParameter("TASK_NOTE", input.task_note));
            parameters.Add(new OracleParameter("TOTAL_TIME", input.total_time));
            parameters.Add(new OracleParameter("address_id", input.address_id));
            parameters.Add(new OracleParameter("service_id", input.service_id));

            int res = ExecuteNonQuery("INSERT INTO system.task (TASK_ID, NOTE, TOTAL_TIME, address_id, service_id) "
                                    + " VALUES (task_seq.NEXTVAL, :TASK_NOTE, :TOTAL_TIME, :address_id, :service_id)", parameters);
            if (res == 1)
            {
                return SelectCurrentFromSequence("task_seq");
            }
            else
            {
                return -1;
            }
        }

        public int Update(int id = -1, string note = null, int total_time = -1)
        {
            int count = 0;
            using (OracleConnection connection = new OracleConnection(OracleWcfService.CONNECTION_STRING))
            {
                if (id == -1)
                    return 0;
                string query = "UPDATE system.Task SET ";
                if (note != null)
                    query += "note = :note , ";
                if (total_time > -1)
                    query += "total_time = :total_time ";
                connection.Open();
                OracleCommand oraCommand = new OracleCommand(query + " WHERE task_id=:id", connection);
                oraCommand.Parameters.Add("id", id);
                oraCommand.Parameters.Add("note", note);
                oraCommand.Parameters.Add("total_time", total_time);
                count = oraCommand.ExecuteNonQuery();
            }
            return count;
        }
    }
}