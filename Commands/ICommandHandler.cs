using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T command);
    }
}
