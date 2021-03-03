using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 50;
        private const string InvalidWeight = "{0} weight should be in the range [1..50].";

        private string name;
        private int weight;

        public Topping(string name, int weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfValueIsNotAllowed(new HashSet<string> { "meat", "veggies", "cheese", "sauce" }, value.ToLower(), $"Cannot place {value} on top of your pizza.");
               

                this.name = value;
            }
        }

        public int Weight
        {
            get => this.weight;
            private set
            {
                //Validator.ThrowIfNumberIsNotInRange(MinWeight, MaxWeight, value, $"{this.name} weight should be in the range[{MinWeight}..{MaxWeight}].");
                if (value < MinWeight ||value > MaxWeight)
                {
                    throw new ArgumentException(String.Format(InvalidWeight, this.name));
                }
                
                this.weight = value;
            }
        }

        public double GetCalories()
        {
            double modifier = GetModifier();

            return this.Weight * 2 * modifier;
        }

        private double GetModifier()
        {
            string nameLower = this.Name.ToLower();

            if (nameLower == "meat")
            {
                return 1.2;
            }
            else if (nameLower == "veggies")
            {
                return 0.8;
            }
            else if (nameLower == "cheese")
            {
                return 1.1;
            }

            return 0.9;
        }
    }
}
