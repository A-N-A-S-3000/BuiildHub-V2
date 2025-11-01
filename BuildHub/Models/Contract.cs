using System.ComponentModel.DataAnnotations;

namespace BuildHub.Models
{
    public class Contract
    {
        public int Id { get; set; }

        [Required]
        public int? ProjectId { get; set; }

        [Required]
        public int CompanyId { get; set; }
        public Company? Company { get; set; }

        public int? BrokerBidId { get; set; }
        public BrokerBid? BrokerBid { get; set; }

        public string? Terms { get; set; }               
        public DateTime? SignedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
