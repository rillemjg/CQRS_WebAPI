using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dtos;
using Dtos.Core;
using Repositories;
using Dtos.Additional;

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

        public IEnumerable<ShoppingCartNamedElement> GetNamedShoppingCartElements()
        {
            var shoppingCartElements = ShoppingCartRepository.GetAllShoppingCartElements();
            var products = ProductRepository.GetAllProducts();

            var namedElements = new List<ShoppingCartNamedElement>();

            if (shoppingCartElements != null && products != null)
            {
                foreach (var shoppingCartElement in shoppingCartElements)
                {
                    var product = products.SingleOrDefault(x => x.Id == shoppingCartElement.ProductId);

                    if (product != null)
                    {
                        namedElements.Add(new ShoppingCartNamedElement() {
                            ProductId = product.Id,
                            ProductName = product.Name,
                            Quantity = shoppingCartElement.Quantity
                        });
                    }
                }
            }

            return namedElements;
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
