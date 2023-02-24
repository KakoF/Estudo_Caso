using Domain.Abstractions;
using Domain.Interfaces.Services;

namespace Service.Implementations
{
    public class HorizontalSimianPattern : SimianPatternAbstract
    {
        public HorizontalSimianPattern() : base(){}

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
            return isSimian;
        }
    }
}
