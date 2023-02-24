using Domain.DTO;
using Domain.Interfaces.Services;
using Domain.Abstractions;
using Microsoft.Extensions.Logging;
using Domain.Interfaces.Repositories;
using Domain.Entities;

namespace Service.Services
{
    public class SimianService : ISimianService
    {
        private readonly ILogger<SimianService> _logger;
        private readonly ISimianPatternsExecute _patternsExecute;
        private readonly ISimianRepository _repository;
        
       
        public SimianService(ILogger<SimianService> logger, ISimianPatternsExecute patternsExecute, ISimianRepository repository)
        {
            _logger = logger;
            _patternsExecute = patternsExecute;
            _repository = repository;
        }
        public async Task<SimianResponseDTO> VerifyDna(SimianRequestDTO data)
        {
            var result = _patternsExecute.Execute(data.Dna);
            var simian = new SimianEntity(string.Join(",", data.Dna), result.Where(x => x.Equals(true)).Count() >= 2);
            await _repository.Create(simian);
            return new SimianResponseDTO(simian.IsSimian);
        } 
        
    }
}
