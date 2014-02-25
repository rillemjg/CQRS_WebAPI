using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Commands.Commands;

namespace Commands.Handlers
{
    public class ClearShoppingCartCommandHandler : ICommandHandler<ClearShoppingCartCommand>
    {
        public void Handle(ClearShoppingCartCommand command)
        {
            if (command != null)
            {
                var shoppingCart = new BusinessProxy.BusinessProxy().GetShoppingCart(0);
                shoppingCart.ClearShoppingCart();
            }
        }
    }
}
