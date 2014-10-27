using System;
using System.Runtime.Serialization;
using Glimpse.Core.Message;

namespace Glimpse.WCF.Message
{
    [Serializable]
    [DataContract(Namespace = "http://schemas.getglimpse.com/glimpsewcf/2014/10")]
    public class SerializableTimelineMessage : SerializableTimedMessage, ITimelineMessage
    {
        [DataMember]
        public string EventName { get; set; }

        [DataMember]
        public string EventCategoryName { get; set; }

        [DataMember]
        public string EventCategoryColor { get; set; }

        [DataMember]
        public string EventCategoryColorHighlight { get; set; }

        [DataMember]
        public string EventSubText { get; set; }

        [IgnoreDataMember]
        public TimelineCategoryItem EventCategory
        {
            get
            {
                return new TimelineCategoryItem(EventCategoryName, EventCategoryColor, EventCategoryColorHighlight);
            }
            set 
            { 
                EventCategoryName = value.Name;
                EventCategoryColor = value.Color;
                EventCategoryColorHighlight = value.ColorHighlight;
            }
        }

        public SerializableTimelineMessage(ITimelineMessage baseMessage) : base(baseMessage)
        {
            EventName = baseMessage.EventName;
            EventSubText = baseMessage.EventSubText;
            EventCategory = baseMessage.EventCategory;
        }

        
    }
}
