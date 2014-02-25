using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Events.Events;
using Repositories;

namespace Events.Handlers
{
    public class ClearShoppingCartEventHandler : IEventHandler<ClearShoppingCartEvent>
    {
        public void Handle(ClearShoppingCartEvent eventData)
        {
            ShoppingCartRepository.ClearCart();
        }
    }
}
