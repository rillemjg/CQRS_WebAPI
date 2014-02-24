using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dtos;
using Queries;

namespace MvcLearning_WebAPI.Controllers
{
    public class FailedEventsController : ApiController
    {
        // GET api/failedevents
        public FailedEventData Get()
        {
            return new FailedEventsQuery().GetFirstFailedEventData();
        }
    }
}
