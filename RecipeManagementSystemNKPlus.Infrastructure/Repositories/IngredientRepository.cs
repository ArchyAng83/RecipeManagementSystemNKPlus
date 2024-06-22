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
    public class IngredientRepository(RecipeDbContext context) : IGenericOwnedRepository<Ingredient>
    {
        public async Task<GeneralResponse> AddAsync(Ingredient entity)
        {
            if (entity is not null)
            {
                if (!CheckName(entity.Name))
                {
                    return new GeneralResponse(false, "Already exist.");
                }

                context.Ingredients.Add(entity);
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
                context.Ingredients.Remove(entity);
                await context.SaveChangesAsync();
                return new GeneralResponse(true, "Ingredient deleted successfully!");
            }

            return GetNotFound();
        }

        public async Task<List<Ingredient>> GetAllAsync() => await context.Ingredients.ToListAsync();

        public async Task<Ingredient?> GetByIdAsync(int id) => await context.Ingredients.FindAsync(id);

        public async Task<GeneralResponse> UpdateAsync(Ingredient entity)
        {
            if (entity is not null)
            {
                context.Ingredients.Update(entity);
                await context.SaveChangesAsync();
                return SaveSuccess();
            }

            return GetNotFound();
        }

        private static GeneralResponse GetNotFound() => new(false, "Ingredient not found.");
        private static GeneralResponse SaveSuccess() => new(true, "Ingredient saved successfully!");

        private bool CheckName(string name)
        {
            var ing = context.Ingredients.Where(c => c.Name.ToLower().Equals(name.ToLower())).FirstOrDefault();

            return ing is null;
        }
    }
}
