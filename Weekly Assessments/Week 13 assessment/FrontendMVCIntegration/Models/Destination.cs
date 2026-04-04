using System.ComponentModel.DataAnnotations;

namespace FrontendMVCIntegration.Models
{
    public class Destination
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string Country { get; set; }
        public string? Description { get; set; }

        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5")]
        public int Rating { get; set; }
        public DateTime LastVisited { get; set; }
    }
}