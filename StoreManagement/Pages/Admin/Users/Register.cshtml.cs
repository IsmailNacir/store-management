using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using StoreManagement.Data.Models;
using StoreManagement.Data.Models.ViewModels;

namespace StoreManagement.Pages.Admin.Users
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public AppUserViewModel AppUserInput { get; set; }

        private readonly UserManager<AppUser> _userManager;
        private readonly IToastNotification _toastNotification;
        private readonly IMapper _mapper;

        public RegisterModel(UserManager<AppUser> userManager,
                            IToastNotification toastNotification,
                            IMapper mapper)
        {
            _toastNotification = toastNotification;
            _userManager = userManager;
            _mapper = mapper;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                AppUser user = _mapper.Map<AppUser>(AppUserInput);
                user.UserName = AppUserInput.Email;
                var response = await _userManager.CreateAsync(user, AppUserInput.Password);

                if (response.Succeeded)
                {
                    _toastNotification.AddSuccessToastMessage("User was created successffuly");
                    return RedirectToPage("Index");
                }
                else
                {
                    _toastNotification.AddErrorToastMessage("User was not created");
                    return Page();
                }
            }
            return Page();
        }
    }
}
