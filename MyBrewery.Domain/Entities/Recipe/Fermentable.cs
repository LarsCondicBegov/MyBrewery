namespace MyBrewery.Domain.Models
{
    public class Fermentable : Entity
    {
        public int RecipeId { get; set; }
        public decimal Amount { get; set; } //kg
        public decimal Ppg { get; set; } // (Gravity) Points per Pound Gallon
        public decimal Colour { get; set; } //°L
        public decimal Bill { get; set; } //%
        public bool LateAddition {  get; set; }
        public FermentableEnum Type {  get; set; }
    }

    public enum FermentableEnum
    {
        Malt,
        Malt_Extract,
        Sugar
    }
}