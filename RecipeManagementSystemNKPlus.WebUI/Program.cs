using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RecipeManagementSystemNKPlus.Application.DTOs;
using RecipeManagementSystemNKPlus.Application.Interfaces;
using RecipeManagementSystemNKPlus.Application.Services;
using RecipeManagementSystemNKPlus.Domain.Entities;

namespace RecipeManagementSystemNKPlus.WebUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7224") });

            builder.Services.AddScoped<IGenericOwnedService<CompositeType>, GenericOwnedService<CompositeType>>();
            builder.Services.AddScoped<IGenericOwnedService<Ingredient>, GenericOwnedService<Ingredient>>();
            builder.Services.AddScoped<IGenericOwnedService<Product>, GenericOwnedService<Product>>();
            builder.Services.AddScoped<IGenericOwnedService<ProductDto>, GenericOwnedService<ProductDto>>();

            await builder.Build().RunAsync();
        }
    }
}
