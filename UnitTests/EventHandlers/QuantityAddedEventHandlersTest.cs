using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dtos.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Events.Events;
using Events.Handlers;
using Dtos;
using Repositories;

namespace UnitTests.EventHandlers
{
    [TestClass]
    public class QuantityAddedEventHandlersTest
    {
        [TestMethod]
        public void QuantityAddedDbEventHandlerTest()
        {
            ShoppingCartRepository.ClearCart();

            var quantityAddedEvent = new QuantityAddedEvent()
                                         {
                                             AddedQuantity = 5,
                                             ProductId = 2
                                         };

            var quantityAddedDbEventHandler = new QuantityAddedDbEventHandler();
            quantityAddedDbEventHandler.Handle(quantityAddedEvent);

            var repositoryResult = (List<ShoppingCartElement>)ShoppingCartRepository.GetAllShoppingCartElements();
            Assert.AreEqual(repositoryResult.Count, 1);
        }
    }
}
