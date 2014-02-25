using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dtos;
using Dtos.Core;

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
            return cartElements.SingleOrDefault(x => x.ProductId == productId);
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
