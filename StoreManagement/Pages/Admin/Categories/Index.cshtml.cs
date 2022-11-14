using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using StoreManagement.Data;
using StoreManagement.Data.Models;
using StoreManagement.Data.Models.ViewModels;
using StoreManagement.Service.Interfaces;

namespace StoreManagement.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ProductDbContext _dbContext;
        private readonly ICategoryService _categoryService;

        public IEnumerable<CategoryViewModel> CategoryList { get; set; }
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public IndexModel(ProductDbContext context, ICategoryService categoryService)
        {
            _dbContext = context;
            _categoryService = categoryService;
        }
        public async Task OnGet()
        {
            CategoryList = await _categoryService.GetBySearchTerm(SearchTerm);
        }

    }
}
