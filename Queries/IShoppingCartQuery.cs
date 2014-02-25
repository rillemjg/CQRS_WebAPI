using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dtos;
using Dtos.Core;
using Dtos.Additional;

namespace Queries
{
    public interface IShoppingCartQuery
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProduct(int id);

        IEnumerable<ShoppingCartNamedElement> GetNamedShoppingCartElements();

        string GetShoppingCartElement(int productId);

        IEnumerable<int> GetFullCartElementsIds();
    }
}
