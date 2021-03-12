using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<string, IBuyer> buyersByName = new Dictionary<string, IBuyer>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputData = Console.ReadLine().Split().ToArray();

                string name = inputData[0];
                int age = int.Parse(inputData[1]);

                if (inputData.Length == 3)
                {
                    string group = inputData[2];
                    buyersByName[name] = new Rebel(name, age, group);
                }
                else
                {
                    string id = inputData[2];
                    string birthdate = inputData[3];

                    buyersByName[name] = new Citizen(name, age, id, birthdate);
                }
            }

            while (true)
            {
                string name = Console.ReadLine();

                if (name == "End")
                {
                    break;
                }

                if (!buyersByName.ContainsKey(name))
                {
                    continue;
                }

                IBuyer buyer = buyersByName[name];
                buyer.BuyFood();
            }

            var total = buyersByName.Values.Sum(b => b.Food);

            Console.WriteLine(total);
        }
    }
}
