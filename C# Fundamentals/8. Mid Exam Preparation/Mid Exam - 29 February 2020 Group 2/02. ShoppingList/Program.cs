using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceryList = Console.ReadLine().Split('!').ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Go Shopping!")
                {
                    Console.WriteLine(string.Join(", ", groceryList));
                    break;
                }

                string[] commands = input.Split().ToArray();
                string item = commands[1];

                switch (commands[0])
                {
                    case "Urgent":
                        if (!groceryList.Contains(item))
                        {
                            groceryList.Insert(0, item);
                        }
                        break;
                    case "Unnecessary":
                        if (groceryList.Contains(item))
                        {
                            groceryList.Remove(item);
                        }
                        break;
                    case "Correct":
                        if (groceryList.Contains(item))
                        {
                            string newItem = commands[2];
                            int oldItemIndex = groceryList.FindIndex(x => x == item);

                            groceryList[oldItemIndex] = newItem;
                        }
                        break;
                    case "Rearrange":
                        if (groceryList.Contains(item))
                        {
                            groceryList.Remove(item);
                            groceryList.Add(item);
                        }
                        break;
                }
            }
        }
    }
}
