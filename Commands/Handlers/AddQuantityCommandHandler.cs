using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Commands.Commands;
using BusinessProxy;

namespace Commands.Handlers
{ 
    public class AddQuantityCommandHandler : ICommandHandler<AddQuantityCommand>
    {
        public void Handle(AddQuantityCommand command)
        {
            if (command != null)
            {
                var shoppingCart = new BusinessProxy.BusinessProxy().GetShoppingCart(command.ProductId);
                shoppingCart.AddQuantity(command.Quantity);
            }
        }
    }
}
