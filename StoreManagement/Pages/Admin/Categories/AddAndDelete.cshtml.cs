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
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly ProductDbContext _dbContext;
        private readonly ICategoryService _categoryService;
        [BindProperty]
        public CategoryViewModel Categ { get; set; }
        public AddModel(ProductDbContext context,
                        IMapper mapper,
                        IToastNotification toastNotification,
                        ICategoryService categoryService)
        {
            _dbContext = context;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _categoryService = categoryService;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            Category category = _mapper.Map<Category>(Categ);

            if (ModelState.IsValid && category != null)
            {

                await _dbContext.Category.AddAsync(category);
                int isSaved = await _dbContext.SaveChangesAsync();
                if (isSaved > 0)
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
