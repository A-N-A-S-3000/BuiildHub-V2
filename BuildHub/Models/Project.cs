using System.ComponentModel.DataAnnotations;

namespace BuildHub.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public string Location { get; set; } = "";

        [Required] public string status { get; set; } = ""; // new, in progress, completed

        [Required]
        public int Floors { get; set; }

        [Required]
        public string KrokiNumber { get; set; } = "";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string? ImagePath { get; set; }

        // Foreign key
        public int UserId { get; set; }
        public User? User { get; set; }

    }
}