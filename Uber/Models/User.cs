using System.ComponentModel.DataAnnotations;

namespace Uber.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(100)] 
        public string FullName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        public string Role { get; set; }
        public List<Ride> RiderRides { get; set; } = new List<Ride>();
        public List<Ride> DriverRides { get; set; } = new List<Ride>();
        public Vehicle? Vehicle { get; set; }
    }
}
