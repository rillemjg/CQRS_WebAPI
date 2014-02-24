using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Events.Events;

namespace Events
{
    public interface IEventPublisher
    {
        void Publish(IEvent eventData);
    }
}
