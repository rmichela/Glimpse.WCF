using System;
using Glimpse.Core.Message;

namespace Glimpse.WCF
{
    public class TimeWasteMessage : ITimelineMessage
    {
        public TimeWasteMessage()
        {
            Id = Guid.NewGuid();
            StartTime = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public TimeSpan Offset { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime StartTime { get; set; }
        public string EventName { get; set; }
        public TimelineCategoryItem EventCategory { get; set; }
        public string EventSubText { get; set; }
    }
}
