using System;
using Glimpse.Core.Extensibility;

namespace Glimpse.WCF.Extensibility
{
    [Serializable]
    public class RelativeExecutionTimer : IExecutionTimer
    {
        public DateTime RequestStart { get; set; }

        public RelativeExecutionTimer()
        {
            RequestStart = DateTime.Now;
        }

        public TimerResult Point()
        {
            var now = DateTime.Now;
            return new TimerResult
                {
                    StartTime = now,
                    Offset = now - RequestStart,
                    Duration = TimeSpan.Zero
                };
        }

        public TimerResult<T> Time<T>(Func<T> function)
        {
            var now = DateTime.Now;
            var result = new TimerResult<T>
            {
                StartTime = now,
                Offset = (now - RequestStart),
                Result = function()
            };
            result.Duration = (now - RequestStart) - result.Offset;

            return result;
        }

        public TimerResult Time(Action action)
        {
            var now = DateTime.Now;
            var result = new TimerResult
            {
                StartTime = now,
                Offset = (now - RequestStart)
            };
            action();
            result.Duration = (now - RequestStart) - result.Offset;

            return result;
        }

        public TimeSpan Start()
        {
            var now = DateTime.Now;
            return (now - RequestStart);
        }

        public TimerResult Stop(TimeSpan offset)
        {
            var now = DateTime.Now;
            var result = new TimerResult
            {
                StartTime = now - offset,
                Offset = offset
            };
            result.Duration = (now - RequestStart) - result.Offset;

            return result;
        }
    }
}
