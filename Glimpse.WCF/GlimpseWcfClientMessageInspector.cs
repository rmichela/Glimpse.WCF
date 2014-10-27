using System;
using System.Collections.Concurrent;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Framework;
using Glimpse.Core.Message;
using Glimpse.WCF.Extensibility;
using Glimpse.WCF.Message;

namespace Glimpse.WCF
{
    // CLIENT SIDE
    public class GlimpseWcfClientMessageInspector : IClientMessageInspector
    {
        private class ServiceDescription
        {
            public TimeSpan Offest;
            public EndpointAddress RemoteAddress;
            public string Action;
        }

        private readonly ConcurrentDictionary<Guid, ServiceDescription> _knownOffsets = new ConcurrentDictionary<Guid, ServiceDescription>();

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, IClientChannel channel)
        {
            IExecutionTimer timer = GlimpseWcfConfigShim.GetSessionTimer();
            TimeSpan offset = timer.Start();
            Guid correlationState = Guid.NewGuid();

            var description = new ServiceDescription
                {
                    Offest = offset,
                    RemoteAddress = channel.RemoteAddress,
                    Action = request.Headers.Action
                };

            if (!_knownOffsets.TryAdd(correlationState, description))
            {
                throw new InvalidOperationException();
            }

            return correlationState;
        }

        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            // Time this call
            IExecutionTimer timer = GlimpseWcfConfigShim.GetSessionTimer();
            ServiceDescription serviceDescription;
            if (!_knownOffsets.TryRemove((Guid)correlationState, out serviceDescription))
            {
                throw new InvalidOperationException();
            }

            var message = new WcfTimelineMessage()
                .AsTimedMessage(timer.Stop(serviceDescription.Offest))
                // TODO: Fix service name
                .AsTimelineMessage("WCF: " + ExtractContractName(serviceDescription.Action), 
                                   WcfTimelineMessage.Category,
                                   serviceDescription.RemoteAddress.Uri.ToString());

            // Publish this request's timeline message
            IMessageBroker broker = GlimpseWcfConfigShim.GetBroker();
            broker.Publish(message);

            // Publish any timeline messages the service is reporting
            var glimpseWcfHeader = reply.Headers.GetHeader<GlimpseWcfMessageHeader>(GlimpseWcfMessageHeader.Name, GlimpseWcfMessageHeader.Namespace);
            foreach (ITimedMessage headerMessage in glimpseWcfHeader.CollectedITimedMessages)
            {
                headerMessage.Offset += message.Offset;
                broker.Publish(headerMessage);
            }
            foreach (ITraceMessage traceMessage in glimpseWcfHeader.CollectedITraceMessages)
            {
                broker.Publish(traceMessage);
            }
        }

        private string ExtractContractName(string action)
        {
            var splits = action.Split('/');
            return splits[splits.Length - 2];
        }
    }
}
