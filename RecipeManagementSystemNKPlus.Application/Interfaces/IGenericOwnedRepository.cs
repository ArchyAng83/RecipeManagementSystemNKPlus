using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeManagementSystemNKPlus.Application.DTOs;

namespace RecipeManagementSystemNKPlus.Application.Interfaces
{
    public interface IGenericOwnedRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<GeneralResponse> AddAsync(T entity);
        Task<GeneralResponse> UpdateAsync(T entity);
        Task<GeneralResponse> DeleteAsync(int id);
    }
}
