using Domain.DTO.SimianCalcDTO;
using Domain.DTO.StatsDTO;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace SimianApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatsController : ControllerBase
    {
        private readonly IStatsService _service;

        public StatsController(IStatsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<StatsResponseDTO> Get()
        {
            return await _service.GetStatsAsync();
        }

        [HttpGet]
        [Route("List")]
        public async Task<IEnumerable<SimianCalcResponseDTO>> List()
        {
            return await _service.GetAsync();
        }
    }
}