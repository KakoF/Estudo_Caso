using Domain.DTO.IsSimianDTO;
using Domain.DTO.StatsDTO;
using Domain.Entities;
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
        public async Task<IEnumerable<SimianCalcEntity>> List()
        {
            return await _service.GetAsync();
        }
    }
}