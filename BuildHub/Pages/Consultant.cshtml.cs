using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BuildHub.Pages
{
    public class ConsultantModel : PageModel
    {
        [TempData] public string? TEmail { get; set; }
        [TempData] public string? TUserType { get; set; }

        [TempData] public string? TProjectLocation { get; set; }
        [TempData] public string? TProjectFloors { get; set; }
        [TempData] public string? TKrokiNumber { get; set; }
        public void OnGet()
        {
        }
    }
}
