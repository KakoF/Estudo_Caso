using Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Domain.Interfaces.Repositories;
using Domain.Entities;
using Domain.DTO.IsSimianDTO;

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
        public async Task<IsSimianResponseDTO> VerifyDnaAsync(IsSimianRequestDTO data)
        {
            _logger.LogWarning("Inicio de analise do Dna: {0}", string.Join(",", data.Dna));
            var isSimian = _patternsExecute.Execute(data.Dna).Where(x => x.Equals(true)).Count() >= 2;
            var simian = new SimianEntity(string.Join(",", data.Dna), isSimian);
            await _repository.CreateAsync(simian);
            return new IsSimianResponseDTO(simian.IsSimian);
        } 
        
    }
}
