using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uber.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string PlateNumber { get; set; }
        [Required] 
        public string Color { get; set; }
        [Required]
        [ForeignKey(nameof(DriverId))]
        public int DriverId { get; set; }
        public User Driver { get; set; }
    }
}
