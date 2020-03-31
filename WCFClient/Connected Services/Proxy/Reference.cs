﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFClient.Proxy {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Proxy.IService", CallbackContract=typeof(WCFClient.Proxy.IServiceCallback))]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/ClientLogIntoServer")]
        void ClientLogIntoServer(string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/ClientLogIntoServer")]
        System.Threading.Tasks.Task ClientLogIntoServerAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/ServerGetMessageFromClient")]
        void ServerGetMessageFromClient(string clientMessage);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/ServerGetMessageFromClient")]
        System.Threading.Tasks.Task ServerGetMessageFromClientAsync(string clientMessage);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/ClientLogOutOfServer")]
        void ClientLogOutOfServer(string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/ClientLogOutOfServer")]
        System.Threading.Tasks.Task ClientLogOutOfServerAsync(string username);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/ServerSendMessageToClient")]
        void ServerSendMessageToClient(string serverMessage);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : WCFClient.Proxy.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.DuplexClientBase<WCFClient.Proxy.IService>, WCFClient.Proxy.IService {
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void ClientLogIntoServer(string username) {
            base.Channel.ClientLogIntoServer(username);
        }
        
        public System.Threading.Tasks.Task ClientLogIntoServerAsync(string username) {
            return base.Channel.ClientLogIntoServerAsync(username);
        }
        
        public void ServerGetMessageFromClient(string clientMessage) {
            base.Channel.ServerGetMessageFromClient(clientMessage);
        }
        
        public System.Threading.Tasks.Task ServerGetMessageFromClientAsync(string clientMessage) {
            return base.Channel.ServerGetMessageFromClientAsync(clientMessage);
        }
        
        public void ClientLogOutOfServer(string username) {
            base.Channel.ClientLogOutOfServer(username);
        }
        
        public System.Threading.Tasks.Task ClientLogOutOfServerAsync(string username) {
            return base.Channel.ClientLogOutOfServerAsync(username);
        }
    }
}