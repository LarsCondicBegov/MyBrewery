namespace MyBrewery.Domain.Models
{
    public class Yeast : Entity
    {
        public double Amount { get; set; }
        public double Attenuation { get; set; }
        public double Temperature { get; set; }

    }
}