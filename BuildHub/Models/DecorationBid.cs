// HAMZAH


namespace BuildHub2.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("decoration_bids")]

public class DecorationBid
{
    [Key]
    public long Id { get; set; }

    [ForeignKey(nameof(DecorationRequest))]
    public long Request_Id { get; set; }
    public DecorationRequest DecorationRequest { get; set; } = null!;

    [ForeignKey(nameof(Company))]
    public long Company_Id { get; set; }
    public Company Company { get; set; } = null!;

    [Column(TypeName = "numeric(14,2)")]
    public decimal Price_Total { get; set; }

    public int? Duration_Days { get; set; }

    public bool Selected { get; set; } = false;

    public DateTime Created_At { get; set; } = DateTime.Now;
}

