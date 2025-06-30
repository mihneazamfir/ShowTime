// using ShowTime.Entities;
using ShowTime.Context;
using ShowTime.Repositories.Interfaces;

namespace ShowTime.Repositories.Implementation
{
    public class RepositoryFestival : RepositoryBase<Festival>, IRepositoryFestival
    {
        public RepositoryFestival(ShowTimeContext context) : base(context)
        {
        }
    }
}