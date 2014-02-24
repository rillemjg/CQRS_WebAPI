using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dtos;

namespace Repositories
{
    public static class FailedEventsRepository
    {
        private static List<FailedEventData> FailedEvents;

        static FailedEventsRepository()
        {
            FailedEvents = new List<FailedEventData>();
        }

        public static void AddFailedEvent(FailedEventData failedEventData)
        {
            FailedEvents.Add(failedEventData);
        }

        public static FailedEventData GetFirstFailedEvent()
        {
            if (FailedEvents.Count == 0)
            {
                return null;
            }

            var failedEvent = FailedEvents[0];
            FailedEvents.RemoveAt(0);

            return failedEvent;
        }
    }
}
