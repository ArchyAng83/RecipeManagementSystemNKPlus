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

        public string Name { get; set; }

        public int Quantity { get; set; }

        public double Weight { get; set; }

        public string Description { get; set; } = string.Empty;

        [JsonIgnore]
        public List<ProductCompositeType>? ProductCompositeTypes { get; set; }
    }
}
