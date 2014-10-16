using System;
using System.Threading;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Framework;
using Glimpse.Core.Message;

namespace Glimpse.WCF
{
    public class TimeWaster
    {
        private static TimeSpan _masterTimerOffset;

        public static void StartMasterWaste()
        {
            IExecutionTimer timer = GlimpseConfiguration.GetConfiguredTimerStrategy()();
            _masterTimerOffset = timer.Start();
        }

        public static void EndMasterWaste()
        {
            IExecutionTimer timer = GlimpseConfiguration.GetConfiguredTimerStrategy()();
            TimeWasteMessage message = new TimeWasteMessage()
                .AsTimedMessage(timer.Stop(_masterTimerOffset))
                .AsTimelineMessage("Master Waste", TimeWasteTimelineCategoryItem.Waste);
            IMessageBroker broker = GlimpseConfiguration.GetConfiguredMessageBroker();
            broker.Publish(message);
        }


        public void WasteTime()
        {
            IExecutionTimer timer = GlimpseConfiguration.GetConfiguredTimerStrategy()();
            TimerResult timeResult = timer.Time(() => Thread.Sleep(new Random().Next(2000)));
            TimeWasteMessage message = new TimeWasteMessage()
                .AsTimedMessage(timeResult)
                .AsTimelineMessage("Wasted Time", TimeWasteTimelineCategoryItem.Waste, "Procrastination!");
            IMessageBroker broker = GlimpseConfiguration.GetConfiguredMessageBroker();
            broker.Publish(message);
        }
    }
}
