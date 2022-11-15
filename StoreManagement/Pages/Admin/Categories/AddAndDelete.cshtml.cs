using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using StoreManagement.Data;
using StoreManagement.Data.Models;
using StoreManagement.Data.Models.Utility;
using StoreManagement.Data.Models.ViewModels;
using StoreManagement.Service.Interfaces;

namespace StoreManagement.Pages.Admin.Categories
{
    public class AddModel : PageModel
    {
        private readonly IToastNotification _toastNotification;
        private readonly ICategoryService _categoryService;
        [BindProperty]
        public CategoryViewModel Categ { get; set; }

        public AddModel(IToastNotification toastNotification,
                        ICategoryService categoryService)

        {
            _toastNotification = toastNotification;
            _categoryService = categoryService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var response = await _categoryService.AddCategory(Categ);
               
                if (response)
                {
                    _toastNotification.AddSuccessToastMessage("The enw category was succeffully saved !");
                    return RedirectToPage("Index");
                }
                else
                {
                    _toastNotification.AddErrorToastMessage("The new Category is not saved ! Please try again");

                }
            }

            return Page();
        }

        public async Task<IActionResult> OnGetDelete(Guid categoryId)
        {
            var response = await _categoryService.DeleteCategory(categoryId);

            if (response)
            {
                _toastNotification.AddSuccessToastMessage("The category was successffully removed !");
                return RedirectToPage("Index");

            }

            _toastNotification.AddErrorToastMessage("There is an error, please try again :/");
            return RedirectToPage("Index");
        }

    }
}
