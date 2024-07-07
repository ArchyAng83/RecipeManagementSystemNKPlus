using RecipeManagementSystemNKPlus.Application.DTOs;
using RecipeManagementSystemNKPlus.Domain.Entities;

namespace RecipeManagementSystemNKPlus.Application.Calculations
{
    public static class Calculation
    {
        public static List<Product> GetResult(Product product, int ctId, int startQuantity, int endQuantity, int step)
        {
            var result = new List<Product>();

            for (int i = startQuantity; i <= endQuantity; i += step)
            {
                var prod = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Weight = product.Weight,
                    Quantity = i,
                    Description = product.Description
                };

                foreach (var (compositeType, ing) in product.CompositeTypes!.Where(ct => ct.Id == ctId).SelectMany(ct => ct.Ingredients!.Select(ing => (ct, ing))))
                {
                    var ings = new Ingredient
                    {
                        Id = ing.Id,
                        Name = ing.Name,
                        Composites = ing.Composites!.Select(c => new Composite
                        {
                            ProductId = c.ProductId,
                            CompositeTypeId = c.CompositeTypeId,
                            IngredientId = c.IngredientId,
                            Weight = c.Weight / prod.Quantity * i,
                        }).ToList()
                    };

                    compositeType.Ingredients!.Add(ings);
                    prod.CompositeTypes!.Add(compositeType);
                }

                result.Add(prod);
            }

            return result;
        }

        public static List<CompositeTypeDto> GetResult(CompositeType compositeType, int qty, int startQuantity, int endQuantity, int step)
        {
            var result = new List<CompositeTypeDto>();

            for (int i = startQuantity; i <= endQuantity; i += step)
            {
                var comp = new CompositeTypeDto() { Name = compositeType.Name, Qty = i};

                foreach (var ingredient in compositeType.Ingredients!)
                {
                    var ing = new IngredientDto() { Name = ingredient.Name };
                    ing.Weight = ingredient.Composites!.Where(c => c.CompositeTypeId == compositeType.Id).Select(x => x.Weight / qty * i).First();
                    comp.Ingredients.Add(ing);
                }

                result.Add(comp);
            }

            return result;
        }
    }
}
