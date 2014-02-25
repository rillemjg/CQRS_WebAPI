using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dtos.Additional;

namespace Repositories
{
    public static class PaymentRepository
    {
        private static List<PaymentData> paymentDataList;

        static PaymentRepository()
        {
            paymentDataList = new List<PaymentData>();
        }

        public static PaymentData GetPaymentData(string guid)
        {
            return paymentDataList.SingleOrDefault(x => x.PaymentGuid == guid);
        }

        public static void AddOrReplacePaymentData(PaymentData data)
        {
            paymentDataList.RemoveAll(x => x.PaymentGuid == data.PaymentGuid);

            var repositoryPaymentData = new PaymentData();
            repositoryPaymentData.PaymentGuid = data.PaymentGuid;
            repositoryPaymentData.Message = data.Message;
            repositoryPaymentData.PaymentStatus = data.PaymentStatus;
            paymentDataList.Add(repositoryPaymentData);
        }
    }
}
