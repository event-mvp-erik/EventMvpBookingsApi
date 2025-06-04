namespace EventMvpBookingsApi.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string AttendeeName { get; set; } = "";
        public string Email { get; set; } = "";
        public int NumberOfSeats { get; set; }
    }
}
