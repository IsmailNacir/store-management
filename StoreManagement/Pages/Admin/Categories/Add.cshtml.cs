using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using StoreManagement.Data;
using StoreManagement.Data.Models;
using StoreManagement.Data.Models.Utility;
using StoreManagement.Data.Models.ViewModels;

namespace StoreManagement.Pages.Admin.Categories
{
    public class AddModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly ProductDbContext _dbContext;
        [BindProperty]
        public CategoryViewModel Categ { get; set; }
        public AddModel(ProductDbContext context,
                        IMapper mapper,
                        IToastNotification toastNotification)
        {
            _dbContext = context;
            _mapper = mapper;
            _toastNotification = toastNotification;
        }
        public void OnGet()
        {
        }

        public async Task OnPost()
        {
            Category category = _mapper.Map<Category>(Categ);

            if (ModelState.IsValid)
            {
                if (category != null)
                {
                    await _dbContext.AddAsync(category);
                    int isSaved = await _dbContext.SaveChangesAsync();
                    if (isSaved > 0)
                    {
                        _toastNotification.AddSuccessToastMessage("The enw category was succeffully saved !");
                    }
                    else
                    {
                        _toastNotification.AddErrorToastMessage("The new Category is not saved ! Please try again");
                        //return RedirectToPage("./Index");
                    }

                }

            }
        }
    }
}
