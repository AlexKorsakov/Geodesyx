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
    public class SBrigadeEndedTasks : OracleWcfService, IBrigadeEndedTasks
    {
        public List<VBrigadeEndedTasks> SelectAll()
        {
            var list = new List<VBrigadeEndedTasks>();
            using (OracleConnection connection = new OracleConnection(OracleWcfService.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT * FROM BRIGADE_ENDED_TASKS WHERE change_date between add_months(trunc(sysdate,'mm'),-1) and last_day(add_months(trunc(sysdate,'mm'),0))", connection);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        var temp = new VBrigadeEndedTasks();
                        temp.task_id = oraReader.GetInt32(0);
                        temp.request_name = oraReader.GetString(1);
                        temp.request_description = oraReader.GetString(2);
                        temp.task_note = oraReader.GetString(3);
                        temp.change_date = oraReader.GetDateTime(4);
                        temp.brigade_id = oraReader.GetInt32(5);
                        temp.total_time = oraReader.GetInt32(6);

                        list.Add(temp);
                    }
            }
            return list;
        }

        public List<VBrigadeEndedTasks> SelectIn(List<int> task_ids)
        {
            var list = new List<VBrigadeEndedTasks>();
            string values = "";

            if (task_ids.Count > 0)
                values = "where task_id in (" + String.Join(",", task_ids.ToArray()) + ")";
            else
                return list;
            using (OracleConnection connection = new OracleConnection(OracleWcfService.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT * FROM BRIGADE_ENDED_TASKS " + values, connection);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        var temp = new VBrigadeEndedTasks();
                        temp.task_id = oraReader.GetInt32(0);
                        temp.request_name = oraReader.GetString(1);
                        temp.request_description = oraReader.GetString(2);
                        temp.task_note = oraReader.GetString(3);
                        temp.change_date = oraReader.GetDateTime(4);
                        temp.brigade_id = oraReader.GetInt32(5);
                        list.Add(temp);
                    }
            }
            return list;
        }
    }
}
