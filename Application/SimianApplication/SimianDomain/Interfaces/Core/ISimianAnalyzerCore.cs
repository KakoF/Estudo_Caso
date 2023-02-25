using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimianDomain.Interfaces.Core
{
    public abstract class ISimianAnalyzerCore
    {
        protected readonly Regex SIMIAN_PATTERN = new Regex(@"(a{4}|c{4}|t{4}|g{4})", RegexOptions.IgnoreCase);
        protected int Occurrences { get; set; }
        protected ISimianAnalyzerCore NextAnalyzer { get; set; }

        public abstract int Analyze(string[] DNA, int Occurrences = 0);
        public void SetNextAnalyzer(ISimianAnalyzerCore nextAnalyzer)
        {
            this.NextAnalyzer = nextAnalyzer;
        }
    }
}
