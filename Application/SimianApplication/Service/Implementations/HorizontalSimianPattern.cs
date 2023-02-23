using Domain.Abstractions;

namespace Service.Implementations
{
    public class HorizontalSimianPattern : SimianPatternAbstract
    {
        public override string[] DefaultPattern => throw new NotImplementedException();

        public override bool CheckPattern(string[] dna)
        {
            return false;
        }
    }
}
