using System;
using System.Collections.Generic;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double MouseWeightModifier = 0.1;
        private static HashSet<string> mouseAllowedFoods = new HashSet<string>
        {
            nameof(Fruit),
            nameof(Vegetable)
        };
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, mouseAllowedFoods, MouseWeightModifier, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
