using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dtos;
using Dtos.Core;
using Repositories;
using Domain;
using Events;
using Events.Handlers;

namespace BusinessProxy
{
    public class BusinessProxy
    {
        public ShoppingCart GetShoppingCart(int productId)
        {
            var shoppingCartElement = ShoppingCartRepository.Get(productId);

            if (shoppingCartElement == null)
            {
                shoppingCartElement = new ShoppingCartElement();
                shoppingCartElement.ProductId = productId;
                shoppingCartElement.Quantity = 0;
            }

            var quantityAdditionFailedEventHandler = new QuantityAdditionFailedEventHandler();
            var quantityAddedDbEventHandler = new QuantityAddedDbEventHandler();
            var clearShoppingCartEventHandler = new ClearShoppingCartEventHandler();
            return new ShoppingCart(new EventPublisher(quantityAdditionFailedEventHandler, quantityAddedDbEventHandler, clearShoppingCartEventHandler),
                shoppingCartElement.ProductId,
                shoppingCartElement.Quantity);
        }

        public Payment GetPayment(List<int> productIds, string paymentGuid)
        {
            var products = ProductRepository.GetByIds(productIds);
            var paymentSucceededEventHandler = new PaymentSucceededEventHandler();
            var paymentFailedEventHandler = new PaymentFailedEventHandler();
            var paymentBeginEventHandler = new PaymentBeginEventHandler();

            return new Payment(new PaymentEventPublisher(paymentSucceededEventHandler, paymentFailedEventHandler, paymentBeginEventHandler),
                products, paymentGuid);
        }
    }
}
