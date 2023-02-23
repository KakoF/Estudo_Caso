using Domain.DTO;
using Domain.Interfaces.Services;
using Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SimianDnaVerifyService : ISimianDnaVerifyService
    {
        private readonly IEnumerable<SimianPatternAbstract> _simianPatterns;
        public SimianDnaVerifyService(IEnumerable<SimianPatternAbstract> simianPatterns)
        {
            _simianPatterns = typeof(SimianPatternAbstract).Assembly.GetTypes()
            .Where(t => t.IsSubclassOf(typeof(SimianPatternAbstract)) && !t.IsAbstract)
            .Select(t => (SimianPatternAbstract?)Activator.CreateInstance(t));
        }
        public SimianResponseDTO Verify(SimianRequestDTO data)
        {
            var result = IsSimian(data);
            return new SimianResponseDTO(result.Where(x => x.Equals(true)).Count() >= 2);
        } 
        private IEnumerable<bool> IsSimian(SimianRequestDTO data)
        {
            foreach (var pattern in _simianPatterns)
            {
                yield return pattern.CheckPattern(data.Dna);
            }
            
        }
    }
}
