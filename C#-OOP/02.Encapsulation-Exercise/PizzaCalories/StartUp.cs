using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string pizzaName = Console.ReadLine().Split()[1];
            string[] doughData = Console.ReadLine().Split().ToArray();

            string flourType = doughData[1];
            string bakingTechnique = doughData[2];
            int weight = int.Parse(doughData[3]);

            try
            {
                Dough dough = new Dough(flourType, bakingTechnique, weight);

                Pizza pizza = new Pizza(pizzaName, dough);

                while (true)
                {
                    string line = Console.ReadLine();

                    if (line == "END")
                    {
                        break;
                    }

                    string[] toppingData = line.Split().ToArray();

                    string toppingName = toppingData[1];
                    int toppingWeight = int.Parse(toppingData[2]);

                    Topping topping = new Topping(toppingName, toppingWeight);

                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetCalories():F2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
