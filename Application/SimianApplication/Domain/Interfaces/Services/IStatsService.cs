using Domain.DTO.StatsDTO;
using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IStatsService
    {
        public Task<StatsResponseDTO> GetStatsAsync();
        public Task<IEnumerable<SimianCalcEntity>> GetAsync();
    }
}
