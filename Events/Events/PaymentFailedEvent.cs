using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events.Events
{
    public class PaymentFailedEvent : IEvent
    {
        public string PaymentGuid { get; set; }
        public string FailureCode { get; set; }
        public string FailureMessage { get; set; }
    }
}
