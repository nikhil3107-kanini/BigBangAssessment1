using BigBangAssessment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigBangAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchRoomController : ControllerBase
    {
        private readonly HotelRoomDbContext _context; // Replace "YourDbContext" with your application's database context class

        public SearchRoomController(HotelRoomDbContext context)
        {
            _context = context;
        }


        
        [HttpGet("{hotelName}")]
        public async Task<ActionResult<IEnumerable<Room>>> GetRoomsByHotel(string hotelName)
        {
            var hotel = await _context.Set<Hotel>()
                .Include(h => h.Rooms)
                .FirstOrDefaultAsync(h => h.Name == hotelName);

            if (hotel == null)
            {
                return NotFound("Hotel not found.");
            }

            return Ok(hotel.Rooms);
        }
    }
}
