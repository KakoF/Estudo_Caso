using SimianDomain.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimianDomain.Core
{
    public class SimianLinearAnalyzerCore : ISimianAnalyzerCore
    {
        public override int Analyze(string[] DNA, int Occurrences = 0)
        {
            this.Occurrences = Occurrences;
            foreach (var row in DNA)
            {
                if (SIMIAN_PATTERN.IsMatch(row))
                {
                    this.Occurrences++;
                }
            }
            if (this.NextAnalyzer != null) { 
                return NextAnalyzer.Analyze(DNA, this.Occurrences);
            }
            return this.Occurrences;
        }
    }
}
