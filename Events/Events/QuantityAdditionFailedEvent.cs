using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events.Events
{
    public class QuantityAdditionFailedEvent : IEvent
    {
        public int ProductId { get; set; }
    }
}
