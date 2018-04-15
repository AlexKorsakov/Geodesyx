using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Geodesyx;
using Oracle.ManagedDataAccess.Client;


namespace Geodesyx.Service
{
    public class SRequestStatus : Service1, IRequestStatus
    {
        public IEnumerable<Models.DTO.RequestStatus> SelectAll()
        {
            var requests_status = new List<Models.DTO.RequestStatus>();
            using (OracleConnection connection = new OracleConnection(Service1.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT * FROM system.request_status ", connection);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        var temp = new Models.DTO.RequestStatus();
                        temp.id = oraReader.GetInt32(0);
                        temp.requestStatusName = oraReader.GetString(1);
                        requests_status.Add(temp);
                    }
            }
            return requests_status;
        }       
    }
}