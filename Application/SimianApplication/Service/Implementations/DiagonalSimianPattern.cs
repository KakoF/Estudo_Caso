using Domain.Abstractions;

namespace Service.Implementations
{
    public class DiagonalSimianPattern : SimianPatternAbstract
    {
        public DiagonalSimianPattern() : base() { }
        public override bool CheckPattern(string[] dna)
        {
            return true;
        }
    }
}
