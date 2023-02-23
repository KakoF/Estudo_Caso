using Domain.DTO;
using Domain.Interfaces.Services;
using Domain.Abstractions;
using Microsoft.Extensions.Logging;

namespace Service.Services
{
    public class SimianService : ISimianService
    {
        private readonly ILogger<SimianService> _logger;
        private readonly ISimianPatternsExecute _patternsExecute;
        
       
        public SimianService(ILogger<SimianService> logger, ISimianPatternsExecute patternsExecute)
        {
            _logger = logger;
            _patternsExecute = patternsExecute;
        }
        public SimianResponseDTO VerifyDna(SimianRequestDTO data)
        {
            var result = _patternsExecute.Execute(data.Dna);
            return new SimianResponseDTO(result.Where(x => x.Equals(true)).Count() >= 2);
        } 
        
    }
}
