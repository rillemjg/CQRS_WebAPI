using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            failedEventData.EventName = "QuantityAdditionFailedEvent";
            failedEventData.ProductId = eventData.ProductId;

            FailedEventsRepository.AddFailedEvent(failedEventData);
        }
    }
}
