using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace Geodesyx.Service
{
    public class SEmployeeRole: Service1, IEmployeeRole
    {
        public Models.DTO.EmployeeRole Select(int id)
        {
            var model = new Models.DTO.EmployeeRole();
            using (OracleConnection connection = new OracleConnection(Service1.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT * FROM system.employee_role WHERE employee_role_id=:id", connection);
                oraCommand.Parameters.Add(":id", id);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        var temp = new Models.DTO.EmployeeRole();
                        temp.id = oraReader.GetInt32(0);
                        temp.name = oraReader.GetString(1);
                        model = temp;
                    }
            }
            return model;
        }

        public IEnumerable<Models.DTO.EmployeeRole> SelectAll()
        {
            var model = new List<Models.DTO.EmployeeRole>();
            using (OracleConnection connection = new OracleConnection(Service1.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT * FROM system.employee_role ", connection);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        var temp = new Models.DTO.EmployeeRole();
                        temp.id = oraReader.GetInt32(0);
                        temp.name = oraReader.GetString(1);
                        model.Add(temp);
                    }
            }
            return model;
        }
    }
}