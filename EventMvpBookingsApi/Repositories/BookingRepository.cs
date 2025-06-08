using EventMvpBookingsApi.Models;

namespace EventMvpBookingsApi.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly List<Booking> _bookings = new();

        public IEnumerable<Booking> GetAll() => _bookings;

        public Booking? GetById(int id) => _bookings.FirstOrDefault(b => b.Id == id);

        public Booking Create(Booking booking)
        {
            booking.Id = _bookings.Any() ? _bookings.Max(b => b.Id) + 1 : 1;
            _bookings.Add(booking);
            return booking;
        }
    }
}
