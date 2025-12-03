// HAMZAH
namespace BuildHub2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("milestone_updates")]
public class MilestoneUpdates
{
    [Key]
    public long Id { get; set; }

    [Required, ForeignKey(nameof(Milestones))]
    public long Milestone_Id { get; set; }
    public Milestones Milestones { get; set; } = null!;

    public string? Note { get; set; } = string.Empty;

    public string Photos_Json { get; set; } = string.Empty;

    [Required]
    public required string Created_By { get; set; }

    public DateTime Created_At { get; set; } = DateTime.Now;



}
