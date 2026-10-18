using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uber.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [Range(20,5000)]
        public int? Amount { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public string PaymentStatus { get; set; }
        [ForeignKey(nameof(RideId))]
        [Required]
        public int RideId { get; set; }
        public Ride Ride { get; set; }
        
    }
}
