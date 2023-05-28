using BigBangAssessment.Models;

namespace BigBangAssessment.Repository
{
    public interface IHotelRepository
    {
        Hotel GetHotelById(int id);
        IEnumerable<Hotel> GetHotels();
        void AddHotel(Hotel hotel);
        void UpdateHotel(Hotel hotel);
        void DeleteHotel(int id);

    }
}
