using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagementSystemNKPlus.Domain.Entities
{
    public class CompositeType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Composite> Composites { get; set; }

        public List<ProductCompositeType> ProductCompositeTypes { get; set; }
    }
}
