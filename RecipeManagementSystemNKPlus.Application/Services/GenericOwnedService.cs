using RecipeManagementSystemNKPlus.Application.DTOs;
using RecipeManagementSystemNKPlus.Application.Interfaces;
using System.Net.Http.Json;

namespace RecipeManagementSystemNKPlus.Application.Services
{
    public class GenericOwnedService<T>(HttpClient httpClient) : IGenericOwnedService<T> where T : class
    {
        public async Task<GeneralResponse> AddAsync(string baseUrl, T entity)
        {
            var response = await httpClient.PostAsJsonAsync($"{baseUrl}", entity);
            var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
            return result!;
        }

        public async Task<GeneralResponse> DeleteAsync(string baseUrl, int id)
        {
            var response = await httpClient.DeleteAsync($"{baseUrl}/{id}");
            var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
            return result!;
        }

        public async Task<List<T>?> GetAllAsync(string baseUrl) => await httpClient.GetFromJsonAsync<List<T>>($"{baseUrl}");

        public async Task<T?> GetByIdAsync(string baseUrl, int id) => await httpClient.GetFromJsonAsync<T>($"{baseUrl}/{id}");

        public async Task<GeneralResponse> UpdateAsync(string baseUrl, T entity)
        {
            var response = await httpClient.PutAsJsonAsync($"{baseUrl}", entity);
            var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
            return result!;
        }
    }
}
