﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Geodesyx.SService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SService.IOracleWcfService")]
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
    public interface IOracleWcfServiceChannel : Geodesyx.SService.IOracleWcfService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OracleWcfServiceClient : System.ServiceModel.ClientBase<Geodesyx.SService.IOracleWcfService>, Geodesyx.SService.IOracleWcfService {
        
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SService.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SelectServices", ReplyAction="http://tempuri.org/IService/SelectServicesResponse")]
        System.Collections.Generic.List<DTOlib.Service> SelectServices();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SelectServices", ReplyAction="http://tempuri.org/IService/SelectServicesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DTOlib.Service>> SelectServicesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Insert", ReplyAction="http://tempuri.org/IService/InsertResponse")]
        int Insert(DTOlib.Service input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Insert", ReplyAction="http://tempuri.org/IService/InsertResponse")]
        System.Threading.Tasks.Task<int> InsertAsync(DTOlib.Service input);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : Geodesyx.SService.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<Geodesyx.SService.IService>, Geodesyx.SService.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<DTOlib.Service> SelectServices() {
            return base.Channel.SelectServices();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DTOlib.Service>> SelectServicesAsync() {
            return base.Channel.SelectServicesAsync();
        }
        
        public int Insert(DTOlib.Service input) {
            return base.Channel.Insert(input);
        }
        
        public System.Threading.Tasks.Task<int> InsertAsync(DTOlib.Service input) {
            return base.Channel.InsertAsync(input);
        }
    }
}