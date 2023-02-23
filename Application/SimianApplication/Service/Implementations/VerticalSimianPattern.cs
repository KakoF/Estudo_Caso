using Domain.Abstractions;

namespace Service.Implementations
{
    public class VerticalSimianPattern : SimianPatternAbstract
    {
        public VerticalSimianPattern() : base() { }

        public override bool CheckPattern(string[] dna)
        {
            return true;
        }
    }
}
