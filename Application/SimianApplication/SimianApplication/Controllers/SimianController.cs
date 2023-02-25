using Domain.DTO.IsSimianDTO;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace SimianApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SimianController : ControllerBase
    {
        private readonly ISimianService _service;

        public SimianController(ISimianService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IsSimianResponseDTO> Post(IsSimianRequestDTO data)
        {
            return await _service.VerifyDnaAsync(data);
        }
    }
}