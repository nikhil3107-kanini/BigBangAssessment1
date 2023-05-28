using BigBangAssessment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BigBangAssessment.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelRoomDbContext _dbContext;

        public RoomRepository(HotelRoomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Room GetRoomById(int id)
        {
            var rooms = _dbContext.Set<Room>().Find(id);
            return rooms;
        }

        public IEnumerable<Room> GetRooms()
        {
            return _dbContext.Set<Room>().ToList();
        }

        public void AddRoom(Room rooms)
        {
            try
            {
                _dbContext.Set<Room>().Add(rooms);
                _dbContext.SaveChanges();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void UpdateRoom(Room rooms)
        {
            try
            {
                _dbContext.Entry(rooms).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void DeleteRoom(int id)
        {
            try
            {
                var Rooms = _dbContext.Set<Room>().Find(id);
                _dbContext.Set<Room>().Remove(Rooms);
                _dbContext.SaveChanges();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }



    }
}
