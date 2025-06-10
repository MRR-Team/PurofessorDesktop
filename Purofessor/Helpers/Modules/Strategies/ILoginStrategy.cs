using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purofessor.Helpers.Modules.Strategies
{
    internal interface ILoginStrategy
    {
            Task<string?> LoginAsync();
    }
}
