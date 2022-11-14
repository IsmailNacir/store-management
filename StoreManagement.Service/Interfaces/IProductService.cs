using StoreManagement.Data.Models;
using StoreManagement.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Service.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetBySearchTerm(string searchTerm);
        Task<bool> DeleteProduct(string productId);
        Task<bool> UpdateOrAddProduct(string? productId, ProductViewModel newProduct);
        Task<ProductViewModel> GetById(string productId);
    }
}
