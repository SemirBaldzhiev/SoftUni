using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 200;
        private const string InvalidDoughException = "Invalid type of dough.";

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                string valueAsLower = value.ToLower();

                if (valueAsLower != "white" && valueAsLower != "wholegrain")
                {
                    throw new ArgumentException(InvalidDoughException);
                }

                this.flourType = value;
            }
        }
        public string BakingTechnique 
        { 
            get => bakingTechnique;
            private set
            {
                string valueAsLower = value.ToLower();
                if (valueAsLower != "crispy" && valueAsLower != "chewy" && valueAsLower != "homemade")
                {
                    throw new ArgumentException(InvalidDoughException); 
                }

                bakingTechnique = value;
            }
        }
        public int Weight 
        {
            get => this.weight;
            private set
            {
                Validator.ThrowIfNumberIsNotInRange(MinWeight, MaxWeight, value, $"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");

                this.weight = value;
            }
        }

        public double GetCalories()
        {
            double flourTypeModifier = GetFlourTypeModifier();
            double bakingTechniqueModifier = GetBakingTechniqueModifier();

            return this.Weight * 2 * flourTypeModifier * bakingTechniqueModifier;
        }

        private double GetBakingTechniqueModifier()
        {
            string bakingTechniqueLower = this.BakingTechnique.ToLower();

            if (bakingTechniqueLower == "crispy")
            {
                return 0.9;
            }
            else if (bakingTechniqueLower == "chewy")
            {
                return 1.1;
            }

            return 1;

        }

        private double GetFlourTypeModifier()
        {
            string flourTypeLower = this.FlourType.ToLower();

            if (flourTypeLower == "white")
            {
                return 1.5;
            }

            return 1;
        }
    }
}
