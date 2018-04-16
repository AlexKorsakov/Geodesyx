using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Geodesyx;
using Oracle.ManagedDataAccess.Client;

namespace Geodesyx.Service
{
    public class SBrigade : Service1, IBrigade
    {
        public IEnumerable<Models.DTO.Brigade> SelectBrigades()
        {
            List<Models.DTO.Brigade> requests = new List<Models.DTO.Brigade>();
            using (OracleConnection connection = new OracleConnection(Service1.CONNECTION_STRING))
            {
                connection.Open();  //исправить
                OracleCommand oraCommand = new OracleCommand("SELECT b.BRIGADE_ID, b.BRIGADE_NAME, e.FIO "
                                                              + "FROM BRIGADE b JOIN EMPLOYEE e on b.BRIGADE_LEAD_ID = e.EMPLOYEE_ID ", connection);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        var temp = new Models.DTO.Brigade();
                        temp.id = oraReader.GetInt32(0);
                        temp.brigadeLead = oraReader.GetString(1);
                        temp.brigadeName = oraReader.GetString(2);
                        requests.Add(temp);
                    }
            }
            return requests;
        }

        public int SelectBrigadeID(int id)
        {
            int output = -1;
            using (OracleConnection connection = new OracleConnection(Service1.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT b.BRIGADE_ID "
                                                              + "FROM BRIGADE b WHERE b.BRIGADE_LEAD_ID = :id", connection);
                oraCommand.Parameters.Add("id", id);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                        output = oraReader.GetInt32(0);
            }
            return output;
        }
    }
}