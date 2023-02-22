using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimianDomain.Interfaces.Core;

namespace SimianApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimianController : ControllerBase
    {
        public SimianController(ISimianVerifierCore simianVerifierCore) 
        {
            _simianVerifierCore = simianVerifierCore;
        }

        private readonly ISimianVerifierCore _simianVerifierCore;
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string[] DNA) 
        {     
            return Ok(new { is_simian = (await _simianVerifierCore.VerifyAsync(DNA)) });
        }
    }
}
