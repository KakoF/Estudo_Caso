using Domain.Abstractions;
using Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace Service.Implementations
{
    public class HorizontalSimianPattern : SimianPatternAbstract
    {
        private readonly ILogger<HorizontalSimianPattern> _logger;
        public HorizontalSimianPattern(ILogger<HorizontalSimianPattern> logger) : base()
        {
            _logger = logger;
        }

        public override bool CheckPattern(string[] dna)
        {
            bool isSimian = false;
            foreach (var row in dna)
            {
                if (DefaultPattern.IsMatch(row))
                {
                    isSimian = true;
                    break;
                }
            }
            _logger.LogWarning("Resultado analise {0}: {1}", string.Join(",", dna), isSimian);
            return isSimian;
        }
    }
}
