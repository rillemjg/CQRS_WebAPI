using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Events.Handlers;
using Events.Events;

namespace Events
{
    public class PaymentEventPublisher : IEventPublisher
    {
        private PaymentSucceededEventHandler paymentSucceededEventHandler;
        private PaymentFailedEventHandler paymentFailedEventHandler;
        private PaymentBeginEventHandler paymentBeginEventHandler;

        public PaymentEventPublisher(PaymentSucceededEventHandler paymentSucceededEventHandler,
            PaymentFailedEventHandler paymentFailedEventHandler,
            PaymentBeginEventHandler paymentBeginEventHandler)
        {
            this.paymentSucceededEventHandler = paymentSucceededEventHandler;
            this.paymentFailedEventHandler = paymentFailedEventHandler;
            this.paymentBeginEventHandler = paymentBeginEventHandler;
        }

        public void Publish(Events.IEvent eventData)
        {
            if (eventData is PaymentSucceededEvent)
            {
                paymentSucceededEventHandler.Handle((PaymentSucceededEvent)eventData);
            }
            else if (eventData is PaymentFailedEvent)
            {
                paymentFailedEventHandler.Handle((PaymentFailedEvent)eventData);
            }
            else if (eventData is PaymentBeginEvent)
            {
                paymentBeginEventHandler.Handle((PaymentBeginEvent)eventData);
            }
        }
    }
}
