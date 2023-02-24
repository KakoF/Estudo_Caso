using Domain.Abstractions;
using Domain.Interfaces.Services;
using System.Text;

namespace Service.Implementations
{
    public class DiagonalSimianPattern : SimianPatternAbstract
    {
        public DiagonalSimianPattern() : base() { }
        public override bool CheckPattern(string[] dna)
        {
            bool isSimian = false;
            for (int x = dna.Length - 1; x >= 0 && !isSimian; x--)
            {
                for (int y = dna[x].Length - 1; y >= 0; y--)
                {
                    StringBuilder sequence = new StringBuilder();
                    var columnCount = y;
                    int row = x;
                    while (row < dna.Length && columnCount >= 0)
                    {
                        sequence.Append(dna[row++][columnCount--]);
                    }
                    if (DefaultPattern.IsMatch(sequence.ToString()))
                    {
                        isSimian = true;
                        break;
                    }
                }
            }
            for (int x = dna.Length - 1; x >= 0 && !isSimian; x--)
            {
                for (int y = dna[x].Length - 1; y >= 0; y--)
                {
                    StringBuilder sequence = new StringBuilder();
                    var columnCount = y;
                    int row = x;
                    while (row < dna.Length && columnCount >= 0)
                    {
                        sequence.Append(dna[row++][columnCount--]);
                    }
                    if (DefaultPattern.IsMatch(sequence.ToString()))
                    {
                        isSimian = true;
                        break;
                    }
                }
            }
            return isSimian;
        }
    }
}
