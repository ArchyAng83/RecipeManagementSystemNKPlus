using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RecipeManagementSystemNKPlus.Domain.Entities
{
    public class CompositeType
    {
        public int Id { get; set; }

        [Unique]
        public string Name { get; set; }

        public List<Ingredient>? Ingredients { get; set; }

        [JsonIgnore]
        public List<Product>? Products { get; set; } 

        [JsonIgnore]
        public List<Composite>? Composites { get; set; }
    }
}
