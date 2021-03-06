﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Geodesyx.SBrigadeInWorkTasks {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SBrigadeInWorkTasks.IOracleWcfService")]
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
    public interface IOracleWcfServiceChannel : Geodesyx.SBrigadeInWorkTasks.IOracleWcfService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OracleWcfServiceClient : System.ServiceModel.ClientBase<Geodesyx.SBrigadeInWorkTasks.IOracleWcfService>, Geodesyx.SBrigadeInWorkTasks.IOracleWcfService {
        
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SBrigadeInWorkTasks.IBrigadeInWorkTasks")]
    public interface IBrigadeInWorkTasks {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrigadeInWorkTasks/SelectAll", ReplyAction="http://tempuri.org/IBrigadeInWorkTasks/SelectAllResponse")]
        System.Collections.Generic.List<DTOlib.VBrigadeInWorkTasks> SelectAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrigadeInWorkTasks/SelectAll", ReplyAction="http://tempuri.org/IBrigadeInWorkTasks/SelectAllResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DTOlib.VBrigadeInWorkTasks>> SelectAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrigadeInWorkTasks/SelectIn", ReplyAction="http://tempuri.org/IBrigadeInWorkTasks/SelectInResponse")]
        System.Collections.Generic.List<DTOlib.VBrigadeInWorkTasks> SelectIn(System.Collections.Generic.List<int> task_ids);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBrigadeInWorkTasks/SelectIn", ReplyAction="http://tempuri.org/IBrigadeInWorkTasks/SelectInResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DTOlib.VBrigadeInWorkTasks>> SelectInAsync(System.Collections.Generic.List<int> task_ids);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBrigadeInWorkTasksChannel : Geodesyx.SBrigadeInWorkTasks.IBrigadeInWorkTasks, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BrigadeInWorkTasksClient : System.ServiceModel.ClientBase<Geodesyx.SBrigadeInWorkTasks.IBrigadeInWorkTasks>, Geodesyx.SBrigadeInWorkTasks.IBrigadeInWorkTasks {
        
        public BrigadeInWorkTasksClient() {
        }
        
        public BrigadeInWorkTasksClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BrigadeInWorkTasksClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BrigadeInWorkTasksClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BrigadeInWorkTasksClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<DTOlib.VBrigadeInWorkTasks> SelectAll() {
            return base.Channel.SelectAll();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DTOlib.VBrigadeInWorkTasks>> SelectAllAsync() {
            return base.Channel.SelectAllAsync();
        }
        
        public System.Collections.Generic.List<DTOlib.VBrigadeInWorkTasks> SelectIn(System.Collections.Generic.List<int> task_ids) {
            return base.Channel.SelectIn(task_ids);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DTOlib.VBrigadeInWorkTasks>> SelectInAsync(System.Collections.Generic.List<int> task_ids) {
            return base.Channel.SelectInAsync(task_ids);
        }
    }
}
