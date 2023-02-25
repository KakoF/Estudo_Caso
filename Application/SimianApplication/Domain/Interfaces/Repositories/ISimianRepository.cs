using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ISimianRepository
    {
        Task<SimianEntity> Create(SimianEntity data);

        Task<IEnumerable<SimianEntity>> Get();
    }
}
