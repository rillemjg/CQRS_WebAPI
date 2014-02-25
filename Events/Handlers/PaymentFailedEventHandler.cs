using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Events.Events;
using Dtos.Additional;
using Repositories;
using Dtos.Infrastructure;

namespace Events.Handlers
{
    public class PaymentFailedEventHandler : IEventHandler<PaymentFailedEvent>
    {
        public void Handle(PaymentFailedEvent eventData)
        {
            string message = eventData.FailureCode + ": " + eventData.FailureMessage;
            var failedEventData = new FailedEventData();
            failedEventData.EventType = eventData.GetType().ToString();
            failedEventData.Message = message;

            FailedEventsRepository.AddFailedEvent(failedEventData);

            var paymentData = new PaymentData()
                                  {
                                      PaymentGuid = eventData.PaymentGuid,
                                      Message = message,
                                      PaymentStatus = PaymentStatus.Failed
                                  };

            PaymentRepository.AddOrReplacePaymentData(paymentData);
        }
    }
}
