using BuildHub.domain;
using BuildHub.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

public class DetailsModel : PageModel
{
    private readonly DataService _db;
    public DetailsModel(DataService db) => _db = db;

    public int ProjectPublicId { get; set; }
    public List<BrokerRequest> Requests { get; set; } = new();
    public List<BrokerBid> Bids { get; set; } = new();

    public void OnGet(string projectPublicId)
    {
        ProjectPublicId = int.TryParse(projectPublicId, out var pid) ? pid : 0;
        Requests = _db.GetBrokerRequestsByProject(projectPublicId);
        Bids = Requests.SelectMany(r => r.Bids ?? new List<BrokerBid>()).OrderBy(b => b.PriceTotal).ToList();
    }
}
