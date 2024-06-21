using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagementSystemNKPlus.Domain.Entities
{
    public class ProductCompositeType
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int CompositeTypeId { get; set; }

        public CompositeType CompositeType { get; set; }
    }
}
