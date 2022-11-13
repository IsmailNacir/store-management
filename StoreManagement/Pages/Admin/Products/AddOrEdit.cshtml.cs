using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using StoreManagement.Data;
using StoreManagement.Data.Models;
using StoreManagement.Data.Models.ViewModels;

namespace StoreManagement.Pages.Admin.Products
{
    public class AddOrEditModel : PageModel
    {
        private readonly ProductDbContext _dbContext;
        private readonly IToastNotification _toastNotification;
        private readonly IMapper _mapper;

        [BindProperty(SupportsGet = true)]
        public ProductViewModel Product { get; set; }

        public AddOrEditModel(ProductDbContext context,
                              IToastNotification toastNotification,
                              IMapper mapper)
        {
            _dbContext = context;
            _toastNotification = toastNotification;
            _mapper = mapper;
        }
        public async void OnGet(string? productId)
        {
            if (productId != null)
            {
                Product? prodcutToEdit = await _dbContext.Product.FirstOrDefaultAsync(p => p.ProductID.ToString() == productId);

                Product = _mapper.Map<ProductViewModel>(prodcutToEdit);
            }

        }

        public async Task<IActionResult> OnGetDelete(string productId)
        {
            Product? productToDelete = await _dbContext.Product.FirstOrDefaultAsync(p => p.ProductID.ToString() == productId);

            if (productToDelete != null)
            {
                _dbContext.Product.Remove(productToDelete);
                await _dbContext.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage("The Product was deleted successffuly");
                return RedirectToPage("Index");
            }

            _toastNotification.AddErrorToastMessage("Somthing wrong, please try again");
            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPost()
        {


            if (ModelState.IsValid)
            {
                Product productToDb = _mapper.Map<Product>(Product);

                if (Product.ProductID == null)
                {
                    // Add Operation

                    await _dbContext.Product.AddAsync(productToDb);
                    int isSaved = await _dbContext.SaveChangesAsync();
                    if (isSaved > 0)
                    {
                        _toastNotification.AddSuccessToastMessage("The new product was succeffully saved !");
                        return RedirectToPage("Index");
                    }
                    else
                    {
                        _toastNotification.AddErrorToastMessage("The new product is not saved ! Please try again");
                        return Page();

                    }

                }

                else
                {
                    // Update Operation

                    _dbContext.Product.Update(productToDb);
                    await _dbContext.SaveChangesAsync();
                    _toastNotification.AddSuccessToastMessage("The new product was succeffully updated !");
                    return RedirectToPage("Index");

                }
            }

            return Page();
        }

    }
}
