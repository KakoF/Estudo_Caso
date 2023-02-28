using Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Domain.Interfaces.Repositories;
using Domain.Entities;
using Domain.DTO.IsSimianDTO;
using Domain.Interfaces.Notifications;
using Domain.Notifications;

namespace Service.Services
{
    public class SimianService : ISimianService
    {
        private readonly ILogger<SimianService> _logger;
        private readonly ISimianPatternsExecute _patternsExecute;
        private readonly ISimianRepository _repository;
        private readonly INotificationHandler<Notification> _notification;

        public SimianService(ILogger<SimianService> logger, ISimianPatternsExecute patternsExecute, ISimianRepository repository, INotificationHandler<Notification> notification)
        {
            _logger = logger;
            _patternsExecute = patternsExecute;
            _repository = repository;
            _notification = notification;
        }
        public async Task<IsSimianResponseDTO> VerifyDnaAsync(IsSimianRequestDTO data)
        {
            _logger.LogWarning("Inicio de analise do Dna: {0}", string.Join(",", data.Dna));
            /*_notification.AddNotification(500, "Titulo do Erro", "Primeiro Erro genérico");
            _notification.AddNotification("Titulo do Erro", "Segundo Erro genérico");*/
            var isSimian = ParseArray(_patternsExecute.Execute(data.Dna)).Where(x => x.Equals(true)).Count() >= 2;
            var simian = new SimianEntity(string.Join(",", data.Dna), isSimian);
            await _repository.CreateAsync(simian);
            return new IsSimianResponseDTO(simian.IsSimian);
        }

        private IEnumerable<bool> ParseArray(IEnumerable<bool[]> array)
        {
            List<bool> list = new List<bool>();
            foreach (var result in array)
            {
                list.AddRange(result);
            }
            return list;

        }

    }
}
