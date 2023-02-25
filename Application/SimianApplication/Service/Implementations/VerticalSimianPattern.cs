using Domain.Abstractions;
using Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System;
using System.Data.Common;
using System.Reflection;
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
            foreach (var step in dna.OrderByDescending(s => s.Length).First().Select((value, index) => new { index, value }))
            {
                string joinedDna = string.Join("", dna.Select(s => string.IsNullOrEmpty(s) ? "" : s.Substring(step.index, 1)));
                if (DefaultPattern.IsMatch(joinedDna))
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
