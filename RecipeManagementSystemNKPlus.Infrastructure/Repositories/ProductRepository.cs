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

        //public async Task<List<Product>> GetAllAsync() => await context.Products.ToListAsync();
        public async Task<List<Product>> GetAllAsync() =>
             await context.Products
            .Include(i => i.ProductComposites!)
            .ToListAsync();


        //public async Task<Product?> GetByIdAsync(int id) => await context.Products.FindAsync(id);
        public async Task<Product?> GetByIdAsync(int id) =>
            await context.Products
            .Include(i => i.ProductComposites!)
            .ThenInclude(i => i.Composite)
            .ThenInclude(i => i!.CompositeType)
            .ThenInclude(i => i!.Composites!)
            .ThenInclude(i => i!.Ingredient)
            .FirstOrDefaultAsync(i => i.Id == id);

        public Task<GeneralResponse> UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
