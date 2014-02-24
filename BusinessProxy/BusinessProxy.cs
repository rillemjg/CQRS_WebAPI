using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dtos;
using Repositories;
using Domain;

namespace BusinessProxy
{
    public class BusinessProxy
    {
        public ShoppingCart GetShoppingCart(int productId)
        {
            var shoppingCartElement = ShoppingCartRepository.Get(productId);
            return new ShoppingCart(shoppingCartElement.ProductId, shoppingCartElement.Quantity);
        }
    }
}
