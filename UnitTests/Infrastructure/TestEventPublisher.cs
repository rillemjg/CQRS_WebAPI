using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Events;
using Events.Events;

namespace UnitTests.Infrastructure
{
    public class TestEventPublisher : IEventPublisher
    {
        public List<QuantityAdditionFailedEvent> FailedEvents { get; private set; }
        public List<QuantityAddedEvent> SuccessEvents { get; private set; }

        public TestEventPublisher()
        {
            FailedEvents = new List<QuantityAdditionFailedEvent>();
            SuccessEvents = new List<QuantityAddedEvent>();
        }

        public void Publish(Events.Events.IEvent eventData)
        {
            if (eventData is QuantityAdditionFailedEvent)
            {
                FailedEvents.Add((QuantityAdditionFailedEvent)eventData);
            }
            else if (eventData is QuantityAddedEvent)
            {
                SuccessEvents.Add((QuantityAddedEvent)eventData);
            }
        }
    }
}
