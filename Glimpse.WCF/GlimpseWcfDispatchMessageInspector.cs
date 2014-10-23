using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Glimpse.WCF
{
    internal class GlimpseWcfDispatchMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            // Do nothing
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            // Attach any accumulated timeline messages to the response header
            var header = new GlimpseWcfMessageHeader
            {
                CalledServiceTimes = GlimpseWcfContext.Current.AccumulateMessages
            };
            reply.Headers.Add(MessageHeader.CreateHeader(GlimpseWcfMessageHeader.Name, GlimpseWcfMessageHeader.Namespace, header));
        }
    }
}
