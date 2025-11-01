using BuildHub.domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class NewCompanyModel : PageModel
{
    private readonly DataService _db;
    public NewCompanyModel(DataService db) => _db = db;

    [BindProperty] public string Name { get; set; } = "";
    [BindProperty] public string? Tier { get; set; }

    public void OnGet() { }
    public IActionResult OnPost()
    {
        if (string.IsNullOrWhiteSpace(Name)) { ModelState.AddModelError("", "Name required"); return Page(); }
        _db.AddCompany(Name, Tier);
        TempData["msg"] = "Company created.";
        return RedirectToPage("/Companies/Index");
    }
}
