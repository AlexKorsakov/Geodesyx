using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Geodesyx;
using Oracle.ManagedDataAccess.Client;

namespace Geodesyx.Service
{
    public class SService : Service1, IService
    {
        public IEnumerable<Models.DTO.Service> SelectServices()  //новые услуги
        {
            List<Models.DTO.Service> requests = new List<Models.DTO.Service>();
            using (OracleConnection connection = new OracleConnection(Service1.CONNECTION_STRING))
            {
                connection.Open();  //исправить
                OracleCommand oraCommand = new OracleCommand("SELECT * from system.service ", connection);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        var temp = new Models.DTO.Service();
                        temp.id = oraReader.GetInt32(0);
                        temp.service_name = oraReader.GetString(1);
                        temp.description = oraReader.GetString(2);
                        temp.service_cost = oraReader.GetInt32(3);
                        requests.Add(temp);
                    }
            }
            return requests;
        }

        public int Insert(Models.DTO.Service input)  
        {
            List<OracleParameter> parameters = new List<OracleParameter>();
            parameters.Add(new OracleParameter("service_name", input.service_name));
            parameters.Add(new OracleParameter("descript", input.description));
            parameters.Add(new OracleParameter("service_cost", input.service_cost));

            int res = ExecuteNonQuery("INSERT INTO system.service (service_id, service_name, description, service_cost) "
                                    + " VALUES (service_seq.NEXTVAL, :service_name, :descrip, :service_cost)", parameters);
            if (res == 1)
                return SelectCurrentFromSequence("service_seq");
            else
                return -1;
        }
    }
}