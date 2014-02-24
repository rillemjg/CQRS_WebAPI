using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Events.Events;
using Events.Handlers;

namespace Events
{
    public class EventPublisher : IEventPublisher
    {
        public void Publish(IEvent eventData)
        {
            if (eventData is QuantityAdditionFailedEvent)
            {
                var handler = new QuantityAdditionFailedEventHandler();
                handler.Handle((QuantityAdditionFailedEvent)eventData);
            }
            else if (eventData is QuantityAddedEvent)
            {
                var handler = new QuantityAddedDbEventHandler();
                handler.Handle((QuantityAddedEvent)eventData);
            }
        }
    }
}
