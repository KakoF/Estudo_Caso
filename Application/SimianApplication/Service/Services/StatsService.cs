using Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Domain.Interfaces.Repositories;
using Domain.Entities;
using Domain.DTO.StatsDTO;
using Domain.Interfaces.Cache;
using Domain.DTO.SimianCalcDTO;

namespace Service.Services
{
    public class StatsService : IStatsService
    {
        private readonly ILogger<StatsService> _logger;
        private readonly ISimianCalcRepository _repository;
        private readonly ICacheMethods _cahceMetods;

        public StatsService(ILogger<StatsService> logger, ISimianCalcRepository repository, ICacheMethods cacheMethods)
        {
            _logger = logger;
            _repository = repository;
            _cahceMetods = cacheMethods;
        }

        public async Task<StatsResponseDTO> GetStatsAsync()
        {
            var simianCalc = await _repository.GetAsync();
            return new StatsResponseDTO(simianCalc.CountIsSimian, simianCalc.CountIsHuman, simianCalc.Ratio);
        }

        public async Task<IEnumerable<SimianCalcResponseDTO>> GetAsync()
        {
            var data = (await _cahceMetods.GetOrCreateAsync("List_SimianCalcEntity", async () => await _repository.GetAllAsync())).ListDTO();
            return data;
            
        }

    }
}
