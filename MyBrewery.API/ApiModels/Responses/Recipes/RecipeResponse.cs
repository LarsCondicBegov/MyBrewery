using System;

namespace MyBrewery.API.ApiModels.Responses.Recipes
{
    public class RecipeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
        public string Notes { get; set; }
        public DateTime BrewDate { get; set; }
        public decimal OriginalGravity { get; set; }
        public decimal FinalGravity { get; set; }
        public decimal ABV { get; set; }
        public decimal IBU { get; set; }
        public decimal SRM { get; set; }
        public decimal Carbs { get; set; }
        public int Calories { get; set; }
        public decimal Efficiency { get; set; }
    }
}
