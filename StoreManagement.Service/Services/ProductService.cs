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
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _dbContext;
        private readonly IMapper _mapper;
        public ProductService(ProductDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<bool> DeleteProduct(string productId)
        {
            Product? productToDelete = await _dbContext.Product.FirstOrDefaultAsync(p => p.ProductId.ToString() == productId);

            if (productToDelete != null)
            {
                _dbContext.Product.Remove(productToDelete);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<ProductViewModel>> GetBySearchTerm(string searchTerm)
        {
            IEnumerable<Product> products = await _dbContext.Product
                .Where(p => p.ProductName.Contains(searchTerm) || string.IsNullOrEmpty(searchTerm))
                .Include(p => p.Category)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }

        public async Task<bool> UpdateOrAddProduct(string? productId, ProductViewModel newProduct)
        {
            Product productToDb = _mapper.Map<Product>(newProduct);

            if (productId == null)
            {
                // Add Operation
                await _dbContext.AddAsync(productToDb);
                await _dbContext.SaveChangesAsync();
                return true;

            }

            else
            {
                // Update Operation
                _dbContext.Product.Update(productToDb);
                await _dbContext.SaveChangesAsync();
                return true;

            }
        }

        public async Task<ProductViewModel> GetById(string productId)
        {
            Product? product = await _dbContext.Product
                                .Include(p => p.Category)
                                .SingleOrDefaultAsync(d => d.ProductId.ToString() == productId);

            return _mapper.Map<ProductViewModel>(product);
        }
    }
}
