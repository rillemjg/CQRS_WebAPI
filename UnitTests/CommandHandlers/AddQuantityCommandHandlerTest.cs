using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Commands.Commands;
using CommandProxy;
using Queries;
using Repositories;

namespace UnitTests.CommandHandlers
{
    [TestClass]
    public class AddQuantityCommandHandlerTest
    {
        [TestMethod]
        public void HandleTest()
        {
            ShoppingCartRepository.ClearCart();
            var productCommandProxy = new ProductCommandProxy();

            var command = new AddQuantityCommand()
                                             {
                                                 ProductId = 1,
                                                 Quantity = 5
                                             };

            productCommandProxy.Store(command);

            command = new AddQuantityCommand()
                          {
                              ProductId = 2,
                              Quantity = 16
                          };

            productCommandProxy.Store(command);

            command = new AddQuantityCommand()
                          {
                              ProductId = 3,
                              Quantity = 3
                          };

            productCommandProxy.Store(command);

            while(!productCommandProxy.Process())
            {
            }

            List<string> shoppingCartQueryResult = (List<string>)new ShoppingCartQuery().GetAllShoppingCartElements();
            Assert.AreEqual(shoppingCartQueryResult.Count, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void HandleTestWithException()
        {
            ShoppingCartRepository.ClearCart();
            var productCommandProxy = new ProductCommandProxy();

            var command = new AddQuantityCommand()
            {
                ProductId = 0,
                Quantity = 5
            };

            productCommandProxy.Store(command);

            command = new AddQuantityCommand()
            {
                ProductId = 0,
                Quantity = 16
            };

            productCommandProxy.Store(command);

            while (!productCommandProxy.Process())
            {
            }
        }
    }
}
