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

        private readonly SynchronizedCollection<ITimedMessage> _accumulatedITimedMessages;
        private readonly SynchronizedCollection<ITraceMessage> _accumulatedITraceMessages;
        private readonly RelativeExecutionTimer _sessionTimer;
        private readonly Guid _guid;

        private GlimpseWcfContext()
        {
            _accumulatedITimedMessages = new SynchronizedCollection<ITimedMessage>();
            _accumulatedITraceMessages = new SynchronizedCollection<ITraceMessage>();
            _sessionTimer = new RelativeExecutionTimer();
            _guid = Guid.NewGuid();
        }

        // Deserialization constructor
        private GlimpseWcfContext(SerializationInfo info, StreamingContext context)
        {
            _accumulatedITimedMessages = (SynchronizedCollection<ITimedMessage>)info.GetValue("_accumulatedITimedMessages", typeof(SynchronizedCollection<ITimedMessage>));
            _accumulatedITraceMessages = (SynchronizedCollection<ITraceMessage>)info.GetValue("_accumulatedITraceMessages", typeof(SynchronizedCollection<ITraceMessage>));
            _sessionTimer = (RelativeExecutionTimer) info.GetValue("_sessionTimer", typeof (RelativeExecutionTimer));
            _guid = (Guid) info.GetValue("_guid", typeof (Guid));
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

        public ITimedMessage[] AccumulatedITimedMessages
        {
            get { return _accumulatedITimedMessages.ToArray(); }
        }

        public ITraceMessage[] AccumulatedITraceMessages
        {
            get { return _accumulatedITraceMessages.ToArray(); }
        }

        public void AccumulateMessage(ITimedMessage message)
        {
            _accumulatedITimedMessages.Add(message);
        }

        public void AccumulateMessage(ITraceMessage message)
        {
            _accumulatedITraceMessages.Add(message);
        }

        public Guid Identifier { get { return _guid; } }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (context.State == StreamingContextStates.CrossAppDomain)
            {
                // If crossing an app domain, don't serialize anything because the receiving side won't have the type loaded
                info.SetType(typeof(object));
            }
            else
            {
                info.AddValue("_accumulatedITimedMessages", _accumulatedITimedMessages);
                info.AddValue("_accumulatedITraceMessages", _accumulatedITraceMessages);
                info.AddValue("_sessionTimer", _sessionTimer);
                info.AddValue("_guid", _guid);
            }
        }
    }
}
