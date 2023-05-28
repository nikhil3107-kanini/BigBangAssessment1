using BigBangAssessment.Models;
using Microsoft.EntityFrameworkCore;

namespace BigBangAssessment.Repository
{
    public class HotelRepository:IHotelRepository
    {
        private readonly HotelRoomDbContext _dbContext;

        public HotelRepository(HotelRoomDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddHotel(Hotel hotel)
        {
            try
            {
                _dbContext.Set<Hotel>().Add(hotel);
                _dbContext.SaveChanges();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteHotel(int id)
        {
            try
            {
                var hotel = _dbContext.Set<Hotel>().Find(id);
                _dbContext.Set<Hotel>().Remove(hotel);
                _dbContext.SaveChanges();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public IEnumerable<Hotel> GetHotels()
        {
            var hotels = _dbContext.Set<Hotel>().Include(x => x.Rooms).ToList();
                      


            return hotels;
        }

        public Hotel GetHotelById(int id)
        {
            var hotel = _dbContext.Set<Hotel>().FirstOrDefault(d => d.HotelId == id);
            return hotel;
        }

        public void UpdateHotel(Hotel hotel)
        {
            try
            {
                _dbContext.Entry(hotel).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }



    }
}
