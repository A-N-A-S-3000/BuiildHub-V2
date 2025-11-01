using BuildHub.domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class CreateModel : PageModel
{
    private readonly DataService _db;
    public CreateModel(DataService db) => _db = db;

    [BindProperty] public string Status { get; set; } = "new";
    [BindProperty] public string Location { get; set; } = "";
    [BindProperty] public int Floors { get; set; }
    [BindProperty] public string KrokiNumber { get; set; } = "";
    [BindProperty] public int UserId { get; set; } = 1;  // simple fixed user
    [BindProperty] public string? ImagePath { get; set; }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (string.IsNullOrWhiteSpace(Location) || string.IsNullOrWhiteSpace(KrokiNumber) || Floors < 1)
        {
            ModelState.AddModelError(string.Empty, "Fill all fields.");
            return Page();
        }

        _db.AddProject(Status, Location, Floors, KrokiNumber, UserId, ImagePath);
        TempData["msg"] = "Project created.";
        return RedirectToPage("/Projects/Index");
    }
}
