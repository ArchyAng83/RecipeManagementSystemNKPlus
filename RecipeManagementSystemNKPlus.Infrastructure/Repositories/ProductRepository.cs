using Microsoft.EntityFrameworkCore;
using RecipeManagementSystemNKPlus.Application.DTOs;
using RecipeManagementSystemNKPlus.Application.Interfaces;
using RecipeManagementSystemNKPlus.Domain.Entities;
using RecipeManagementSystemNKPlus.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagementSystemNKPlus.Infrastructure.Repositories
{
    public class ProductRepository(RecipeDbContext context) : IGenericOwnedRepository<Product>
    {
        public Task<GeneralResponse> AddAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllAsync() => await context.Products.ToListAsync();

        public Task<Product?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse> UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
