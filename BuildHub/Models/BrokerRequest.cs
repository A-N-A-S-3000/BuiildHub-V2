using System.ComponentModel.DataAnnotations;

namespace BuildHub.Models
{
    public class BrokerRequest
    {
        public int Id { get; set; }

        // plain text GUID from A (project public id)
        [Required, StringLength(64)]
        public int ProjectId { get; set; } = 1;

        public bool HasPlans { get; set; } = false;

        // excellent|good|standard or null
        [StringLength(20)]
        public string? TierFilter { get; set; }

        // open → awarded → closed
        [Required, StringLength(20)]
        public string Status { get; set; } = "open";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<BrokerBid> Bids { get; set; } = new();
    }

}
