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
    public class PaymentBeginEventHandler : IEventHandler<PaymentBeginEvent>
    {
        public void Handle(PaymentBeginEvent eventData)
        {
            PaymentRepository.AddOrReplacePaymentData(new PaymentData()
                                                          {
                                                              PaymentGuid = eventData.PaymentGuid,
                                                              PaymentStatus = PaymentStatus.Began
                                                          });
        }
    }
}
