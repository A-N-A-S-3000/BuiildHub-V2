using System.ComponentModel.DataAnnotations;

namespace BuildHub.Models
{
    public class CompanyProject
    {
        public long Id { get; set; }

        [Required]
        public int CompanyId { get; set; }
        public Company? Company { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; } = "";          

        [Required, StringLength(200)]
        public string Location { get; set; } = "";       

        [Range(0, 100)]
        public int Floors { get; set; }                  

        [StringLength(500)]
        public string? Description { get; set; }         

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string? ImagePath { get; set; }           
    }
}
