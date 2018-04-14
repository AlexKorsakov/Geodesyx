using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;

namespace Geodesyx
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        int ExecuteNonQuery(string query, IEnumerable<Oracle.ManagedDataAccess.Client.OracleParameter> param = null, string connectionString = null);
        [OperationContract]
        int SelectCurrentFromSequence(string sequence_name, string connectionString = null);
        //[OperationContract]
        //int Select(string query, IEnumerable<Oracle.ManagedDataAccess.Client.OracleParameter> param = null, string connectionString = null);
    }

    [ServiceContract]
    public interface IAddress
    {
        [OperationContract]
        Models.DTO.Address Select(int id);

        [OperationContract]
        int Insert(Models.DTO.Address input);

        [OperationContract]
        int Update(int id = -1, string name = null, float X = 0, float Y = 0);
    }

    [ServiceContract]
    public interface IBrigade
    {
        [OperationContract]
        IEnumerable<Models.DTO.Brigade> SelectBrigades();
    }

    [ServiceContract]
    public interface IRequest
    {
        [OperationContract]
        IEnumerable<Models.DTO.Request> SelectAll();

        [OperationContract]
        IEnumerable<Models.DTO.Request> SelectNewRequests();

        [OperationContract]
        Models.DTO.Request Select(int id);

        [OperationContract]
        int Insert(Models.DTO.Request input);

        [OperationContract]
        int Update(int id = -1, string name = null, string desc = null);
    }

    [ServiceContract]
    public interface IRequestStatusChange
    {
        [OperationContract]
        int Insert(Models.DTO.RequestStatusChange input);
        [OperationContract]
        int Select(string query, IEnumerable<Oracle.ManagedDataAccess.Client.OracleParameter> param = null, string connectionString = null);
    }

    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        IEnumerable<Models.DTO.Service> SelectServices();

        [OperationContract]
        int Insert(Models.DTO.Service input);
    }

    [ServiceContract]
    public interface ITask
    {
        [OperationContract]
        IEnumerable<Models.DTO.Task> SelectNewTasks();

        [OperationContract]
        int Insert(Models.DTO.Task input);
    }

    [ServiceContract]
    public interface ITaskStatusChange
    {
        /*
        [OperationContract]
        IEnumerable<Models.DTO.TaskStatusChange> SelectNewServices();
        */
        [OperationContract]
        int Insert(Models.DTO.TaskStatusChange input);
    }
    /*
    [ServiceContract]
    public interface IUniversal
    {
        [OperationContract]
        void Insert<T> (out int result, ref T DTO, List<object> Parameters, string query);

        void ExcecuteQuery(string query, IEnumerable<Oracle.ManagedDataAccess.Client.OracleParameter> param = null, string connectionString = null);

    }
    */
}
