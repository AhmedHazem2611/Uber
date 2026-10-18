using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uber.Models
{
    public class Ride
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PickupLocation { get; set; }
        [Required]
        public string PickOffLocation { get; set; }
        [Range(20,5000)]
        public int? Fare { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        [ForeignKey(nameof(RiderId))]
        public int RiderId { get; set; }
        public User Rider { get; set; }
        [ForeignKey(nameof(DriverId))]
        public int? DriverId { get; set; }
        public User? Driver { get; set; }
        public Payment? Payment { get; set; }
        public Rating? Rating { get; set; }  

    }
}
