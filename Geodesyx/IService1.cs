using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Geodesyx
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string DoWork();

    }

    [ServiceContract]
    public interface IRequest
    {
        [OperationContract]
        IEnumerable<Models.DTO.Request> SelectAll();

        [OperationContract]
        Models.DTO.Request Select(int id);

        [OperationContract]
        int Insert(int id, string name, string desc, int orderStatusChange);

        [OperationContract]
        int Update(int id = -1, string name = null, string desc = null, int orderStatusChange = -1);
    }

    [ServiceContract]
    public interface IRequestStatusChange
    {
    }

    [ServiceContract]
    public interface IAddress
    {

        [OperationContract]
        Models.DTO.Address Select(int id);

        [OperationContract]
        int Insert(int id, string name, string desc, int orderStatusChange);

        [OperationContract]
        int Update(int id = -1, string name = null, string desc = null, int orderStatusChange = -1);
    }
}
