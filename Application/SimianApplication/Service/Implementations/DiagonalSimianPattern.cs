using Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class DiagonalSimianPattern : SimianPatternAbstract
    {
        public override string[] DefaultPattern => throw new NotImplementedException();

        public override bool CheckPattern(string[] dna)
        {
            return false;
        }
    }
}
