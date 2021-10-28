using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBrewery.Domain.Models
{
    public class Recipe : Entity
    {
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
        /*
        public List<Fermentable> Fermentables { get; set; }
        public List<Hop> Hops { get; set; }
        public Yeast Yeast { get; set; }
        public Priming Priming { get; set; }
        public WaterProfile WaterProfile { get; set; }
        */

    }
}
