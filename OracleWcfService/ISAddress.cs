using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DTOlib;

namespace OracleWcfService
{
    [ServiceContract]
    public interface IAddress
    {
        [OperationContract]
        Address Select(int id);

        [OperationContract]
        IEnumerable<Address> SelectAddresses();

        [OperationContract]
        int Insert(Address input);

        [OperationContract]
        int Update(int id = -1, string name = null, float X = 0, float Y = 0);
    }
}
