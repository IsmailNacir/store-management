using StoreManagement.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetBySearchTerm(string searchTerm);
        Task<bool> DeleteCategory(Guid categoryId);
        Task<bool> AddCategory(CategoryViewModel newCategory);
    }
}
