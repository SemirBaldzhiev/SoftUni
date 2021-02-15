using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> items = new Dictionary<int, string>()
            {
                {25, "Bread" },
                {50, "Cake" },
                {75, "Pastry" },
                {100, "Fruit Pie" }
            };

            Dictionary<string, int> itemsCount = new Dictionary<string, int>()
            {
                {"Bread", 0 },
                { "Cake", 0 },
                {"Fruit Pie", 0},
                { "Pastry", 0 }
            };

            int[] inputLiquids = Console.ReadLine().Split().Select(int.Parse).ToArray(); ;
            int[] inputIngredients = Console.ReadLine().Split().Select(int.Parse).ToArray(); ;

            Queue<int> liquids = new Queue<int>(inputLiquids);
            Stack<int> ingredients = new Stack<int>(inputIngredients);

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int liquid = liquids.Dequeue();
                int ingredient = ingredients.Pop();

                int sum = liquid + ingredient;

                if (items.ContainsKey(sum))
                {
                    itemsCount[items[sum]]++;
                }
                else
                {
                    ingredient += 3;
                    ingredients.Push(ingredient);
                }
            }

            if (itemsCount.Values.All(x => x >= 1))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            foreach (var item in itemsCount)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

        }
    }
}
