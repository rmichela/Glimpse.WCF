using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Linq;
using Glimpse.Core.Message;
using Glimpse.WCF.Extensibility;
using Glimpse.WCF.Message;

namespace Glimpse.WCF
{
    // SERVER SIDE
    public class GlimpseWcfDispatchMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            GlimpseWcfConfigShim.Register();
            return null;
        }

        public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            // Attach any accumulated timeline messages to the response header
            var currentContext = GlimpseWcfContext.Current;

            var header = new GlimpseWcfMessageHeader
            {
                CollectedITimedMessages = currentContext.AccumulatedITimedMessages.Select(SerializeTimedMessages).ToArray(),
                CollectedITraceMessages = currentContext.AccumulatedITraceMessages.Select(SerializeTraceMessage).ToArray()
            };
            reply.Headers.Add(MessageHeader.CreateHeader(GlimpseWcfMessageHeader.Name, GlimpseWcfMessageHeader.Namespace, header));
        }

        private ITimedMessage SerializeTimedMessages(ITimedMessage message)
        {
            if (message is ITimelineMessage)
            {
                return new SerializableTimelineMessage(message as ITimelineMessage);
            }
            return new SerializableTimedMessage(message);
        }

        private ITraceMessage SerializeTraceMessage(ITraceMessage message)
        {
            return new SerializableTraceMessage(message);
        }
    }
}
