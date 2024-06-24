using RecipeManagementSystemNKPlus.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagementSystemNKPlus.Application.Interfaces
{
    public interface IGenericOwnedService<T> where T : class
    {
        Task<List<T>?> GetAllAsync(string baseUrl);
        Task<T?> GetByIdAsync(string baseUrl, int id);
        Task<GeneralResponse> AddAsync(string baseUrl, T entity);
        Task<GeneralResponse> UpdateAsync(string baseUrl, T entity);
        Task<GeneralResponse> DeleteAsync(string baseUrl, int id);
    }
}
