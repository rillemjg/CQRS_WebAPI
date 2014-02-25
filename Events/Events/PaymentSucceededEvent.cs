using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events.Events
{
    public class PaymentSucceededEvent : IEvent
    {
        public string PaymentGuid { get; set; }
    }
}
