using Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Domain.Interfaces.Repositories;
using Domain.Entities;
using Domain.Notification;
using Domain.DTO.IsSimianDTO;

namespace Service.Services
{
    public class SimianService : ISimianService
    {
        private readonly ILogger<SimianService> _logger;
        private readonly ISimianPatternsExecute _patternsExecute;
        private readonly ISimianRepository _repository;
        private readonly NotificationContext _notificationContext;



        public SimianService(ILogger<SimianService> logger, ISimianPatternsExecute patternsExecute, ISimianRepository repository, NotificationContext notificationContext)
        {
            _logger = logger;
            _patternsExecute = patternsExecute;
            _repository = repository;
            _notificationContext = notificationContext;
        }
        public async Task<IsSimianResponseDTO> VerifyDna(IsSimianRequestDTO data)
        {
            if (data.Invalid)
            {
                _notificationContext.AddNotifications(data.ValidationResult);
                return null;
            }
            
            _logger.LogWarning("Inicio de analise do Dna: {0}", string.Join(",", data.Dna));
            var isSimian = _patternsExecute.Execute(data.Dna).Where(x => x.Equals(true)).Count() >= 2;
            var simian = new SimianEntity(string.Join(",", data.Dna), isSimian);
            await _repository.Create(simian);
            return new IsSimianResponseDTO(simian.IsSimian);
        } 
        
    }
}
