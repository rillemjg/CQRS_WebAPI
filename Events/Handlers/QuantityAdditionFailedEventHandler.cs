using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Events.Events;

namespace Events.Handlers
{
    public class QuantityAdditionFailedEventHandler : IEventHandler<QuantityAdditionFailedEvent>
    {
        public void Handle(QuantityAdditionFailedEvent eventData)
        {
            throw new NotImplementedException();
        }
    }
}
