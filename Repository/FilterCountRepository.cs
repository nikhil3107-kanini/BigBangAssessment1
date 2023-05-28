using BigBangAssessment.Models;

namespace BigBangAssessment.Repository
{
    public class FilterCountRepository: IFilterCountRepository
    {

        private readonly HotelRoomDbContext _dbContext;

        public FilterCountRepository(HotelRoomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int GetRoomCount(int id)
        {
            try
            {
                return _dbContext.Set<Room>().Count(r => r.HotelId == id && r.Available == true);
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                Console.WriteLine("Error getting room count: " + ex.Message);
                throw; // Re-throw the exception to be handled at the higher level
            }
        }

        public IEnumerable<Hotel> GetHotelsByFilter(string? location, decimal? minPrice, decimal? maxPrice)
        {
            try
            {
                var hotels = _dbContext.Set<Hotel>().AsQueryable();

                if (!string.IsNullOrEmpty(location))
                    hotels = hotels.Where(h => h.Location.Contains(location));

                if (minPrice != null)
                    hotels = hotels.Where(h => h.MinPrice >= minPrice);

                if (maxPrice != null)
                    hotels = hotels.Where(h => h.MinPrice <= maxPrice);

                return hotels.ToList();
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                Console.WriteLine("Error retrieving hotels by filter: " + ex.Message);
                throw; // Re-throw the exception to be handled at the higher level
            }
        }


    }
}
