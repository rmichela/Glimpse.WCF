using System.Runtime.Serialization;

namespace Glimpse.WCF
{
    [DataContract(Namespace = "http://schemas.getglimpse.com/glimpsewcf/2014/10")]
    public class GlimpseWcfMessageHeader
    {
        public static readonly string Name = "GlimpseWcfMessageHeader";
        public static readonly string Namespace = "http://schemas.getglimpse.com/glimpsewcf/2014/10";

        [DataMember]
        public WcfTimelineMessage ServiceTime { get; set; }

        [DataMember]
        public WcfTimelineMessage[] CalledServiceTimes { get; set; } 
    }
}
