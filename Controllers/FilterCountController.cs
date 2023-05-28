using BigBangAssessment.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBangAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterCountController : ControllerBase
    {
        private readonly IFilterCountRepository _filterCountRepository;

        public FilterCountController(IFilterCountRepository filterCountRepository)
        {
            _filterCountRepository = filterCountRepository;
        }

        [HttpGet]
        public IActionResult GetAllHotels(string? location = null, decimal? minPrice = null, decimal? maxPrice = null)
        {
            var hotels = _filterCountRepository.GetHotelsByFilter(location, minPrice, maxPrice);
            return Ok(hotels);
        }



        [HttpGet("{id}")]
        public int GetCount(int id)
        {
            var count = _filterCountRepository.GetRoomCount(id);

            return count;
        }

    }
}
