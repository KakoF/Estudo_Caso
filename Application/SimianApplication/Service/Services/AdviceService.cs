using Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Domain.Interfaces.Repositories;
using Domain.Entities;
using Domain.DTO.IsSimianDTO;
using Domain.DTO.StatsDTO;
using Domain.Models.Clients.Advice;
using Domain.Interfaces.Clients;
using Domain.Models.Clients;

namespace Service.Services
{
    public class AdviceService : IAdviceService
    {
        private readonly ILogger<AdviceService> _logger;
        private readonly IAdviceClient _client;

        public AdviceService(ILogger<AdviceService> logger, IAdviceClient client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task<AdviceModel> Get()
        {
            var respone = await _client.Get("advice");
            return (AdviceModel)respone?.Data ?? null;
        }
        
    }
}
