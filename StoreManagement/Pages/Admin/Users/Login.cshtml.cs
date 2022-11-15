using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.Data.Models;
using StoreManagement.Data.Models.ViewModels;

namespace StoreManagement.Pages.Admin.Users
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginViewModel LoginInput { get; set; }
        private readonly SignInManager<AppUser> _signInManager;

        public LoginModel(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var response = await _signInManager.PasswordSignInAsync(LoginInput.Email,
                                       LoginInput.Password, LoginInput.Remember, lockoutOnFailure: false);

                if (response.Succeeded)
                {
                    return RedirectToPage("../Products/Index");
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Invalid login or password");
                    return Page();
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnGetLogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToPage("../Users/Login");
        }
    }
}
