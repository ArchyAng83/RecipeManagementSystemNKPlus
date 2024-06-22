using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeManagementSystemNKPlus.Application.Interfaces;
using RecipeManagementSystemNKPlus.Domain.Entities;

namespace RecipeManagementSystemNKPlus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompositeTypeController(IGenericOwnedRepository<CompositeType> compositeTypeRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCompositeTypesAsync()
        {
            var results = await compositeTypeRepository.GetAllAsync();
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompositeTypeByIdAsync(int id)
        {
            var result = await compositeTypeRepository.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCompositeTypeAsync(CompositeType compositeType)
        {
            var result = await compositeTypeRepository.AddAsync(compositeType);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompositeTypeAsync(CompositeType compositeType)
        {
            var result = await compositeTypeRepository.UpdateAsync(compositeType);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCompositeTypeAsync(int id)
        {
            var result = await compositeTypeRepository.DeleteAsync(id);
            return Ok(result);
        }
    }
}
