using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagementSystemNKPlus.Application.DTOs
{
    public class CompositeDto
    {
        public int ProductId { get; set; }

        public int CompositeTypeId { get; set; }

        public int IngredientId { get; set; }

        public double Weight { get; set; }
    }
}
