using System;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Message;
using Glimpse.WCF.Message;

namespace Glimpse.WCF.Extensibility
{
    public class GlimpseWcfMessageBroker : IMessageBroker
    {
        public void Publish<T>(T message)
        {
            if (message is ITraceMessage)
            {
                GlimpseWcfContext.Current.AccumulateMessage(new SerializableTraceMessage(message as ITraceMessage));
            }
            if (message is ITimelineMessage)
            {
                GlimpseWcfContext.Current.AccumulateMessage(new SerializableTimelineMessage(message as ITimelineMessage));                
            }
            if (message is ITimedMessage)
            {
                GlimpseWcfContext.Current.AccumulateMessage(new SerializableTimedMessage(message as ITimedMessage));
            }
        }

        public Guid Subscribe<T>(Action<T> action)
        {
            // do nothing
            return Guid.NewGuid();
        }

        public void Unsubscribe<T>(Guid subscriptionId)
        {
            // do nothing
        }
    }
}
