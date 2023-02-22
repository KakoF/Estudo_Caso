using SimianDomain.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimianDomain.Core
{
    public class SimianVerifierCore : ISimianVerifierCore
    {
        private readonly Regex SIMIAN_PATTERN = new Regex(@"(aaaa|cccc|tttt|gggg)", RegexOptions.IgnoreCase);
        public Task<bool> VerifyAsync(string[] DNA)
        {
            bool isSimian = false; 
            //Linear
            foreach (var row in DNA)
            {
                if (SIMIAN_PATTERN.IsMatch(row)) {
                    isSimian = true;
                    break;
                }
            }
            //Column
            for (int y = 0; y < DNA[0].Length && !isSimian; y++)
            {
                StringBuilder column = new StringBuilder();
                foreach (var row in DNA)
                {
                    column.Append(row[y]);
                }
                if (SIMIAN_PATTERN.IsMatch(column.ToString()))
                {
                    isSimian = true;
                    break;
                }
            }
            //Diagonal
            for (int x = 0; x < DNA.Length && !isSimian; x++) 
            {
                for (int y = 0; y < DNA[x].Length; y++)
                {
                    StringBuilder sequence = new StringBuilder();
                    var columnCount = y;
                    int row = x;
                    while (row < DNA.Length && columnCount < DNA[x].Length)
                    {
                        sequence.Append(DNA[row++][columnCount++]);
                    }
                    if (SIMIAN_PATTERN.IsMatch(sequence.ToString()))
                    {
                        isSimian = true;
                        break;
                    }
                }
            }
            //Diagonal Reverse
            for (int x = DNA.Length - 1; x >= 0 && !isSimian; x--)
            {
                for (int y = DNA[x].Length -1 ; y >= 0; y--)
                {
                    StringBuilder sequence = new StringBuilder();
                    var columnCount = y;
                    int row = x;
                    while (row < DNA.Length && columnCount >= 0)
                    {
                        sequence.Append(DNA[row++][columnCount--]);
                    }
                    if (SIMIAN_PATTERN.IsMatch(sequence.ToString()))
                    {
                        isSimian = true;
                        break;
                    }
                }
            }

            return Task.FromResult(isSimian);
       }
    }
}
