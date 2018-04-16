using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Web.Configuration;
using System.Reflection;
using DTOlib;


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


    [ServiceContract]
    public interface IBrigade
    {
        [OperationContract]
        IEnumerable<Brigade> SelectBrigades();

        [OperationContract]
        int SelectBrigadeID(int id);
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
        List<int> SelectTasksID(int brigade);

        [OperationContract]
        int Insert(Request_Task input);
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

        [OperationContract]
        int Select(string query, IEnumerable<OracleParameter> param = null, string connectionString = null);
    }

    [ServiceContract]
    public interface IEmployee
    {
        [OperationContract]
        Employee Select(string username, string password);
    }

    [ServiceContract]
    public interface IEmployeeRole
    {
        [OperationContract]
        EmployeeRole Select(int id);

        [OperationContract]
        IEnumerable<EmployeeRole> SelectAll();
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
        IEnumerable<Task> SelectTasks(List<int> ids);

        [OperationContract]
        IEnumerable<Task> SelectNewTasks();

        [OperationContract]
        List<int> SelectTaskIDs_ByStatus(int status_id);

        [OperationContract]
        int Insert(Task input);

        [OperationContract]
        int Update(int id = -1, string note = null, int total_time = -1);
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
        [OperationContract]
        int Insert(TaskStatusChange input);

        [OperationContract]
        IEnumerable<TaskStatusChange> Select(List<int> ids);

        [OperationContract]
        IEnumerable<TaskStatusChange> SelectNewTasks();
    }
}
