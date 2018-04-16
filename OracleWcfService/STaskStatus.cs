using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OracleWcfService;
using Oracle.DataAccess.Client;
using DTOlib;


namespace OracleWcfService
{
    public class STaskStatus : OracleWcfService, ITaskStatus
    {
        public IEnumerable<TaskStatus> SelectAll()
        {
            var list = new List<TaskStatus>();
            using (OracleConnection connection = new OracleConnection(OracleWcfService.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT * FROM system.task_status ", connection);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        var temp = new TaskStatus();
                        temp.id = oraReader.GetInt32(0);
                        temp.name = oraReader.GetString(1);
                        list.Add(temp);
                    }
            }
            return list;
        }
    }
}