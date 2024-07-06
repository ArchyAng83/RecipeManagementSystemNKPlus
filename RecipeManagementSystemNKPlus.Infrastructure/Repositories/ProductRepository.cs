using Microsoft.EntityFrameworkCore;
using RecipeManagementSystemNKPlus.Application.DTOs;
using RecipeManagementSystemNKPlus.Application.Interfaces;
using RecipeManagementSystemNKPlus.Domain.Entities;
using RecipeManagementSystemNKPlus.Infrastructure.DataAccess;

namespace RecipeManagementSystemNKPlus.Infrastructure.Repositories
{
    public class ProductRepository(RecipeDbContext context) : IGenericOwnedRepository<Product>
    {
        public async Task<GeneralResponse> AddAsync(Product entity)
        {
            if (entity is not null)
            {
                if (!CheckName(entity.Name))
                {
                    return new GeneralResponse(false, "Already exist.");
                }

                context.Products.Add(entity);                
                
                await context.SaveChangesAsync();
                return SaveSuccess();
            }

            return GetNotFound();
        }

        public async Task<GeneralResponse> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity is not null)
            {
                context.Products.Remove(entity);
                await context.SaveChangesAsync();
                return new GeneralResponse(true, "Product deleted successfully!");
            }

            return GetNotFound();
        }

        public async Task<List<Product>> GetAllAsync() => await context.Products.ToListAsync();

        public async Task<Product?> GetByIdAsync(int id) =>
            await context.Products
            .Include(p => p.Composites!)
            .ThenInclude(c => c.CompositeType)
            .Include(p => p.Composites!)
            .ThenInclude(c => c.Ingredient)
            .FirstOrDefaultAsync(i => i.Id == id);

        //var query = from c in context.Composites
        //join p in context.Products on c.ProductId equals p.Id
        //join ct in context.CompositeTypes on c.CompositeTypeId equals ct.Id
        //join i in context.Ingredients on c.IngredientId equals i.Id
        //select new
        //{
        //    ProductId = c.ProductId,
        //    ProductName = p.Name,
        //    CompositeTypeName = ct.Name,
        //    IngredientName = i.Name,
        //    Weight = c.Weight
        //};


        public async Task<GeneralResponse> UpdateAsync(Product entity)
        {
            if (entity is not null)
            {
                context.Products.Update(entity);
                //context.Composites.UpdateRange(entity.Composites!);

                await context.SaveChangesAsync();
                return SaveSuccess();
            }

            return GetNotFound();
        }

        private static GeneralResponse GetNotFound() => new(false, "Product not found.");
        private static GeneralResponse SaveSuccess() => new(true, "Product saved successfully!");

        private bool CheckName(string name)
        {
            var prod = context.Products.Where(c => c.Name.ToLower().Equals(name.ToLower())).FirstOrDefault();

            return prod is null;
        }
    }
}
