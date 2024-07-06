using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeManagementSystemNKPlus.Application.DTOs;
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

        [HttpPost]
        public async Task<IActionResult> AddProductAsync(Product product)
        {
            var result = await productRepository.AddAsync(product);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync(Product product)
        {
        //    var newProduct = new Product
        //    {
        //        Id = product!.Id,
        //        Name = product.Name,
        //        Quantity = product.Quantity,
        //        Weight = product.Weight,
        //        Description = product.Description,
        //        Composites = new()
        //    };

        //    newProduct.Composites.AddRange(product.Composites!);

            var result = await productRepository.UpdateAsync(product);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            var result = await productRepository.DeleteAsync(id);
            return Ok(result);
        }

        [HttpPut("addcomposite")]
        public async Task<IActionResult> UpdateCompositeAsync(ProductDto productDto)
        {
            var prod = await productRepository.GetByIdAsync(productDto.Id);
            prod.Id = productDto.Id;
            prod.Name = productDto.Name;
            prod.Quantity = productDto.Quantity;
            prod.Weight = productDto.Weight;
            prod.Description = productDto.Description;
            prod.Composites = productDto.Composites!.Select(c => new Composite
            {
                ProductId = c.ProductId,
                CompositeTypeId = c.CompositeTypeId,
                IngredientId = c.IngredientId,
                Weight = c.Weight
            }).ToList();

            //    newProduct.Composites.AddRange(product.Composites!);

            var result = await productRepository.UpdateAsync(prod);
            return Ok(result);
        }
    }
}
