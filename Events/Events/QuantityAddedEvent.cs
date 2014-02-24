using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events.Events
{
    public class QuantityAddedEvent : IEvent
    {
        public int ProductId { get; set; }
        public int AddedQuantity { get; set; }
    }
}
