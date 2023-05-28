using BigBangAssessment.Models;

namespace BigBangAssessment.Repository
{
    public interface IRoomRepository
    {
        Room GetRoomById(int id);
        IEnumerable<Room> GetRooms();
        void AddRoom(Room room);
        void UpdateRoom(Room room);
        void DeleteRoom(int id);
    }
}
