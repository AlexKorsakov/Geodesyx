using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OracleWcfService;
using Oracle.ManagedDataAccess.Client;
using DTOlib;


namespace OracleWcfService
{
    public class SRequestStatus : OracleWcfService, IRequestStatus
    {
        public IEnumerable<RequestStatus> SelectAll()
        {
            var requests_status = new List<RequestStatus>();
            using (OracleConnection connection = new OracleConnection(OracleWcfService.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT * FROM system.request_status ", connection);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        var temp = new RequestStatus();
                        temp.id = oraReader.GetInt32(0);
                        temp.requestStatusName = oraReader.GetString(1);
                        requests_status.Add(temp);
                    }
            }
            return requests_status;
        }       
    }
}