using Microsoft.AspNetCore.Mvc;
using EventMvpBookingsApi.Models;
using EventMvpBookingsApi.Repositories;

namespace EventMvpBookingsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingRepository _repository;

        public BookingsController(IBookingRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Booking> GetById(int id)
        {
            var booking = _repository.GetById(id);
            if (booking == null) return NotFound();
            return Ok(booking);
        }

        [HttpPost]
        public ActionResult<Booking> Create([FromBody] Booking booking)
        {
            if (string.IsNullOrWhiteSpace(booking.AttendeeName) || string.IsNullOrWhiteSpace(booking.Email))
                return BadRequest("Name and Email are required");

            var created = _repository.Create(booking);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}
