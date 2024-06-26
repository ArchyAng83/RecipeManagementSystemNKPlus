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
    public class CompositeTypeRepository(RecipeDbContext context) : IGenericOwnedRepository<CompositeType>
    {
        public async Task<GeneralResponse> AddAsync(CompositeType entity)
        {   
            if (entity is not null)
            {
                if (!CheckName(entity.Name))
                {
                    return new GeneralResponse(false, "Already exist.");
                }

                context.CompositeTypes.Add(entity);
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
                context.CompositeTypes.Remove(entity);
                await context.SaveChangesAsync();
                return new GeneralResponse(true, "CompositeType deleted successfully!");
            }

            return GetNotFound();
        }        

        public async Task<List<CompositeType>> GetAllAsync() => await context.CompositeTypes.Include(i => i.Ingredients).ToListAsync();

        public async Task<CompositeType?> GetByIdAsync(int id) => await context.CompositeTypes.FindAsync(id);

        public async Task<GeneralResponse> UpdateAsync(CompositeType entity)
        {
            if (entity is not null)
            {
                if (!CheckName(entity.Name))
                {
                    return new GeneralResponse(false, "Already exist.");
                }

                context.CompositeTypes.Update(entity);
                await context.SaveChangesAsync();
                return SaveSuccess();
            }

            return GetNotFound();
        }

        private static GeneralResponse GetNotFound() => new(false, "CompositeType not found.");
        private static GeneralResponse SaveSuccess() => new(true, "CompositeType saved successfully!");
        
        private bool CheckName(string name)
        {
            var ct = context.CompositeTypes.Where(c => c.Name.ToLower().Equals(name.ToLower())).FirstOrDefault();

            return ct is null;
        }
    }
}
