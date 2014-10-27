using System;
using Glimpse.Core.Message;

namespace Glimpse.WCF.Message
{
    public class WcfTimelineMessage : ITimelineMessage
    {
        public static readonly TimelineCategoryItem Category = new TimelineCategoryItem("WCF Service", "#007864", "#008F77");

        public WcfTimelineMessage()
        {
            Id = Guid.NewGuid();
            StartTime = DateTime.Now;
        }
        
        public string ServiceName { get; set; }
        public Guid Id { get; private set; }
        public TimeSpan Offset { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime StartTime { get; set; }
        public string EventName { get; set; }
        public string EventSubText { get; set; }

        public TimelineCategoryItem EventCategory { get; set; }
    }
}
