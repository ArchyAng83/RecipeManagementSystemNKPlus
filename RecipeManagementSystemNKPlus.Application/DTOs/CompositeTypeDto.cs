namespace RecipeManagementSystemNKPlus.Application.DTOs
{
    public class CompositeTypeDto
    {
        public string Name { get; set; }

        public int Qty { get; set; }

        public List<IngredientDto> Ingredients { get; set; } = new();
    }
}
