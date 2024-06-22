using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeManagementSystemNKPlus.Application.Interfaces;
using RecipeManagementSystemNKPlus.Domain.Entities;

namespace RecipeManagementSystemNKPlus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController(IGenericOwnedRepository<Ingredient> ingredientRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetIngredientsAsync()
        {
            var results = await ingredientRepository.GetAllAsync();
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIngredientByIdAsync(int id)
        {
            var result = await ingredientRepository.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddIngredientAsync(Ingredient ingredient)
        {
            var result = await ingredientRepository.AddAsync(ingredient);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateIngredientAsync(Ingredient ingredient)
        {
            var result = await ingredientRepository.UpdateAsync(ingredient);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteIngredientAsync(int id)
        {
            var result = await ingredientRepository.DeleteAsync(id);
            return Ok(result);
        }
    }
}
