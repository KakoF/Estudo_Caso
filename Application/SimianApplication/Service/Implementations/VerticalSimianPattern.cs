using Service.Abstractions;

namespace Service.Implementations
{
    public class VerticalSimianPattern : SimianPatternAbstract
    {
        public override string[] DefaultPattern => throw new NotImplementedException();

        public override bool CheckPattern(string[] dna)
        {
            return true;
        }
    }
}
