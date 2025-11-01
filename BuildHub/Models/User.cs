using System.ComponentModel.DataAnnotations;

namespace BuildHub.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; } = "";

        [Required, MinLength(6)]
        public string Password { get; set; } = "";

        [Required]
        public string UserType { get; set; } = ""; // company or homeowner

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation property
        public List<Project> Projects { get; set; } = new();
    }
}