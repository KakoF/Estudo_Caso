using Domain.DTO.IsSimianDTO;

namespace Domain.Interfaces.Services
{
    public interface ISimianService
    {
        public Task<IsSimianResponseDTO> VerifyDnaAsync(IsSimianRequestDTO data);
    }
}
