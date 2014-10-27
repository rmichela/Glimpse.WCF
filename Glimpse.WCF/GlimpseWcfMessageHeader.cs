using System.Runtime.Serialization;
using Glimpse.Core.Message;
using Glimpse.WCF.Message;

namespace Glimpse.WCF
{
    [DataContract(Namespace = "http://schemas.getglimpse.com/glimpsewcf/2014/10")]
    [KnownType(typeof (SerializableTimedMessage))]
    [KnownType(typeof (SerializableTimelineMessage))]
    [KnownType(typeof (SerializableTraceMessage))]
    public class GlimpseWcfMessageHeader
    {
        public static readonly string Name = "GlimpseWcfMessageHeader";
        public static readonly string Namespace = "http://schemas.getglimpse.com/glimpsewcf/2014/10";

        [DataMember]
        public ITimedMessage[] CollectedITimedMessages { get; set; }

        [DataMember]
        public ITraceMessage[] CollectedITraceMessages { get; set; }
    }
}
