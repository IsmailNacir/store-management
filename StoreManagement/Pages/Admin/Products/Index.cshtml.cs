using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Data;
using StoreManagement.Data.Models;

namespace StoreManagement.Pages.Admin.Products
{
    public class IndexModel : PageModel
    {
        private readonly ProductDbContext _dbContext;
        public IEnumerable<Product> ProductList { get; set; }
        public IndexModel(ProductDbContext context)
        {
            _dbContext = context;
        }
        public async Task OnGet()
        {
            ProductList = await _dbContext.Product.ToListAsync();
        }
    }
}
