using Domain.Interfaces.Services;

namespace Domain.Abstractions
{
    public abstract class SimianPatternAbstract : ISimianPattern
    {
        public abstract string[] DefaultPattern { get; }

        public abstract bool CheckPattern(string[] dna);

    }
}

