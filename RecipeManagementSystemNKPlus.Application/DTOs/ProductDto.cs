using RecipeManagementSystemNKPlus.Domain.Entities;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagementSystemNKPlus.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Unique]
        public string Name { get; set; }

        public int Quantity { get; set; }

        public double Weight { get; set; }

        public string Description { get; set; } = string.Empty;

        public List<CompositeDto>? Composites { get; set; } = new();
    }
}
