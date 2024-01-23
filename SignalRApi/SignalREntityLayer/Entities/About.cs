using System.ComponentModel.DataAnnotations;

namespace SignalREntityLayer.Entities
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
