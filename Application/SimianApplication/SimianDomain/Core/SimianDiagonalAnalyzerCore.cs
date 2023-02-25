using SimianDomain.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimianDomain.Core
{
    public class SimianDiagonalAnalyzerCore : ISimianAnalyzerCore
    {
        public override int Analyze(string[] DNA, int Occurrences = 0)
        {
            this.Occurrences = Occurrences;

            for (int y = 0; y < DNA[0].Length; y++)
            {
                StringBuilder sequence = new StringBuilder();
                var columnCount = y;
                int row = 0;
                while (row < DNA.Length && columnCount < DNA[0].Length)
                {
                    sequence.Append(DNA[row++][columnCount++]);
                }
                if (SIMIAN_PATTERN.IsMatch(sequence.ToString()))
                {
                    this.Occurrences++;
                }
            }

            for (int x = 0; x < DNA.Length; x++)
            {
                StringBuilder sequence = new StringBuilder();
                var columnCount = 0;
                int row = x;
                while (row < DNA.Length && columnCount < DNA[0].Length)
                {
                    sequence.Append(DNA[row++][columnCount++]);
                }
                if (SIMIAN_PATTERN.IsMatch(sequence.ToString()))
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

