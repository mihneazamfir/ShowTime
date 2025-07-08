using ShowTime.Entities;
using ShowTime.Context;
using ShowTime.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ShowTime.Repositories.Implementation
{
    public class RepositoryFestival : RepositoryBase<Festival>, IRepositoryFestival
    {
        public RepositoryFestival(ShowTimeContext context) : base(context)
        {
        }

        public async Task<Festival?> GetByIdWithBandsAsync(Guid id)
        {
            return await _context.Festivals
                .Include(f => f.Bands)
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}