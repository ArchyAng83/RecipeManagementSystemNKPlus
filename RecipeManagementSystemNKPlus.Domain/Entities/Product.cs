using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RecipeManagementSystemNKPlus.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Unique]
        public string Name { get; set; }

        public int Quantity { get; set; }

        public double Weight { get; set; }

        public string Description { get; set; } = string.Empty;

        public List<Composite>? Composites { get; set; }

        //[JsonIgnore]
        public List<ProductComposite>? ProductComposites { get; set; } = new();
    }
}
