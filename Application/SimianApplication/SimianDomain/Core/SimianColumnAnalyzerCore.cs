using SimianDomain.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimianDomain.Core
{
    public class SimianColumnAnalyzerCore : ISimianAnalyzerCore
    {
        public override int Analyze(string[] DNA, int Occurrences = 0)
        {
            this.Occurrences = Occurrences;
            for (int y = 0; y < DNA[0].Length ; y++)
            {
                StringBuilder column = new StringBuilder();
                foreach (var row in DNA)
                {
                    column.Append(row[y]);
                }
                if (SIMIAN_PATTERN.IsMatch(column.ToString()))
                {
                    this.Occurrences++;
                }
            }
            if (this.NextAnalyzer != null)
            {
                return NextAnalyzer.Analyze(DNA, this.Occurrences);
            }
            return this.Occurrences;
        }
    }
}
