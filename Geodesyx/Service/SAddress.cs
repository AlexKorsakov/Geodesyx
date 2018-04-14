using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Geodesyx;
using Oracle.ManagedDataAccess.Client;

namespace Geodesyx.Service
{
    public class SAddress : Service1, IAddress
    {
        public Models.DTO.Address Select(int id)
        {
            var request = new Models.DTO.Address();
            using (OracleConnection connection = new OracleConnection(Service1.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT * FROM system.address WHERE address_id=:id", connection);
                oraCommand.Parameters.Add("id", id);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        request.id = oraReader.GetInt32(0);
                        request.X = oraReader.GetFloat(1);
                        request.Y = oraReader.GetFloat(2);
                        request.address_name = oraReader.GetString(3);
                    }
            }
            return request;
        }

        public IEnumerable<Models.DTO.Address> SelectAddresses()
        {
            var adrs = new List<Models.DTO.Address>();
            using (OracleConnection connection = new OracleConnection(Service1.CONNECTION_STRING))
            {
                connection.Open();
                OracleCommand oraCommand = new OracleCommand("SELECT * FROM system.address", connection);
                OracleDataReader oraReader = oraCommand.ExecuteReader();
                if (oraReader.HasRows)
                    while (oraReader.Read())
                    {
                        var temp = new Models.DTO.Address();
                        temp.id = oraReader.GetInt32(0);
                        string s = oraReader.GetString(1);
                        temp.address_name = oraReader.GetString(1);
                        temp.X = oraReader.GetFloat(2);
                        temp.Y = oraReader.GetFloat(3);
                        adrs.Add(temp);
                    }
            }
            return adrs;
        }
              

        public int Insert(Models.DTO.Address input)
        {
            List<OracleParameter> parameters = new List<OracleParameter>();
            parameters.Add(new OracleParameter("address_name", input.address_name));
            parameters.Add(new OracleParameter("X", input.X));
            parameters.Add(new OracleParameter("Y", input.Y));

            int res = ExecuteNonQuery("INSERT INTO system.address (address_id, address_name, X, Y) "
                                    + " VALUES (ADDRESS_seq.NEXTVAL, :address_name, :X, :y)", parameters);
            if (res == 1)
                return SelectCurrentFromSequence("ADDRESS_seq");
            else
                return -1;
        }

        public int Update(int id = -1, string name = null, float X = 0, float Y = 0)
        {
            int count = 0;
            Models.DTO.Request request = new Models.DTO.Request();
            using (OracleConnection connection = new OracleConnection(Service1.CONNECTION_STRING))
            {
                if (id == -1)
                    return 0;
                string query = "UPDATE system.address SET ";
                if (name != null)
                    query += "request_name = :name";
                if (X != 0 && Y != 0)
                    query += ", X = :X, Y = :Y";
                connection.Open();
                OracleCommand oraCommand = new OracleCommand(query + " WHERE address_id=:id;", connection);
                oraCommand.Parameters.Add("id", id);
                oraCommand.Parameters.Add("name", name);
                oraCommand.Parameters.Add("X", X);
                oraCommand.Parameters.Add("Y", Y);
                count = oraCommand.ExecuteNonQuery();
            }
            return count;
        }
    }
}