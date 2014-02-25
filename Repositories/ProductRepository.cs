using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dtos;
using Dtos.Core;

namespace Repositories
{
    public static class ProductRepository
    {
        private static List<Product> productsList;

        static ProductRepository()
        {
            productsList = new List<Product>();
            productsList.Add(new Product { Id = 1, Name = "Coffee", Price = 3 });
            productsList.Add(new Product { Id = 2, Name = "Tea", Price = 3 });
            productsList.Add(new Product { Id = 3, Name = "Bread", Price = 2 });
            productsList.Add(new Product { Id = 4, Name = "Cup", Price = 6 });
        }

        public static List<Product> GetAllProducts()
        {
            return productsList;
        }

        public static Product GetById(int id)
        {
            return productsList.SingleOrDefault(x => x.Id == id);
        }

        public static List<Product> GetByIds(List<int> ids)
        {
            return productsList.Where(x => ids.Contains(x.Id)).ToList();
        }
    }
}
