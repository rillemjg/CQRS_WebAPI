using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dtos.Additional;

namespace Commands.Commands
{
    public class PerformPaymentCommand : ICommand
    {
        public List<ShoppingCartNamedElement> ShoppingCartNamedElements { get; set; }
        public string Guid { get; set; }
    }
}
