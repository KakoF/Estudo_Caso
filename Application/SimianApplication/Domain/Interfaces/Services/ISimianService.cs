using Domain.DTO;

namespace Domain.Interfaces.Services
{
    public interface ISimianService
    {
        public SimianResponseDTO VerifyDna(SimianRequestDTO data);
    }
}
