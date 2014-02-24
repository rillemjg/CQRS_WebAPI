using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dtos;
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
            var quantityAdditionFailedEventHandler = new QuantityAdditionFailedEventHandler();
            var quantityAddedDbEventHandler = new QuantityAddedDbEventHandler();
            return new ShoppingCart(new EventPublisher(quantityAdditionFailedEventHandler, quantityAddedDbEventHandler),
                shoppingCartElement.ProductId,
                shoppingCartElement.Quantity);
        }
    }
}
