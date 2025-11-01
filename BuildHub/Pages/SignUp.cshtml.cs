using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BuildHub.Pages
{


    public class SignUpModel : PageModel
    {
        public class SignUpInput
        {
            [Required, EmailAddress]
            public string Email { get; set; } = "";

            [Required, MinLength(6)]
            public string Password { get; set; } = "";

            [Required, RegularExpression("^(company|homeowner)$",
               ErrorMessage = "Choose company or homeowner")]
            public string UserType { get; set; } = "";
        }

        [BindProperty] public SignUpInput Input { get; set; } = new();


        [TempData] public string? TEmail { get; set; }
        [TempData] public string? TUserType { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();


            TEmail = Input.Email;
            TUserType = Input.UserType;


            return RedirectToPage("Welcome");
        }
    }

}