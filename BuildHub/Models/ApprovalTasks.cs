// HAMZAH

namespace BuildHub2.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("approval_tasks")]
public class ApprovalTasks
{
    [Key]
    public long Id { get; set; }

    [Required, MaxLength(64)]
    public required string Project_Public_Id { get; set; }

    [Required, MaxLength(20)]
    public required string Phase { get; set; } 

    [Required, MaxLength(200)]
    public required string Title { get; set; }

    [Required, MaxLength(20)]
    public string Status { get; set; } = "open"; 

    [Column(TypeName = "numeric(14,2)")]
    public decimal? Fee_Amount_Omr { get; set; }

    public bool Fee_Paid { get; set; } = false;

    public DateTime? Due_Date { get; set; }

    public DateTime Created_At { get; set; } = DateTime.Now;

    public DateTime Updated_At { get; set; } = DateTime.Now;
}
