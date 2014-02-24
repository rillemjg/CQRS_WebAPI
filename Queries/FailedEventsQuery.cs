using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositories;

namespace Queries
{
    public class FailedEventsQuery : IFailedEventsQuery
    {
        public Dtos.FailedEventData GetFirstFailedEventData()
        {
            return FailedEventsRepository.GetFirstFailedEvent();
        }
    }
}
