using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        private const double CatWeightModifier = 0.3;
        private static HashSet<string> catAllowedFoods = new HashSet<string>
        {
            nameof(Meat),
            nameof(Vegetable)
        };
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, catAllowedFoods, CatWeightModifier, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
