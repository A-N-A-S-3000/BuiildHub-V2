// HAMZAH
namespace BuildHub2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public enum RequestStatus
{
    Open,
    Awarded,
    Closed
}

[Table("decoration_requests")]

public class DecorationRequest
{
    [Key]
    public long Id { get; set; }
    [Required]
    public required string Project_Public_Id { get; set; }
    public string Scope_Note { get; set; } = string.Empty;
    [Required]
    public string Status { get; set; } = "open";
    public DateTime Created_At { get; set; } = DateTime.Now;


}
