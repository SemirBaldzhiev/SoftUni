using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Party!")
                {
                    break;
                }


                string[] commands = line.Split().ToArray();

                var predicate = GetPredicate(commands[1], commands[2]);

                switch (commands[0])
                {
                    case "Double":
                        var filteredNames = names.FindAll(predicate);

                        if (filteredNames.Count > 0)
                        {
                            int index = names.IndexOf(filteredNames[0]);

                            names.InsertRange(index, filteredNames);
                        }

                        break;

                    case "Remove":
                        names.RemoveAll(predicate);
                        break;
                }
            }

            if (names.Count > 0)
            {
                Console.WriteLine(string.Join(", ", names) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string commandType, string value)
        {
            Predicate<string> predicateToReturn = null;

            switch (commandType)
            {
                case "StartsWith":
                    predicateToReturn = name => name.StartsWith(value);
                    break;
                case "EndsWith":
                    predicateToReturn = name => name.EndsWith(value);
                    break;
                case "Length":
                    predicateToReturn = name => name.Length == int.Parse(value);
                    break;
            }

            return predicateToReturn;
        }
    }
}
