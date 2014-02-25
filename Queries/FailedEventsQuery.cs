using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dtos.Additional;
using Repositories;

namespace Queries
{
    public class FailedEventsQuery : IFailedEventsQuery
    {
        public FailedEventData GetFirstFailedEventData()
        {
            return FailedEventsRepository.GetFirstFailedEvent();
        }
    }
}
