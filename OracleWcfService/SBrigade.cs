using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OracleWcfService;
using Oracle.ManagedDataAccess.Client;
using DTOlib;

namespace OracleWcfService
{
    public class SBrigade : OracleWcfService, IBrigade
    {
        public IEnumerable<Brigade> SelectBrigades()
        {
            List<Brigade> requests = new List<Brigade>();
            using (OracleConnection connection = new OracleConnection(OracleWcfService.CONNECTION_STRING))
            {
                connection.Open();  //исправить
                OracleCommand oraCommand = new OracleCommand("SELECT b.BRIGADE_ID, b.BRIGADE_NAME, e.FIO "
                                                              + "FROM BRIGADE b JOIN EMPLOYEE e on b.BRIGADE_LEAD_ID = e.EMPLOYEE_ID ", connection);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        var temp = new Brigade();
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
            using (OracleConnection connection = new OracleConnection(OracleWcfService.CONNECTION_STRING))
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