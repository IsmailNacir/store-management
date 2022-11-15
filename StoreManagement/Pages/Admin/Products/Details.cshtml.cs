using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Data;
using StoreManagement.Data.Models.ViewModels;
using StoreManagement.Service.Interfaces;

namespace StoreManagement.Pages.Admin.Products
{
    public class DetailsModel : PageModel
    {
        public ProductViewModel Product { get; set; }
        private readonly IProductService _productService;

        public DetailsModel(IProductService productService)
        {
            _productService = productService;
        }
        public async Task OnGet(Guid productId)
        {
            Product = await _productService.GetById(productId.ToString());
        }
    }
}
