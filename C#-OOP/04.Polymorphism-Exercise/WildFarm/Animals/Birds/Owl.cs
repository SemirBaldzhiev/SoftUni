using System;
using System.Collections.Generic;
using WildFarm.Foods;

namespace WildFarm.Animals.Birds
{
    public class Owl : Bird
    {
        private const double OwlWeightModifier = 0.25;
        private static HashSet<string> owlAllowedFoods = new HashSet<string>
        {
            nameof(Meat)
        };
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, owlAllowedFoods, OwlWeightModifier, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
