using BuildHub.domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class OpenModel : PageModel
{
    private readonly DataService _db;
    public OpenModel(DataService db) => _db = db;

    [BindProperty] public int ProjectPublicId { get; set; }   // int in your code
    [BindProperty] public bool HasPlans { get; set; }
    [BindProperty] public string? TierFilter { get; set; }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (ProjectPublicId <= 0) { ModelState.AddModelError("", "ProjectPublicId required"); return Page(); }
        _db.OpenBrokerRequest(ProjectPublicId, HasPlans, TierFilter);
        TempData["msg"] = "Broker request opened.";
        return RedirectToPage("/Requests/Details", new { projectPublicId = ProjectPublicId.ToString() });
    }
}
