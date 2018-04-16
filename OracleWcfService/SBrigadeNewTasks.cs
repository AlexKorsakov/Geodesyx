using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OracleWcfService;
using Oracle.DataAccess.Client;
using DTOlib;

namespace OracleWcfService
{
    public class SBrigadeNewTasks : OracleWcfService, IBrigadeNewTasks
    {
        public List<VBrigadeNewTasks> SelectAll()
        {
            var list = new List<VBrigadeNewTasks>();
            using (OracleConnection connection = new OracleConnection(OracleWcfService.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT * FROM BRIGADE_NEW_TASKS", connection);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        var temp = new VBrigadeNewTasks();
                        temp.request_id = oraReader.GetInt32(0);
                        temp.task_id = oraReader.GetInt32(1);
                        temp.request_name = oraReader.GetString(2);
                        temp.request_description = oraReader.GetString(3);
                        temp.service_name = oraReader.GetString(4);
                        temp.task_note = oraReader.GetString(5);
                        temp.request_status_name = oraReader.GetString(6);
                        temp.change_date = oraReader.GetDateTime(7);
                        temp.address_name = oraReader.GetString(8);
                        temp.adr_X = oraReader.GetFloat(9);
                        temp.adr_Y = oraReader.GetFloat(10);
                        temp.task_status_id = oraReader.GetInt32(11);
                        list.Add(temp);
                    }
            }
            return list;
        }

        public List<VBrigadeNewTasks> SelectIn(List<int> task_ids)
        {
            string values = "";
            var list = new List<VBrigadeNewTasks>();

            if (task_ids.Count > 0)
                values = "where task_id in (" + String.Join(",", task_ids.ToArray()) + ")";
            else
                return list;
            using (OracleConnection connection = new OracleConnection(OracleWcfService.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT * FROM BRIGADE_NEW_TASKS " + values, connection);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        var temp = new VBrigadeNewTasks();
                        temp.request_id = oraReader.GetInt32(0);
                        temp.task_id = oraReader.GetInt32(1);
                        temp.request_name = oraReader.GetString(2);
                        temp.request_description = oraReader.GetString(3);
                        temp.service_name = oraReader.GetString(4);
                        temp.task_note = oraReader.GetString(5);
                        temp.request_status_name = oraReader.GetString(6);
                        temp.change_date = oraReader.GetDateTime(7);
                        temp.address_name = oraReader.GetString(8);
                        temp.adr_X = oraReader.GetFloat(9);
                        temp.adr_Y = oraReader.GetFloat(10);
                        temp.task_status_id = oraReader.GetInt32(11);
                        list.Add(temp);
                    }
            }
            return list;
        }
    }
}