using System.ComponentModel.DataAnnotations;

namespace SignalREntityLayer.Entities
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string PersonCount { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
