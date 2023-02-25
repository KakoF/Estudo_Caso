using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ISimianCalcRepository
    {
        Task<ViewSimianCalcEntity> GetAsync();
    }
}
