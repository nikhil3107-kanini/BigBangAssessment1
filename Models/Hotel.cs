using System.ComponentModel.DataAnnotations;

namespace BigBangAssessment.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }

       

        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }

        public string? Amenities { get; set; }
        

        public ICollection<Room>? Rooms { get; set; }
        
    }
}
