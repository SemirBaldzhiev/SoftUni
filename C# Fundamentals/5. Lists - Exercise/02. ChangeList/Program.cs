using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] commands = line.Split().ToArray();
                int element = int.Parse(commands[1]);
                switch (commands[0])
                {
                    case "Delete":
                        numbers.RemoveAll(x => x == element);
                        break;
                    case "Insert":
                        int possition = int.Parse(commands[2]);
                        numbers.Insert(possition, element);
                        break;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
