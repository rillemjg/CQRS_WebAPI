using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Events.Events;

namespace Events.Handlers
{
    public interface IEventHandler<T> where T : IEvent
    {
        void Handle(T eventData);
    }
}
