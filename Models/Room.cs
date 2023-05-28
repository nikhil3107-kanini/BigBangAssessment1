using System.ComponentModel.DataAnnotations;

namespace BigBangAssessment.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public string? RoomNumber { get; set; }
        public string? Type { get; set; }
        public int Capacity { get; set; }

        public bool Available { get; set; }
        public int Price { get; set; }

        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }
    }
}
