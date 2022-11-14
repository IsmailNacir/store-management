using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Data;
using StoreManagement.Data.Models;
using StoreManagement.Data.Models.ViewModels;
using StoreManagement.Service.Interfaces;

namespace StoreManagement.Pages.Admin.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public IEnumerable<ProductViewModel> ProductList { get; set; }
        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }
        public async Task OnGet()
        {
            ProductList = await _productService.GetBySearchTerm(SearchTerm);
        }
    }
}
