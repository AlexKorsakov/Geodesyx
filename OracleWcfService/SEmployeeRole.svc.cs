using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using DTOlib;

namespace OracleWcfService
{
    public class SEmployeeRole : OracleWcfService, IEmployeeRole
    {
        public EmployeeRole Select(int id)
        {
            var model = new EmployeeRole();
            using (OracleConnection connection = new OracleConnection(OracleWcfService.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT * FROM system.employee_role WHERE employee_role_id=:id", connection);
                oraCommand.Parameters.Add("id", id);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        var temp = new EmployeeRole();
                        temp.id = oraReader.GetInt32(0);
                        temp.name = oraReader.GetString(1);
                        model = temp;
                    }
            }
            return model;
        }

        public IEnumerable<EmployeeRole> SelectAll()
        {
            var model = new List<EmployeeRole>();
            using (OracleConnection connection = new OracleConnection(OracleWcfService.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT * FROM system.employee_role ", connection);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        var temp = new EmployeeRole();
                        temp.id = oraReader.GetInt32(0);
                        temp.name = oraReader.GetString(1);
                        model.Add(temp);
                    }
            }
            return model;
        }
    }
}