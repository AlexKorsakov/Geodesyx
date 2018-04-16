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
    public class SEmployee : OracleWcfService, IEmployee
    {
        public Employee Select(string username, string password)
        {
            var model = new Employee();
            using (OracleConnection connection = new OracleConnection(OracleWcfService.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT * FROM system.employee WHERE login=:login and pass=:pass", connection);
                oraCommand.Parameters.Add("login", username);
                oraCommand.Parameters.Add("pass", password);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        var temp = new Employee();
                        temp.id = oraReader.GetInt32(0);
                        temp.fio = oraReader.GetString(1);
                        temp.login = oraReader.GetString(2);
                        temp.pass = oraReader.GetString(3);
                        temp.employeeRole_id = oraReader.GetInt32(4);
                        model = temp;
                    }
            }
            return model;
        }
    }
}