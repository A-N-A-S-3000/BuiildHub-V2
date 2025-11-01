using BuildHub.domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class NewCompanyProjectModel : PageModel
{
    private readonly DataService _db;
    public NewCompanyProjectModel(DataService db) => _db = db;

    [BindProperty] public int CompanyId { get; set; }
    [BindProperty] public string Title { get; set; } = "";
    [BindProperty] public string Location { get; set; } = "";
    [BindProperty] public int Floors { get; set; }
    [BindProperty] public string? Description { get; set; }
    [BindProperty] public string? ImagePath { get; set; }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(Location) || Floors < 0)
        { ModelState.AddModelError("", "Fill fields"); return Page(); }

        _db.AddCompanyProject(CompanyId, Title, Location, Floors, Description, ImagePath);
        if (CompanyId <= 0)
        {
            TempData["msg"] = "Nigga, put a correct ID and do it again.";
            return Page();
        }
        else
        {
            TempData["msg"] = "Company project added.";
        return RedirectToPage("/Companies/Index");
        }
    }
}
