using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Events.Events;
using Dtos;
using Repositories;

namespace Events.Handlers
{
    public class QuantityAddedDbEventHandler : IEventHandler<QuantityAddedEvent>
    {
        public void Handle(QuantityAddedEvent eventData)
        {
            ShoppingCartElement shoppingCartElement = ShoppingCartRepository.Get(eventData.ProductId);

            if (shoppingCartElement == null)
            {
                shoppingCartElement = new ShoppingCartElement();
            }

            shoppingCartElement.ProductId = eventData.ProductId;
            shoppingCartElement.Quantity += eventData.AddedQuantity;
            ShoppingCartRepository.Save(shoppingCartElement);
        }
    }
}
