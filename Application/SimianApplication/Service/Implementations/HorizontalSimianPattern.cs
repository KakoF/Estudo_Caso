using Domain.Abstractions;

namespace Service.Implementations
{
    public class HorizontalSimianPattern : SimianPatternAbstract
    {
        public HorizontalSimianPattern() : base(){}

        public override bool CheckPattern(string[] dna)
        {
            return false;
        }
    }
}
