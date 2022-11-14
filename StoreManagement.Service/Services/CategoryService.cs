using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Data;
using StoreManagement.Data.Models;
using StoreManagement.Data.Models.ViewModels;
using StoreManagement.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ProductDbContext _dbContext;
        private readonly IMapper _mapper;
        public CategoryService(ProductDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<CategoryViewModel> AddCategory(CategoryViewModel newCategory)
        {
            if(newCategory != null)
            {
                Category categoryToDb = _mapper.Map<Category>(newCategory);
               await _dbContext.Category.AddAsync(categoryToDb);
                await _dbContext.SaveChangesAsync();
                CategoryViewModel result = await GetById(newCategory.CategoryId.ToString());
                return result;
            }
            return null;
        }

        public async Task<bool> DeleteCategory(Guid categoryId)
        {
            Category? categoryToDelete = await _dbContext.Category.FirstOrDefaultAsync(c => c.CategoryId == categoryId);

            if(categoryToDelete !=null)
            {
                _dbContext.Category.Remove(categoryToDelete);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetBySearchTerm(string searchTerm)
        {
            IEnumerable<Category> categories = await _dbContext.Category
                .Where(c => c.Libelle.Contains(searchTerm) || string.IsNullOrEmpty(searchTerm))
                .ToListAsync();

            return _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
        }

        public async Task<CategoryViewModel> GetById(string categoryId)
        {
            Category? category = await _dbContext.Category
                    .SingleOrDefaultAsync(c => c.CategoryId.ToString() == categoryId);

            return _mapper.Map<CategoryViewModel>(category);

        }
    }
}
