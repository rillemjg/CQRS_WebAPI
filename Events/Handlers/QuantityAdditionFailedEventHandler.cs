using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dtos.Additional;
using Events.Events;
using Repositories;
using Dtos;

namespace Events.Handlers
{
    public class QuantityAdditionFailedEventHandler : IEventHandler<QuantityAdditionFailedEvent>
    {
        public void Handle(QuantityAdditionFailedEvent eventData)
        {
            var failedEventData = new FailedEventData();
            failedEventData.EventType = eventData.GetType().ToString();
            failedEventData.Message = "Adding quantity failed for product " + eventData.ProductId;

            FailedEventsRepository.AddFailedEvent(failedEventData);
        }
    }
}
