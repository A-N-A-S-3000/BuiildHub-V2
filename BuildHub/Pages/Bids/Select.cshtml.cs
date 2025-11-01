using BuildHub.domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class SelectModel : PageModel
{
    private readonly DataService _db;
    public SelectModel(DataService db) => _db = db;

    [BindProperty(SupportsGet = true)] public int BidId { get; set; }
    [BindProperty(SupportsGet = true)] public int ProjectPublicId { get; set; }
    [BindProperty] public string Terms { get; set; } = "Standard turnkey contract v1";

    public (int? contractId, string? error) Result { get; set; }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        var (bid, contract, error) = _db.SelectBid(BidId, Terms);
        if (error != null) { TempData["msg"] = error; return RedirectToPage("/Requests/Details", new { projectPublicId = ProjectPublicId.ToString() }); }

        TempData["msg"] = $"Bid selected. Contract #{contract!.Id} created.";
        return RedirectToPage("/Contracts/ByProject", new { projectPublicId = ProjectPublicId.ToString() });
    }
}
