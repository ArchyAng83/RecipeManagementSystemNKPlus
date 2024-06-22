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

        public string Name { get; set; }

        [JsonIgnore]
        public List<Composite>? Composites { get; set; }
    }
}
