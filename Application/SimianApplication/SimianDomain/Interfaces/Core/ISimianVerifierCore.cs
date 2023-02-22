using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimianDomain.Interfaces.Core
{
    public interface ISimianVerifierCore
    {
        public Task<bool> VerifyAsync(string[] DNA);
    }
}
