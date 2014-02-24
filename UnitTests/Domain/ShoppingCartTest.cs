using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using UnitTests.Infrastructure;

namespace UnitTests.Domain
{
    [TestClass]
    public class ShoppingCartTest
    {
        [TestMethod]
        public void AddQuantitySuccessTest()
        {
            var testEventPublisher = new TestEventPublisher();
            var shoppingCart = new ShoppingCart(testEventPublisher, 13, 0);
            shoppingCart.AddQuantity(15);
            Assert.IsTrue(testEventPublisher.SuccessEvents.Count == 1);
            Assert.IsTrue(testEventPublisher.FailedEvents.Count == 0);
            Assert.IsTrue(testEventPublisher.SuccessEvents[0].ProductId == 13);
            Assert.IsTrue(testEventPublisher.SuccessEvents[0].AddedQuantity == 15);
        }

        [TestMethod]
        public void AddQuantityTooManyItemsTest()
        {
            var testEventPublisher = new TestEventPublisher();
            var shoppingCart = new ShoppingCart(testEventPublisher, 13, 10);
            shoppingCart.AddQuantity(15);
            Assert.IsTrue(testEventPublisher.SuccessEvents.Count == 0);
            Assert.IsTrue(testEventPublisher.FailedEvents.Count == 1);
            Assert.IsTrue(testEventPublisher.FailedEvents[0].ProductId == 13);
        }

        [TestMethod]
        public void AddQuantityNegativeValueTest()
        {
            var testEventPublisher = new TestEventPublisher();
            var shoppingCart = new ShoppingCart(testEventPublisher, 13, 4);
            shoppingCart.AddQuantity(-9);
            Assert.IsTrue(testEventPublisher.SuccessEvents.Count == 0);
            Assert.IsTrue(testEventPublisher.FailedEvents.Count == 1);
            Assert.IsTrue(testEventPublisher.FailedEvents[0].ProductId == 13);
        }
    }
}
