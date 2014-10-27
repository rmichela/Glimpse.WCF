using System;
using System.Runtime.Serialization;
using Glimpse.Core.Message;

namespace Glimpse.WCF.Message
{
    [Serializable]
    [DataContract(Namespace = "http://schemas.getglimpse.com/glimpsewcf/2014/10")]
    public class SerializableTimedMessage : ITimedMessage
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public TimeSpan Offset { get; set; }

        [DataMember]
        public TimeSpan Duration { get; set; }

        [DataMember]
        public DateTime StartTime { get; set; }

        public SerializableTimedMessage(ITimedMessage baseMessage)
        {
            Id = baseMessage.Id;
            Offset = baseMessage.Offset;
            Duration = baseMessage.Duration;
            StartTime = baseMessage.StartTime;
        }
    }
}
