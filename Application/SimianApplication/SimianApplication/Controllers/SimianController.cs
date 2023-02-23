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
        private readonly ISimianDnaVerifyService _service;

        public SimianController(ILogger<SimianController> logger, ISimianDnaVerifyService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public SimianResponseDTO Post(SimianRequestDTO data)
        {
            return _service.Verify(data);
        }
    }
}