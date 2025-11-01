using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
namespace BuildHub.Pages
{
    public class WelcomeModel : PageModel
    {
        public class WelcomeInput
        {
            [Required]
            public string Location { get; set; } = "";

            [Required]
            public int floors { get; set; } = 0 ;

            [Required]
            public string krokiNumber { get; set; } = "";
        }
        [BindProperty] public WelcomeInput Input_welcome { get; set; } = new();
        [TempData] public string? TEmail { get; set; }
        [TempData] public string? TUserType { get; set; }

        [TempData] public string? TProjectLocation { get; set; }
        [TempData] public String? TProjectFloors { get; set; }
        [TempData] public string? TKrokiNumber { get; set; }

        public void OnGet() {
            TempData.Keep("TEmail");
            TempData.Keep("TUserType");
        }

        public IActionResult OnPostSaveProject()
        {
            TProjectLocation = Input_welcome.Location.Trim();
            TProjectFloors = Input_welcome.floors.ToString();
            TKrokiNumber = Input_welcome.krokiNumber.Trim();
            TempData.Keep("TEmail");
            TempData.Keep("TUserType");
            return RedirectToPage("Consultant");
        }
    }
}
