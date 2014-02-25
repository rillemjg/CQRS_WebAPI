using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dtos.Additional;
using Events.Events;
using Repositories;
using Dtos.Infrastructure;

namespace Events.Handlers
{
    public class PaymentSucceededEventHandler : IEventHandler<PaymentSucceededEvent>
    {
        public void Handle(PaymentSucceededEvent eventData)
        {
            PaymentRepository.AddOrReplacePaymentData(new PaymentData()
                                                          {
                                                              PaymentGuid = eventData.PaymentGuid,
                                                              PaymentStatus = PaymentStatus.Succeeded
                                                          });
        }
    }
}
