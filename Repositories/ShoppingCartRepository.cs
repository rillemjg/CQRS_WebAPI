using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dtos;

namespace Repositories
{
    public static class ShoppingCartRepository
    {
        private static List<ShoppingCartElement> cartElements;

        static ShoppingCartRepository()
        {
            cartElements = new List<ShoppingCartElement>();
        }

        public static ShoppingCartElement Get(int productId)
        {
            var element = cartElements.SingleOrDefault(x => x.ProductId == productId);

            if (element == null)
            {
                element = new ShoppingCartElement()
                              {
                                  ProductId = productId,
                                  Quantity = 0
                              };
                cartElements.Add(element);
            }

            return element;
        }

        public static IEnumerable<ShoppingCartElement> GetAllShoppingCartElements()
        {
            return cartElements;
        }

        public static void Save(ShoppingCartElement element)
        {
            cartElements.RemoveAll(x => x.ProductId == element.ProductId);
            cartElements.Add(element);
        }

        public static void ClearCart()
        {
            cartElements = new List<ShoppingCartElement>();
        }
    }
}
