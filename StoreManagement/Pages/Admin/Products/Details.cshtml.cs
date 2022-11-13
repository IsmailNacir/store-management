using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Data;
using StoreManagement.Data.Models.ViewModels;

namespace StoreManagement.Pages.Admin.Products
{
    public class DetailsModel : PageModel
    {
        public ProductViewModel Product { get; set; }
        private readonly ProductDbContext _dbContext;
        public DetailsModel(ProductDbContext context)
        {
            _dbContext = context;    
        }
        public async Task OnGet(Guid productId)
        {
            //this.Product = await _context.Product.FindAsync(productId);
        }
    }
}
