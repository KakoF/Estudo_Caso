using Domain.DTO;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace SimianApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SimianController : ControllerBase
    {
        private readonly ILogger<SimianController> _logger;
        private readonly ISimianService _service;

        public SimianController(ILogger<SimianController> logger, ISimianService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public async Task<SimianResponseDTO> Post(SimianRequestDTO data)
        {
            return await _service.VerifyDna(data);
        }
    }
}