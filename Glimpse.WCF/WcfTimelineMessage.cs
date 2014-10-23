using System;
using System.Runtime.Serialization;
using Glimpse.Core.Message;

namespace Glimpse.WCF
{
    [DataContract(Namespace = "http://schemas.getglimpse.com/glimpsewcf/2014/10")]
    public class WcfTimelineMessage : ITimelineMessage
    {
        private static readonly TimelineCategoryItem Category = new TimelineCategoryItem("WCF Service", "#007864", "#008F77");

        public WcfTimelineMessage()
        {
            Id = Guid.NewGuid();
            StartTime = DateTime.Now;
        }

        [DataMember]
        public string ServiceName { get; set; }

        [DataMember]
        public Guid Id { get; private set; }
        [DataMember]
        public TimeSpan Offset { get; set; }
        [DataMember]
        public TimeSpan Duration { get; set; }
        [DataMember]
        public DateTime StartTime { get; set; }
        [DataMember]
        public string EventName { get; set; }
        [DataMember]
        public string EventSubText { get; set; }

        public TimelineCategoryItem EventCategory {
            get { return Category; }
            set { throw new NotImplementedException(); }
        }
    }
}
