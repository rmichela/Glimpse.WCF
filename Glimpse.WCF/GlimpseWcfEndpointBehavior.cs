using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Glimpse.WCF
{
    public class GlimpseWcfEndpointBehavior : BehaviorExtensionElement, IEndpointBehavior
    {
        public void Validate(ServiceEndpoint endpoint)
        {
            // Do nothing
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            // Do nothing
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new GlimpseWcfDispatchMessageInspector());
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(new GlimpseWcfClientMessageInspector());
        }

        protected override object CreateBehavior()
        {
            return this;
        }

        public override Type BehaviorType
        {
            get { return GetType(); }
        }
    }
}
