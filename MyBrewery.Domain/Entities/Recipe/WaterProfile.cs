namespace MyBrewery.Domain.Models
{
    public class WaterProfile
    {
        public double Calcium { get; set; } //Ca+2
        public double Magnesium { get; set; } //Mg+2
        public double Sodium { get; set; } //Na+
        public double Chloride { get; set; } //Cl-
        public double Sulfate { get; set; } //SO4-2
        public double Bicarbonate { get; set; } //HCO3-

    }
}