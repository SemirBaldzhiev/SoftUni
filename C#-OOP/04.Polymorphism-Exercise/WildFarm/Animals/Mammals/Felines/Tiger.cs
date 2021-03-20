using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        private const double TigerWeightModifier = 1.0;
        private static HashSet<string> tigerAllowedFoods = new HashSet<string>
        {
            nameof(Meat)
        };
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, tigerAllowedFoods, TigerWeightModifier, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
