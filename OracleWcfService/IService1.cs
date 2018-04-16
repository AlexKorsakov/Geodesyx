using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using System.Web.Configuration;
using System.Reflection;
using DTOlib;


namespace OracleWcfService
{
    [ServiceContract]
    public interface IAddress
    {
        [OperationContract]
        Address Select(int id);

        [OperationContract]
        int Insert(Address input);

        [OperationContract]
        int Update(int id = -1, string name = null, float X = 0, float Y = 0);
    }

    [ServiceContract]
    public interface IBrigade
    {
        [OperationContract]
        IEnumerable<Brigade> SelectBrigades();
    }
    
    [ServiceContract]
    public interface IBrigadeEndedTasks
    {
        [OperationContract]
        List<VBrigadeEndedTasks> SelectAll();
        [OperationContract]
        List<VBrigadeEndedTasks> SelectIn(List<int> task_ids);

    }

    [ServiceContract]
    public interface IBrigadeInWorkTasks
    {
        [OperationContract]
        List<VBrigadeInWorkTasks> SelectAll();
        [OperationContract]
        List<VBrigadeInWorkTasks> SelectIn(List<int> task_ids);

    }

    [ServiceContract]
    public interface IBrigadeNewTasks
    {
        [OperationContract]
        List<VBrigadeNewTasks> SelectAll();
        [OperationContract]
        List<VBrigadeNewTasks> SelectIn(List<int> task_ids);
    }

    [ServiceContract]
    public interface IRequest
    {
        [OperationContract]
        IEnumerable<Request> SelectAll();

        [OperationContract]
        IEnumerable<Request> SelectNewRequests();

        [OperationContract]
        Request Select(int id);

        [OperationContract]
        int Insert(Request input);

        [OperationContract]
        int Update(int id = -1, string name = null, string desc = null);
    }

    [ServiceContract]
    public interface IRequest_Task
    {
        [OperationContract]
        int Insert(Request_Task input);

        [OperationContract]
        List<int> SelectTasksID(int brigade);
    }

    [ServiceContract]
    public interface IRequestStatus
    {
        [OperationContract]
        IEnumerable<RequestStatus> SelectAll();
    }


    [ServiceContract]
    public interface IRequestStatusChange
    {
        [OperationContract]
        int Insert(RequestStatusChange input);
        [OperationContract]
        IEnumerable<RequestStatusChange> Select(List<int> ids);
        [OperationContract]
        RequestStatusChange SelectLastStatus(int id);
    }

    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        IEnumerable<Service> SelectServices();

        [OperationContract]
        int Insert(Service input);
    }

    [ServiceContract]
    public interface ITask
    {
        [OperationContract]
        IEnumerable<Task> SelectNewTasks();

        [OperationContract]
        int Insert(Task input);
    }

    [ServiceContract]
    public interface ITaskStatus
    {
        [OperationContract]
        IEnumerable<TaskStatus> SelectAll();
    }

    [ServiceContract]
    public interface ITaskStatusChange
    {
        /*
        [OperationContract]
        IEnumerable<TaskStatusChange> SelectNewServices();
        */
        [OperationContract]
        int Insert(TaskStatusChange input);

        [OperationContract]
        IEnumerable<TaskStatusChange> Select(List<int> ids);
    }
    /*
    [ServiceContract]
    public interface IUniversal
    {
        [OperationContract]
        void Insert<T> (out int result, ref T DTO, List<object> Parameters, string query);

        void ExcecuteQuery(string query, IEnumerable<Oracle.DataAccess.Client.OracleParameter> param = null, string connectionString = null);

    }
    */
}
