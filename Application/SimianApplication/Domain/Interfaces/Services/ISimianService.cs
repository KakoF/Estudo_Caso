using Domain.DTO;

namespace Domain.Interfaces.Services
{
    public interface ISimianService
    {
        public Task<SimianResponseDTO> VerifyDna(SimianRequestDTO data);
    }
}
