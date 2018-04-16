using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;
using System.Web.Configuration;
using System.Reflection;

namespace OracleWcfService
{
    [ServiceContract]
    public interface IOracleWcfService
    {
        [OperationContract]
        int ExecuteNonQuery(string query, IEnumerable<OracleParameter> param = null, string connectionString = null);

        [OperationContract]
        int SelectCurrentFromSequence(string sequence_name, string connectionString = null);
    }
}
