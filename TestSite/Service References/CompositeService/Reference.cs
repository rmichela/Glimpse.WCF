﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestSite.CompositeService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CompositeService.ICompositeService")]
    public interface ICompositeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompositeService/DoWork", ReplyAction="http://tempuri.org/ICompositeService/DoWorkResponse")]
        int[] DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompositeService/DoWork", ReplyAction="http://tempuri.org/ICompositeService/DoWorkResponse")]
        System.Threading.Tasks.Task<int[]> DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompositeService/DoWorkParallel", ReplyAction="http://tempuri.org/ICompositeService/DoWorkParallelResponse")]
        int[] DoWorkParallel();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompositeService/DoWorkParallel", ReplyAction="http://tempuri.org/ICompositeService/DoWorkParallelResponse")]
        System.Threading.Tasks.Task<int[]> DoWorkParallelAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICompositeServiceChannel : TestSite.CompositeService.ICompositeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CompositeServiceClient : System.ServiceModel.ClientBase<TestSite.CompositeService.ICompositeService>, TestSite.CompositeService.ICompositeService {
        
        public CompositeServiceClient() {
        }
        
        public CompositeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CompositeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CompositeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CompositeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int[] DoWork() {
            return base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task<int[]> DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public int[] DoWorkParallel() {
            return base.Channel.DoWorkParallel();
        }
        
        public System.Threading.Tasks.Task<int[]> DoWorkParallelAsync() {
            return base.Channel.DoWorkParallelAsync();
        }
    }
}
