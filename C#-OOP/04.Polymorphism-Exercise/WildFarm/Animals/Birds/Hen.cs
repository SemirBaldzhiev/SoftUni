using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        private const double HenWeightModifier = 0.35;
        private static HashSet<string> henAllowedFoods = new HashSet<string>
        {
            nameof(Fruit),
            nameof(Meat),
            nameof(Seeds),
            nameof(Vegetable)
        };
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, henAllowedFoods, HenWeightModifier, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
