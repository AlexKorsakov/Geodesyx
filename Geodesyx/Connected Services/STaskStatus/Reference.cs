﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Geodesyx.STaskStatus {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="STaskStatus.IOracleWcfService")]
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
    public interface IOracleWcfServiceChannel : Geodesyx.STaskStatus.IOracleWcfService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OracleWcfServiceClient : System.ServiceModel.ClientBase<Geodesyx.STaskStatus.IOracleWcfService>, Geodesyx.STaskStatus.IOracleWcfService {
        
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="STaskStatus.ITaskStatus")]
    public interface ITaskStatus {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITaskStatus/SelectAll", ReplyAction="http://tempuri.org/ITaskStatus/SelectAllResponse")]
        System.Collections.Generic.List<DTOlib.TaskStatus> SelectAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITaskStatus/SelectAll", ReplyAction="http://tempuri.org/ITaskStatus/SelectAllResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DTOlib.TaskStatus>> SelectAllAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITaskStatusChannel : Geodesyx.STaskStatus.ITaskStatus, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TaskStatusClient : System.ServiceModel.ClientBase<Geodesyx.STaskStatus.ITaskStatus>, Geodesyx.STaskStatus.ITaskStatus {
        
        public TaskStatusClient() {
        }
        
        public TaskStatusClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TaskStatusClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TaskStatusClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TaskStatusClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<DTOlib.TaskStatus> SelectAll() {
            return base.Channel.SelectAll();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DTOlib.TaskStatus>> SelectAllAsync() {
            return base.Channel.SelectAllAsync();
        }
    }
}
