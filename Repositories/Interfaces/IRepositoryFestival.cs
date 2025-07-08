using ShowTime.Entities;

namespace ShowTime.Repositories.Interfaces
{
    public interface IRepositoryFestival : IRepositoryBase<Festival>
    {
        Task<Festival?> GetByIdWithBandsAsync(Guid id);
    }
}