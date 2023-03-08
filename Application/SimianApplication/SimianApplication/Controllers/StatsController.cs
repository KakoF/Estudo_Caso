using App.Metrics;
using Domain.DTO.StatsDTO;
using Domain.Interfaces.Services;
using Domain.Metrics;
using Microsoft.AspNetCore.Mvc;

namespace SimianApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatsController : ControllerBase
    {
        private readonly IStatsService _service;
        private readonly IMetrics _metrics;

        public StatsController(IStatsService service, IMetrics metrics)
        {
            _service = service;
            _metrics = metrics;
        }

        [HttpGet]
        public async Task<StatsResponseDTO> Get()
        {
            _metrics.Measure.Counter.Increment(MetricsRegistry.SimianStats);
            return await _service.GetStatsAsync();
        }
    }
}