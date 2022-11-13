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
        private readonly ProductDbContext _context;

        public IEnumerable<Category> CategoryList { get; set; }

        public IndexModel(ProductDbContext context)
        {
            _context = context;
        }
        public async Task OnGet()
        {
            CategoryList = await _context.Category.OrderBy(c=>c.Libelle).ToListAsync();
        }
    }
}
