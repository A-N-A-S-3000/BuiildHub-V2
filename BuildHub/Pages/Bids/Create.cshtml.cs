using BuildHub.domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

public class CreateBidModel : PageModel
{
    private readonly DataService _db;
    public CreateBidModel(DataService db) => _db = db;

    [BindProperty(SupportsGet = true)] public int ProjectPublicId { get; set; }
    [BindProperty] public int RequestId { get; set; }  // choose an open request for that project
    [BindProperty] public int CompanyId { get; set; }
    [BindProperty] public decimal PriceTotal { get; set; }
    [BindProperty] public int? DurationDays { get; set; }
    [BindProperty] public string? TierSnapshot { get; set; }
    [BindProperty] public string? Message { get; set; }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (RequestId <= 0 || CompanyId <= 0 || PriceTotal < 0)
        {
            ModelState.AddModelError("", "Fill all fields.");
            return Page();
        }

        _db.PlaceBrokerBid(RequestId, CompanyId, PriceTotal, DurationDays, TierSnapshot, Message);
        TempData["msg"] = "Bid placed.";
        return RedirectToPage("/Requests/Details", new { projectPublicId = ProjectPublicId.ToString() });
    }
}
