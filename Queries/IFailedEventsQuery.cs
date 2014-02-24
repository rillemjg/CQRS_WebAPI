using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dtos;

namespace Queries
{
    public interface IFailedEventsQuery
    {
        FailedEventData GetFirstFailedEventData();
    }
}
