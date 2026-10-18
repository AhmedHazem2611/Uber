using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uber.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(1,5)]
        public int Score { get; set; }
        [MaxLength(250)]
        public string Comment { get; set; }
        [ForeignKey(nameof(RideId))]
        public int RideId { get; set; }
        public Ride Ride { get; set; }
    }
}
