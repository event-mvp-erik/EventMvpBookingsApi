using EventMvpBookingsApi.Models;

namespace EventMvpBookingsApi.Repositories
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetAll();
        Booking? GetById(int id);
        Booking Create(Booking booking);
    }
}
