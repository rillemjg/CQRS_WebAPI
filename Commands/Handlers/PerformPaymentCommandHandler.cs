using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Commands.Commands;

namespace Commands.Handlers
{
    public class PerformPaymentCommandHandler : ICommandHandler<PerformPaymentCommand>
    {
        public void Handle(PerformPaymentCommand command)
        {
            if (command != null)
            {
                var payment = new BusinessProxy.BusinessProxy()
                    .GetPayment(command.ShoppingCartNamedElements
                        .Select(x => x.ProductId).ToList(),
                        command.Guid
                    );

                payment.ProcessPayment(command.ShoppingCartNamedElements);
            }
        }
    }
}
