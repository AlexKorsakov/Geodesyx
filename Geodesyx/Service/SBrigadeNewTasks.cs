﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Geodesyx;
using Oracle.ManagedDataAccess.Client;

namespace Geodesyx.Service
{
    public class SBrigadeNewTasks : Service1, IBrigadeNewTasks
    {
        public List<Models.DTO.VBrigadeNewTasks> SelectAll()
        {
            var list = new List<Models.DTO.VBrigadeNewTasks>();
            using (OracleConnection connection = new OracleConnection(Service1.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT * FROM BRIGADE_NEW_TASKS", connection);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        var temp = new Models.DTO.VBrigadeNewTasks();
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

        public List<Models.DTO.VBrigadeNewTasks> SelectIn(List<int> task_ids)
        {
            string values = "";
            var list = new List<Models.DTO.VBrigadeNewTasks>();

            if (task_ids.Count > 0)
                values = "where task_id in (" + String.Join(",", task_ids.ToArray()) + ")";
            else
                return list;
            using (OracleConnection connection = new OracleConnection(Service1.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT * FROM BRIGADE_NEW_TASKS " + values, connection);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        var temp = new Models.DTO.VBrigadeNewTasks();
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