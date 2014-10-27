using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Glimpse.WCF.Extensibility;

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
            var header = new GlimpseWcfMessageHeader
            {
                CalledServiceTimes = GlimpseWcfContext.Current.AccumulatedIMessages
            };
            reply.Headers.Add(MessageHeader.CreateHeader(GlimpseWcfMessageHeader.Name, GlimpseWcfMessageHeader.Namespace, header));
        }
    }
}
