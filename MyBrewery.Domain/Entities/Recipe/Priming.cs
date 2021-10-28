namespace MyBrewery.Domain.Models
{
    public class Priming
    {
        public string Type { get; set; }
        public double Amount { get; set; }
        public int Temperature { get; set; }
        public double CO2_Level { get; set; }

    }
}