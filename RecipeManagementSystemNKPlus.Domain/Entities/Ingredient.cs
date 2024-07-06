using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RecipeManagementSystemNKPlus.Domain.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }

        [Unique]
        [StringLength(3, 50)]
        [Required]
        public string Name { get; set; }

        [JsonIgnore]
        public List<CompositeType>? CompositeTypes { get; set; }

        //[JsonIgnore]
        public List<Composite>? Composites { get; set; } = new();
    }
}
