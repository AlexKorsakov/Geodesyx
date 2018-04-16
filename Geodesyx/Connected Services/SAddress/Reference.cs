﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Geodesyx.SAddress {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SAddress.IOracleWcfService")]
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
    public interface IOracleWcfServiceChannel : Geodesyx.SAddress.IOracleWcfService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OracleWcfServiceClient : System.ServiceModel.ClientBase<Geodesyx.SAddress.IOracleWcfService>, Geodesyx.SAddress.IOracleWcfService {
        
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SAddress.IAddress")]
    public interface IAddress {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddress/Select", ReplyAction="http://tempuri.org/IAddress/SelectResponse")]
        DTOlib.Address Select(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddress/Select", ReplyAction="http://tempuri.org/IAddress/SelectResponse")]
        System.Threading.Tasks.Task<DTOlib.Address> SelectAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddress/SelectAddresses", ReplyAction="http://tempuri.org/IAddress/SelectAddressesResponse")]
        System.Collections.Generic.List<DTOlib.Address> SelectAddresses();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddress/SelectAddresses", ReplyAction="http://tempuri.org/IAddress/SelectAddressesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DTOlib.Address>> SelectAddressesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddress/Insert", ReplyAction="http://tempuri.org/IAddress/InsertResponse")]
        int Insert(DTOlib.Address input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddress/Insert", ReplyAction="http://tempuri.org/IAddress/InsertResponse")]
        System.Threading.Tasks.Task<int> InsertAsync(DTOlib.Address input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddress/Update", ReplyAction="http://tempuri.org/IAddress/UpdateResponse")]
        int Update(int id, string name, float X, float Y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddress/Update", ReplyAction="http://tempuri.org/IAddress/UpdateResponse")]
        System.Threading.Tasks.Task<int> UpdateAsync(int id, string name, float X, float Y);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAddressChannel : Geodesyx.SAddress.IAddress, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AddressClient : System.ServiceModel.ClientBase<Geodesyx.SAddress.IAddress>, Geodesyx.SAddress.IAddress {
        
        public AddressClient() {
        }
        
        public AddressClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AddressClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AddressClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AddressClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public DTOlib.Address Select(int id) {
            return base.Channel.Select(id);
        }
        
        public System.Threading.Tasks.Task<DTOlib.Address> SelectAsync(int id) {
            return base.Channel.SelectAsync(id);
        }
        
        public System.Collections.Generic.List<DTOlib.Address> SelectAddresses() {
            return base.Channel.SelectAddresses();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DTOlib.Address>> SelectAddressesAsync() {
            return base.Channel.SelectAddressesAsync();
        }
        
        public int Insert(DTOlib.Address input) {
            return base.Channel.Insert(input);
        }
        
        public System.Threading.Tasks.Task<int> InsertAsync(DTOlib.Address input) {
            return base.Channel.InsertAsync(input);
        }
        
        public int Update(int id, string name, float X, float Y) {
            return base.Channel.Update(id, name, X, Y);
        }
        
        public System.Threading.Tasks.Task<int> UpdateAsync(int id, string name, float X, float Y) {
            return base.Channel.UpdateAsync(id, name, X, Y);
        }
    }
}