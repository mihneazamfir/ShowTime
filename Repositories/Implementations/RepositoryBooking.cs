// using ShowTime.Entities;
using ShowTime.Context;
using ShowTime.Entities;
using ShowTime.Repositories.Interfaces;

namespace ShowTime.Repositories.Implementation
{
    public class RepositoryBooking : RepositoryBase<Booking>, IRepositoryBooking
    {
        public RepositoryBooking(ShowTimeContext context) : base(context)
        {
        }
    }
}