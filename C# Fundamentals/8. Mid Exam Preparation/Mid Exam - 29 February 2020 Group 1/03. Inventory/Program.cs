using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inventory = Console.ReadLine().Split(", ").ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Craft!")
                {
                    Console.WriteLine(string.Join(", ", inventory));
                    break;
                }

                string[] commands = input.Split(" - ").ToArray();

                string item = commands[1];

                switch (commands[0])
                {
                    case "Collect":
                        if (!inventory.Contains(item))
                        {
                            inventory.Add(item);
                        }
                        break;
                    case "Drop":
                        if (inventory.Contains(item))
                        {
                            inventory.Remove(item);
                        }
                        break;
                    case "Combine Items":

                        string[] items = commands[1].Split(":").ToArray();
                        string oldItem = items[0];
                        string newItem = items[1];

                        if (inventory.Contains(oldItem))
                        {
                            int oldItemIndex = inventory.FindIndex(x => x == oldItem);
                            inventory.Insert(oldItemIndex + 1, newItem);
                        }
                        break;
                    case "Renew":
                        if (inventory.Contains(item))
                        {
                            inventory.Remove(item);
                            inventory.Add(item);
                        }
                        break;
                }
            }
        }
    }
}
