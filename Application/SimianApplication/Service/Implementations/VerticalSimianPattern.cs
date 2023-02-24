using Domain.Abstractions;
using Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using System.Text;

namespace Service.Implementations
{
    public class VerticalSimianPattern : SimianPatternAbstract
    {
        private readonly ILogger<VerticalSimianPattern> _logger;
        public VerticalSimianPattern(ILogger<VerticalSimianPattern> logger) : base()
        {
            _logger = logger;
        }

        public override bool CheckPattern(string[] dna)
        {
            bool isSimian = false;
            for (int y = 0; y < dna[0].Length && !isSimian; y++)
            {
                StringBuilder column = new StringBuilder();
                foreach (var row in dna)
                {
                    column.Append(row[y]);
                }
                if (DefaultPattern.IsMatch(column.ToString()))
                {
                    isSimian = true;
                    break;
                }
            }
            _logger.LogWarning("Resultado analise {0}: {1}", string.Join(",", dna) , isSimian);
            return isSimian;
        }
    }
}
