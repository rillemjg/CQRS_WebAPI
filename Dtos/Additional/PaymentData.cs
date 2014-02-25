using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dtos.Infrastructure;

namespace Dtos.Additional
{
    public class PaymentData
    {
        public string PaymentGuid { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string Message { get; set; }
    }
}
