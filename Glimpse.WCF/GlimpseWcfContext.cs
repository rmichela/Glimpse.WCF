using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Glimpse.WCF
{
    [Serializable]
    internal class GlimpseWcfContext : ISerializable
    {
        private const string CallContextSlotName = "Glimpse.WCF.GlimpseWcfContext";

        private readonly SynchronizedCollection<WcfTimelineMessage> _accumulatedMessages;

        private GlimpseWcfContext()
        {
            _accumulatedMessages = new SynchronizedCollection<WcfTimelineMessage>();
        }

        // Deserialization constructor
        private GlimpseWcfContext(SerializationInfo info, StreamingContext context)
        {
            _accumulatedMessages = (SynchronizedCollection<WcfTimelineMessage>)info.GetValue("_accumulatedMessages", typeof(SynchronizedCollection<WcfTimelineMessage>));
        }

        public static GlimpseWcfContext Current
        {
            get
            {
                var context = CallContext.LogicalGetData(CallContextSlotName) as GlimpseWcfContext;
                if (context == null)
                {
                    context = new GlimpseWcfContext();
                    CallContext.LogicalSetData(CallContextSlotName, context);
                }
                return context;
            }
        }

        public WcfTimelineMessage[] AccumulateMessages
        {
            get { return _accumulatedMessages.ToArray(); }
        }

        public void AccumulateMessage(WcfTimelineMessage message)
        {
            _accumulatedMessages.Add(message);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (context.State == StreamingContextStates.CrossAppDomain)
            {
                // If crossing an app domain, don't serialize anything because the receiving side won't have the type loaded
                info.SetType(typeof(object));
            }
            else
            {
                info.AddValue("_accumulatedMessages", _accumulatedMessages);
            }
        }
    }
}
