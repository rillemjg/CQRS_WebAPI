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
        private QuantityAdditionFailedEventHandler quantityAdditionFailedEventHandler;
        private QuantityAddedDbEventHandler quantityAddedDbEventHandler;
        private ClearShoppingCartEventHandler clearShoppingCartEventHandler;

        public EventPublisher(QuantityAdditionFailedEventHandler quantityAdditionFailedEventHandler,
            QuantityAddedDbEventHandler quantityAddedDbEventHandler,
            ClearShoppingCartEventHandler clearShoppingCartEventHandler)
        {
            this.quantityAdditionFailedEventHandler = quantityAdditionFailedEventHandler;
            this.quantityAddedDbEventHandler = quantityAddedDbEventHandler;
            this.clearShoppingCartEventHandler = clearShoppingCartEventHandler;
        }

        public void Publish(IEvent eventData)
        {
            if (eventData is QuantityAdditionFailedEvent)
            {
                quantityAdditionFailedEventHandler.Handle((QuantityAdditionFailedEvent)eventData);
            }
            else if (eventData is QuantityAddedEvent)
            {
                quantityAddedDbEventHandler.Handle((QuantityAddedEvent)eventData);
            }
            else if (eventData is ClearShoppingCartEvent)
            {
                clearShoppingCartEventHandler.Handle((ClearShoppingCartEvent)eventData);
            }
        }
    }
}
