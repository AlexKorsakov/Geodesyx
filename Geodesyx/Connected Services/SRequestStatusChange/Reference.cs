﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Geodesyx.SRequestStatusChange {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SRequestStatusChange.IOracleWcfService")]
    public interface IOracleWcfService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOracleWcfService/ExecuteNonQuery", ReplyAction="http://tempuri.org/IOracleWcfService/ExecuteNonQueryResponse")]
        int ExecuteNonQuery(string query, System.Collections.Generic.List<Oracle.ManagedDataAccess.Client.OracleParameter> param, string connectionString);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOracleWcfService/ExecuteNonQuery", ReplyAction="http://tempuri.org/IOracleWcfService/ExecuteNonQueryResponse")]
        System.Threading.Tasks.Task<int> ExecuteNonQueryAsync(string query, System.Collections.Generic.List<Oracle.ManagedDataAccess.Client.OracleParameter> param, string connectionString);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOracleWcfService/SelectCurrentFromSequence", ReplyAction="http://tempuri.org/IOracleWcfService/SelectCurrentFromSequenceResponse")]
        int SelectCurrentFromSequence(string sequence_name, string connectionString);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOracleWcfService/SelectCurrentFromSequence", ReplyAction="http://tempuri.org/IOracleWcfService/SelectCurrentFromSequenceResponse")]
        System.Threading.Tasks.Task<int> SelectCurrentFromSequenceAsync(string sequence_name, string connectionString);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOracleWcfServiceChannel : Geodesyx.SRequestStatusChange.IOracleWcfService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OracleWcfServiceClient : System.ServiceModel.ClientBase<Geodesyx.SRequestStatusChange.IOracleWcfService>, Geodesyx.SRequestStatusChange.IOracleWcfService {
        
        public OracleWcfServiceClient() {
        }
        
        public OracleWcfServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OracleWcfServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OracleWcfServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OracleWcfServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int ExecuteNonQuery(string query, System.Collections.Generic.List<Oracle.ManagedDataAccess.Client.OracleParameter> param, string connectionString) {
            return base.Channel.ExecuteNonQuery(query, param, connectionString);
        }
        
        public System.Threading.Tasks.Task<int> ExecuteNonQueryAsync(string query, System.Collections.Generic.List<Oracle.ManagedDataAccess.Client.OracleParameter> param, string connectionString) {
            return base.Channel.ExecuteNonQueryAsync(query, param, connectionString);
        }
        
        public int SelectCurrentFromSequence(string sequence_name, string connectionString) {
            return base.Channel.SelectCurrentFromSequence(sequence_name, connectionString);
        }
        
        public System.Threading.Tasks.Task<int> SelectCurrentFromSequenceAsync(string sequence_name, string connectionString) {
            return base.Channel.SelectCurrentFromSequenceAsync(sequence_name, connectionString);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SRequestStatusChange.IRequestStatusChange")]
    public interface IRequestStatusChange {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRequestStatusChange/Insert", ReplyAction="http://tempuri.org/IRequestStatusChange/InsertResponse")]
        int Insert(DTOlib.RequestStatusChange input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRequestStatusChange/Insert", ReplyAction="http://tempuri.org/IRequestStatusChange/InsertResponse")]
        System.Threading.Tasks.Task<int> InsertAsync(DTOlib.RequestStatusChange input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRequestStatusChange/Select", ReplyAction="http://tempuri.org/IRequestStatusChange/SelectResponse")]
        System.Collections.Generic.List<DTOlib.RequestStatusChange> Select(System.Collections.Generic.List<int> ids);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRequestStatusChange/Select", ReplyAction="http://tempuri.org/IRequestStatusChange/SelectResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DTOlib.RequestStatusChange>> SelectAsync(System.Collections.Generic.List<int> ids);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRequestStatusChange/SelectLastStatus", ReplyAction="http://tempuri.org/IRequestStatusChange/SelectLastStatusResponse")]
        DTOlib.RequestStatusChange SelectLastStatus(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRequestStatusChange/SelectLastStatus", ReplyAction="http://tempuri.org/IRequestStatusChange/SelectLastStatusResponse")]
        System.Threading.Tasks.Task<DTOlib.RequestStatusChange> SelectLastStatusAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRequestStatusChange/SelectQuery", ReplyAction="http://tempuri.org/IRequestStatusChange/SelectQueryResponse")]
        int SelectQuery(string query, System.Collections.Generic.List<Oracle.ManagedDataAccess.Client.OracleParameter> param, string connectionString);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRequestStatusChange/SelectQuery", ReplyAction="http://tempuri.org/IRequestStatusChange/SelectQueryResponse")]
        System.Threading.Tasks.Task<int> SelectQueryAsync(string query, System.Collections.Generic.List<Oracle.ManagedDataAccess.Client.OracleParameter> param, string connectionString);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRequestStatusChangeChannel : Geodesyx.SRequestStatusChange.IRequestStatusChange, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RequestStatusChangeClient : System.ServiceModel.ClientBase<Geodesyx.SRequestStatusChange.IRequestStatusChange>, Geodesyx.SRequestStatusChange.IRequestStatusChange {
        
        public RequestStatusChangeClient() {
        }
        
        public RequestStatusChangeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RequestStatusChangeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RequestStatusChangeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RequestStatusChangeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Insert(DTOlib.RequestStatusChange input) {
            return base.Channel.Insert(input);
        }
        
        public System.Threading.Tasks.Task<int> InsertAsync(DTOlib.RequestStatusChange input) {
            return base.Channel.InsertAsync(input);
        }
        
        public System.Collections.Generic.List<DTOlib.RequestStatusChange> Select(System.Collections.Generic.List<int> ids) {
            return base.Channel.Select(ids);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DTOlib.RequestStatusChange>> SelectAsync(System.Collections.Generic.List<int> ids) {
            return base.Channel.SelectAsync(ids);
        }
        
        public DTOlib.RequestStatusChange SelectLastStatus(int id) {
            return base.Channel.SelectLastStatus(id);
        }
        
        public System.Threading.Tasks.Task<DTOlib.RequestStatusChange> SelectLastStatusAsync(int id) {
            return base.Channel.SelectLastStatusAsync(id);
        }
        
        public int SelectQuery(string query, System.Collections.Generic.List<Oracle.ManagedDataAccess.Client.OracleParameter> param, string connectionString) {
            return base.Channel.SelectQuery(query, param, connectionString);
        }
        
        public System.Threading.Tasks.Task<int> SelectQueryAsync(string query, System.Collections.Generic.List<Oracle.ManagedDataAccess.Client.OracleParameter> param, string connectionString) {
            return base.Channel.SelectQueryAsync(query, param, connectionString);
        }
    }
}
