using Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Domain.Interfaces.Repositories;
using Domain.Entities;
using Domain.DTO.IsSimianDTO;
using Domain.DTO.StatsDTO;
using Domain.Models.Clients.Advice;
using Domain.Interfaces.Clients;
using Domain.Models.Clients;
using Domain.Models.Clients.ChuckNorris;

namespace Service.Services
{
    public class ChuckNorrisService : IChuckNorrisService
    {
        private readonly ILogger<ChuckNorrisService> _logger;
        private readonly IChuckNorrisClient _client;

        public ChuckNorrisService(ILogger<ChuckNorrisService> logger, IChuckNorrisClient client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task<ChuckNorrisModel> Get()
        {
            var respone = await _client.Get("jokes/random");
            if (respone == null)
                return null;
            return (ChuckNorrisModel)respone.Data;
        }
        
    }
}
