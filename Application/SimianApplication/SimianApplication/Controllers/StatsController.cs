using Domain.DTO.StatsDTO;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Prometheus;

namespace SimianApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatsController : ControllerBase
    {
        private readonly IStatsService _service;
        Counter counter = Metrics.CreateCounter("teste_contador", "StatsController");

        public StatsController(IStatsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<StatsResponseDTO> Get()
        {
            counter.Inc();
            return await _service.GetStatsAsync();
        }
    }
}