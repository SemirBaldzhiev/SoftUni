    using System;

    namespace _01._CounterStrike
    {
        class Program
        {
            static void Main(string[] args)
            {
                int initialEnergy = int.Parse(Console.ReadLine());

                int count = 0;

                while (true)
                {
                    string line = Console.ReadLine();

                    if (line == "End of battle")
                    {
                        Console.WriteLine($"Won battles: {count}. Energy left: {initialEnergy}");
                        break;
                    }

                    int distance = int.Parse(line);

                    if (initialEnergy - distance < 0)
                    {
                        Console.WriteLine($"Not enough energy! Game ends with {count} won battles and {initialEnergy} energy");
                        break;
                    }

                    initialEnergy -= distance;
                    count++;


                    if (count % 3 == 0)
                    {
                        initialEnergy += count;
                    }

                }

            }
        }
    }
