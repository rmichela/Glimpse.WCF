using System;
using System.Runtime.Serialization;
using Glimpse.Core.Message;

namespace Glimpse.WCF.Message
{
    [Serializable]
    [DataContract(Namespace = "http://schemas.getglimpse.com/glimpsewcf/2014/10")]
    public class SerializableTraceMessage : ITraceMessage
    {
        [DataMember]
        public string Category { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public TimeSpan FromFirst { get; set; }

        [DataMember]
        public TimeSpan FromLast { get; set; }

        [DataMember]
        public int IndentLevel { get; set; }

        public SerializableTraceMessage(ITraceMessage baseMessage)
        {
            Category = baseMessage.Category;
            Message = baseMessage.Message;
            FromFirst = baseMessage.FromFirst;
            FromLast = baseMessage.FromLast;
            IndentLevel = baseMessage.IndentLevel;
        }
    }
}
