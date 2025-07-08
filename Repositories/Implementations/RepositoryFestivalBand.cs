using ShowTime.Entities;
using ShowTime.Context;
using ShowTime.Repositories.Interfaces;

namespace ShowTime.Repositories.Implementation
{
    public class RepositoryFestivalBand : RepositoryBase<FestivalBand>, IRepositoryFestivalBand
    {
        public RepositoryFestivalBand(ShowTimeContext context) : base(context)
        {
        }
    }
}