using BigBangAssessment.Models;

namespace BigBangAssessment.Repository
{
    public interface IFilterCountRepository
    {
        public int GetRoomCount(int id);

        public IEnumerable<Hotel> GetHotelsByFilter(string? location, decimal? minPrice, decimal? maxPrice);




    }
}
