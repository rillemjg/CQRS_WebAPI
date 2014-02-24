using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dtos;
using Repositories;

namespace Queries
{
    public class ShoppingCartQuery : IShoppingCartQuery
    {
        public IEnumerable<Product> GetAllProducts()
        {
            return ProductRepository.GetAllProducts();
        }

        public Product GetProduct(int id)
        {
            return ProductRepository.GetById(id);
        }

        public IEnumerable<string> GetAllShoppingCartElements()
        {
            List<string> elements = new List<string>();

            var repositoryElements = ShoppingCartRepository.GetAllShoppingCartElements();

            foreach (var shoppingCartElement in repositoryElements)
            {
                var repositoryProduct = ProductRepository.GetById(shoppingCartElement.ProductId);

                if (repositoryProduct != null)
                {
                    elements.Add(repositoryProduct.Name + ": " + shoppingCartElement.Quantity);
                }
            }

            return elements;
        }

        public string GetShoppingCartElement(int productId)
        {
            var product = ProductRepository.GetById(productId);

            if (product == null)
            {
                return "";
            }

            var shoppingCartElement = ShoppingCartRepository.Get(productId);

            if (shoppingCartElement == null)
            {
                return "";
            }

            return product.Name + ": " + shoppingCartElement.Quantity;
        }

        public bool IsCartFullOfProduct(int productId)
        {
            var shoppingCartElement = ShoppingCartRepository.Get(productId);
            return shoppingCartElement.Quantity >= 20;
        }


        public IEnumerable<int> GetFullCartElementsIds()
        {
            return
                ShoppingCartRepository.GetAllShoppingCartElements().Where(x => x.Quantity == 20).Select(z => z.ProductId);
        }
    }
}
