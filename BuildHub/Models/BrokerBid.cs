using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildHub.Models
{
    public class BrokerBid
    {
        public int Id { get; set; }

        [Required]
        public long RequestId { get; set; }
        public BrokerRequest? Request { get; set; }

        [Required]
        public int CompanyId { get; set; }
        public Company? Company { get; set; }

        // snapshot of company tier at bid time (optional)
        [StringLength(20)]
        public string? TierSnapshot { get; set; }

        [Range(0, 999999999999.99)]
        [Column(TypeName = "decimal(14,2)")]
        public decimal PriceTotal { get; set; }

        [Range(0, int.MaxValue)]
        public int? DurationDays { get; set; }

        public bool Selected { get; set; } = false;      // set true when user chooses this bid

        public string? Message { get; set; }             // simple notes

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
