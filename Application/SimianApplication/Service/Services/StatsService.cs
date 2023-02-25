using Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Domain.Interfaces.Repositories;
using Domain.Entities;
using Domain.DTO.IsSimianDTO;
using Domain.DTO.StatsDTO;

namespace Service.Services
{
    public class StatsService : IStatsService
    {
        private readonly ILogger<StatsService> _logger;
        private readonly ISimianCalcRepository _repository;

        public StatsService(ILogger<StatsService> logger, ISimianCalcRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<StatsResponseDTO> GetStatsAsync()
        {
            var simianCalc = await _repository.GetAsync();
            return new StatsResponseDTO(simianCalc.CountIsSimian, simianCalc.CountIsHuman, simianCalc.Ratio);
        }
        
    }
}
