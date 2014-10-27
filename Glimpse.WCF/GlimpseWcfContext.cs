using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using Glimpse.Core.Message;
using Glimpse.WCF.Extensibility;
using Glimpse.WCF.Message;

namespace Glimpse.WCF
{
    [Serializable]
    [KnownType(typeof(SerializableTimedMessage))]
    [KnownType(typeof(SerializableTimelineMessage))]
    [KnownType(typeof(SerializableTraceMessage))]    
    internal class GlimpseWcfContext : ISerializable
    {
        private const string CALL_CONTEXT_SLOT_NAME = "Glimpse.WCF.GlimpseWcfContext";

        private readonly SynchronizedCollection<Glimpse.Core.Message.IMessage> _accumulatedIMessages;
        private readonly SynchronizedCollection<Glimpse.Core.Message.ITraceMessage> _accumulatedITraceMessages;
        private readonly RelativeExecutionTimer _sessionTimer;

        private GlimpseWcfContext()
        {
            _accumulatedIMessages = new SynchronizedCollection<Glimpse.Core.Message.IMessage>();
            _accumulatedITraceMessages = new SynchronizedCollection<ITraceMessage>();
        }

        // Deserialization constructor

        private GlimpseWcfContext(SerializationInfo info, StreamingContext context)
        {
            _accumulatedIMessages = (SynchronizedCollection<Glimpse.Core.Message.IMessage>)info.GetValue("_accumulatedIMessages", typeof(SynchronizedCollection<Glimpse.Core.Message.IMessage>));
            _accumulatedITraceMessages = (SynchronizedCollection<Glimpse.Core.Message.ITraceMessage>)info.GetValue("_accumulatedITraceMessages", typeof(SynchronizedCollection<Glimpse.Core.Message.ITraceMessage>));
            _sessionTimer = (RelativeExecutionTimer) info.GetValue("_sessionTimer", typeof (RelativeExecutionTimer));
        }

        public static GlimpseWcfContext Current
        {
            get
            {
                var context = CallContext.LogicalGetData(CALL_CONTEXT_SLOT_NAME) as GlimpseWcfContext;
                if (context == null)
                {
                    context = new GlimpseWcfContext();
                    CallContext.LogicalSetData(CALL_CONTEXT_SLOT_NAME, context);
                }
                return context;
            }
        }

        public RelativeExecutionTimer SessionTimer
        {
            get { return _sessionTimer; }
        }

        public Glimpse.Core.Message.IMessage[] AccumulatedIMessages
        {
            get { return _accumulatedIMessages.ToArray(); }
        }

        public Glimpse.Core.Message.ITraceMessage[] AccumulatedITraceMessages
        {
            get { return _accumulatedITraceMessages.ToArray(); }
        }

        public void AccumulateMessage(Glimpse.Core.Message.IMessage message)
        {
            _accumulatedIMessages.Add(message);
        }

        public void AccumulateMessage(Glimpse.Core.Message.ITraceMessage message)
        {
            _accumulatedITraceMessages.Add(message);
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
                info.AddValue("_accumulatedIMessages", _accumulatedIMessages);
                info.AddValue("_accumulatedITraceMessages", _accumulatedITraceMessages);
                info.AddValue("_sessionTimer", _sessionTimer);
            }
        }
    }
}
