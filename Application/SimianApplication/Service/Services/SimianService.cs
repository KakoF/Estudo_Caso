using Domain.DTO;
using Domain.Interfaces.Services;
using Domain.Abstractions;

namespace Service.Services
{
    public class SimianService : ISimianService
    {
        private readonly IEnumerable<SimianPatternAbstract> _simianPatterns;
        public SimianService(IEnumerable<SimianPatternAbstract> simianPatterns)
        {
            _simianPatterns = typeof(SimianPatternAbstract).Assembly.GetTypes()
            .Where(t => t.IsSubclassOf(typeof(SimianPatternAbstract)) && !t.IsAbstract)
            .Select(t => (SimianPatternAbstract)Activator.CreateInstance(t));
        }
        public SimianResponseDTO VerifyDna(SimianRequestDTO data)
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
