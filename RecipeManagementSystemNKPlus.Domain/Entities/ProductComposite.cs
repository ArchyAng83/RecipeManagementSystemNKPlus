using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RecipeManagementSystemNKPlus.Domain.Entities
{
    public class ProductComposite
    {
        public int ProductId { get; set; }

        [JsonIgnore]
        public Product? Product { get; set; }

        public int CompositeId { get; set; }

        [JsonIgnore]
        public Composite? Composite { get; set; }
    }
}
