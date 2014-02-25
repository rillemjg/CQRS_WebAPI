using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dtos.Additional;
using Repositories;

namespace Queries
{
    public class PaymentQuery : IPaymentQuery
    {
        public PaymentData GetPaymentData(string paymentGuid)
        {
            return PaymentRepository.GetPaymentData(paymentGuid);
        }
    }
}
