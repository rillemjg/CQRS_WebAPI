using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.SessionState;
using CommandProxy;
using Commands.Commands;
using Dtos;
using Dtos.Core;
using Queries;

namespace MvcLearning_WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private static ProductCommandProxy commandProxy = new ProductCommandProxy(); 

        // GET api/products
        public IEnumerable<Product> GetProducts()
        {
            return new ShoppingCartQuery().GetAllProducts();
        }

        // GET api/products/5
        public Product Get(int id)
        {
            var product = new ShoppingCartQuery().GetProduct(id);

            if (product == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            return product;
        }

        // POST api/products
        public void Post(ShoppingCartElement cartElement)
        {
            if (cartElement != null)
            {
                var command = new AddQuantityCommand();
                command.ProductId = cartElement.ProductId;
                command.Quantity = cartElement.Quantity;
                commandProxy.Store(command);
                commandProxy.Process();
            }
        }

        //// PUT api/products/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/products/5
        //public void Delete(int id)
        //{
        //}
    }
}
