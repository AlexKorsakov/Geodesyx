using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Geodesyx;
using Oracle.ManagedDataAccess.Client;


namespace Geodesyx.Service
{
    public class STaskStatus : Service1, ITaskStatus
    {
        public IEnumerable<Models.DTO.TaskStatus> SelectAll()
        {
            var list = new List<Models.DTO.TaskStatus>();
            using (OracleConnection connection = new OracleConnection(Service1.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT * FROM system.task_status ", connection);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        var temp = new Models.DTO.TaskStatus();
                        temp.id = oraReader.GetInt32(0);
                        temp.name = oraReader.GetString(1);
                        list.Add(temp);
                    }
            }
            return list;
        }
    }
}