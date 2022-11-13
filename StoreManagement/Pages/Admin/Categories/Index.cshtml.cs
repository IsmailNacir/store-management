using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using StoreManagement.Data;
using StoreManagement.Data.Models;
using StoreManagement.Data.Models.ViewModels;

namespace StoreManagement.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ProductDbContext _dbContext;

        public IEnumerable<Category> CategoryList { get; set; }

        public IndexModel(ProductDbContext context)
        {
            _dbContext = context;
        }
        public async Task OnGet()
        {
            CategoryList = await _dbContext.Category.OrderBy(c => c.Libelle).ToListAsync();
        }

        public async Task<IActionResult> OnGetDelete(string categoryId)
        {
            Category? categoryToDelete = await _dbContext.Category
                .FirstOrDefaultAsync(c => c.CategoryId.ToString() == categoryId);

            if (categoryToDelete != null)
            {
                _dbContext.Category.Remove(categoryToDelete);
                await _dbContext.SaveChangesAsync();
                await OnGet();
                return Page();
            }
            return Page();
        }
    }
}
