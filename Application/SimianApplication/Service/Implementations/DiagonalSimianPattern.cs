using Domain.Abstractions;
using Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Service.Services;
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
        public override bool CheckPattern(string[] dna)
        {
            bool isSimian = false;
            for (int x = dna.Length - 1; x >= 0 && !isSimian; x--)
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
                    if (DefaultPattern.IsMatch(sequence.ToString()))
                    {
                        isSimian = true;
                        break;
                    }
                }
            }
            for (int x = dna.Length - 1; x >= 0 && !isSimian; x--)
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
                    if (DefaultPattern.IsMatch(sequence.ToString()))
                    {
                        isSimian = true;
                        break;
                    }
                }
            }
            _logger.LogWarning("Resultado analise {0}: {1}", string.Join(",", dna), isSimian);
            return isSimian;
        }
    }
}
