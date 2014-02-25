using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dtos.Additional;

namespace Queries
{
    public interface IPaymentQuery
    {
        PaymentData GetPaymentData(string paymentGuid);
    }
}
