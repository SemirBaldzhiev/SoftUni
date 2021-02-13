using System;
using System.Collections.Generic;
using System.Linq;

namespace Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split().Skip(1).ToList();
            ListyIterator<string> list = new ListyIterator<string>(items);

            string command = Console.ReadLine();

            while (command != "END")
            {
                switch (command)
                {
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;
                    case "Print":
                        try
                        {
                            list.Print();
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "PrintAll":
                        foreach (var item in items)
                        {
                            Console.Write($"{item} ");
                        }
                        Console.WriteLine();
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
