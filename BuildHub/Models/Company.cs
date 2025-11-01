using System.ComponentModel.DataAnnotations;

namespace BuildHub.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; } = "";

        // "broker" by default (keep simple)
        [Required, StringLength(20)]
        public string Type { get; set; } = "broker";

        // excellent|good|standard (optional)
        [StringLength(20)]
        public string? Tier { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Past projects for this company
        public List<CompanyProject> PastProjects { get; set; } = new();
    }
}
