using Domain.Abstractions;
using Microsoft.Extensions.Logging;
using System.Text;

namespace Service.Implementations
{
    public class DiagonalSimianPattern : SimianPatternAbstract
    {
        private readonly ILogger<DiagonalSimianPattern> _logger;
        public DiagonalSimianPattern(ILogger<DiagonalSimianPattern> logger) : base()
        {
            _logger = logger;
        }
        public override bool[] CheckPattern(string[] dna)
        {

            bool[] isSimian = new bool[dna.Length];
            for (int x = dna.Length - 1; x >= 0; x--)
            {
                for (int y = dna[x].Length - 1; y >= 0; y--)
                {
                    StringBuilder sequence = new StringBuilder();
                    var columnCount = y;
                    int row = x;
                    while (row < dna.Length && columnCount >= 0)
                    {
                        sequence.Append(dna[row++][columnCount--]);
                    }
                    isSimian[x] = DefaultPattern.IsMatch(sequence.ToString());
                }
            }
            for (int x = dna.Length - 1; x >= 0; x--)
            {
                for (int y = dna[x].Length - 1; y >= 0; y--)
                {
                    StringBuilder sequence = new StringBuilder();
                    var columnCount = y;
                    int row = x;
                    while (row < dna.Length && columnCount >= 0)
                    {
                        sequence.Append(dna[row++][columnCount--]);
                    }
                    isSimian[x] = DefaultPattern.IsMatch(sequence.ToString());
                }
            }
            _logger.LogWarning("Resultado analise {0}: {1}", string.Join(",", dna), isSimian);
            return isSimian;
        }
    }
}
