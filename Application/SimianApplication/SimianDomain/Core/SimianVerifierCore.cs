using SimianDomain.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimianDomain.Core
{
    public class SimianVerifierCore : ISimianVerifierCore
    {
        
        public Task<bool> VerifyAsync(string[] DNA)
        {
            ISimianAnalyzerCore linear = new SimianLinearAnalyzerCore();
            ISimianAnalyzerCore column = new SimianColumnAnalyzerCore();
            ISimianAnalyzerCore diagonal = new SimianDiagonalAnalyzerCore();
            ISimianAnalyzerCore diagonalReverse = new SimianDiagonalReverseAnalyzerCore();

            diagonal.SetNextAnalyzer(diagonalReverse);
            column.SetNextAnalyzer(diagonal);
            linear.SetNextAnalyzer(column);

            int count = linear.Analyze(DNA);

            return Task.FromResult(count > 1);
       }
    }
}
