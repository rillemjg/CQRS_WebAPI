using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dtos;

namespace Repositories
{
    public static class ProductRepository
    {
        private static List<Product> productsList;

        static ProductRepository()
        {
            productsList = new List<Product>();
            productsList.Add(new Product { Id = 1, Name = "Coffee" });
            productsList.Add(new Product { Id = 2, Name = "Tea" });
            productsList.Add(new Product { Id = 3, Name = "Bread" });
            productsList.Add(new Product { Id = 4, Name = "Cup" });
        }

        public static List<Product> GetAllProducts()
        {
            return productsList;
        }

        public static Product GetById(int id)
        {
            return productsList.SingleOrDefault(x => x.Id == id);
        }
    }
}
