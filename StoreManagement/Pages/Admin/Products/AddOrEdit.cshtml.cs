using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using StoreManagement.Data;
using StoreManagement.Data.Models;
using StoreManagement.Data.Models.ViewModels;
using StoreManagement.Service.Interfaces;

namespace StoreManagement.Pages.Admin.Products
{
    public class AddOrEditModel : PageModel
    {
        private readonly ProductDbContext _dbContext;
        private readonly IToastNotification _toastNotification;
        private readonly IProductService _productService;
        [BindProperty(SupportsGet = true)]
        public ProductViewModel Product { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }

        public AddOrEditModel(ProductDbContext context,
                              IToastNotification toastNotification,
                              IProductService productService)
        {
            _dbContext = context;
            _toastNotification = toastNotification;
            _productService = productService;
            Product = new ProductViewModel();
        }
        public async void OnGet(string? productId)
        {
            if (productId != null)
            {
                Product = await _productService.GetById(productId.ToString());
            }

            CategoryList = _dbContext.Category.Select(c => new SelectListItem
            {
                Text = c.Libelle,
                Value = c.CategoryId.ToString()
            });

        }

        public async Task<IActionResult> OnGetDelete(string productId)
        {
            var response = await _productService.DeleteProduct(productId);

            if (response)
            {
                _toastNotification.AddSuccessToastMessage("The Product was deleted successffuly");
            }
            else
            {
                _toastNotification.AddErrorToastMessage("Somthing wrong, please try again");
            }
            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {

                var response = await _productService.UpdateOrAddProduct(Product.ProductId.ToString(), Product);

                if (response && Product.ProductId == null)
                {
                    _toastNotification.AddSuccessToastMessage("The new product was succeffully saved !");
                    return RedirectToPage("Index");
                }

                else
                {
                    if (response && Product.ProductId != null)
                    {
                        _toastNotification.AddSuccessToastMessage("The new product was succeffully updated !");
                        return RedirectToPage("Index");
                    }
                }
            }

            return Page();
        }

    }
}
