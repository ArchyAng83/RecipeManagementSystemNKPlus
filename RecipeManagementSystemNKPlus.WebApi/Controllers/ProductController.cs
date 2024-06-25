using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeManagementSystemNKPlus.Application.Interfaces;
using RecipeManagementSystemNKPlus.Domain.Entities;

namespace RecipeManagementSystemNKPlus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IGenericOwnedRepository<Product> productRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var results = await productRepository.GetAllAsync();
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            var result = await productRepository.GetByIdAsync(id);
            return Ok(result);
        }
    }
}
