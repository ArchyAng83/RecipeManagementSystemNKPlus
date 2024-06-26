using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RecipeManagementSystemNKPlus.Domain.Entities
{
    public class Composite
    {    
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int CompositeTypeId { get; set; }

        public CompositeType CompositeType { get; set; }

        public int IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }

        public double Weight { get; set; }
    }
}
