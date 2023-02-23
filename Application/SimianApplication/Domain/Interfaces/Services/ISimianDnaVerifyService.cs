using Domain.DTO;

namespace Domain.Interfaces.Services
{
    public interface ISimianDnaVerifyService
    {
        public SimianResponseDTO Verify(SimianRequestDTO data);
    }
}
