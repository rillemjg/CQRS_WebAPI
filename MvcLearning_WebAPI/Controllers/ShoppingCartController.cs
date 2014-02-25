using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CommandProxy;
using Dtos;
using Dtos.Core;
using Queries;
using Dtos.Additional;
using Commands.Commands;
using MvcLearning_WebAPI.ViewModels;

namespace MvcLearning_WebAPI.Controllers
{
    public class ShoppingCartController : ApiController
    {
        private static ProductCommandProxy commandProxy = new ProductCommandProxy(); 

        // GET api/shoppingcart
        public IEnumerable<ShoppingCartNamedElement> GetNamedShoppingCartElements()
        {
            return new ShoppingCartQuery().GetNamedShoppingCartElements();
        }

        public IEnumerable<int> GetFullCartElements()
        {
            return new ShoppingCartQuery().GetFullCartElementsIds();
        }

        public void ClearShoppingCart()
        {
            var command = new ClearShoppingCartCommand();
            commandProxy.Store(command);
            commandProxy.Process();
        }

        // POST api/shoppingcart
        public void Post([FromBody]ShoppingCartWithGuidViewModel viewModel)
        {
            if (viewModel != null)
            {
                var command = new PerformPaymentCommand();
                command.ShoppingCartNamedElements = viewModel.ShoppingCartElements;
                command.Guid = viewModel.Guid;
                commandProxy.Store(command);
                commandProxy.Process();
            }
        }

        public PaymentData GetPaymentData(string id)
        {
            return new PaymentQuery().GetPaymentData(id);
        }

        //// PUT api/shoppingcart/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/shoppingcart/5
        //public void Delete(int id)
        //{
        //}
    }
}
