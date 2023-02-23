using Domain.Interfaces.Services;
using System.Text.RegularExpressions;

namespace Domain.Abstractions
{
    public abstract class SimianPatternAbstract : ISimianPattern
    {
        protected readonly Regex DefaultPattern;

        public SimianPatternAbstract()
        {
            DefaultPattern = new Regex(@"(aaaa|cccc|tttt|gggg)", RegexOptions.IgnoreCase);
        }

        public abstract bool CheckPattern(string[] dna);

    }
}

