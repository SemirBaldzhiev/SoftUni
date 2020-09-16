using System;

namespace _07._VendingMachine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double totalMoney = 0.0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Start")
                {
                    break;
                }

                double coins = double.Parse(input);
                
                if (coins == 0.1 || coins == 0.2 || coins == 0.5 || coins == 1 || coins == 2)
                {
                    totalMoney += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }

            }

            while (true)
            {
                string product = Console.ReadLine();

                if (product == "End")
                {
                    Console.WriteLine($"Change: {totalMoney:f2}");
                    break;
                }


                if (product == "Nuts")
                {
                    if (totalMoney < 2.0)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        continue;
                    }
                    totalMoney -= 2.0;
                    Console.WriteLine($"Purchased {product.ToLower()}");

                }
                else if (product == "Water")
                {
                    if (totalMoney < 0.7)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        continue;
                    }
                    totalMoney -= 0.7;
                    Console.WriteLine($"Purchased {product.ToLower()}");

                }
                else if (product == "Crisps")
                {
                    if (totalMoney < 1.5)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        continue;
                    }
                    totalMoney -= 1.5;
                    Console.WriteLine($"Purchased {product.ToLower()}");

                }
                else if (product == "Soda")
                {
                    if (totalMoney < 0.8)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        continue;
                    }
                    totalMoney -= 0.8;
                    Console.WriteLine($"Purchased {product.ToLower()}");

                }
                else if (product == "Coke")
                {
                    if (totalMoney < 1.0)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        continue;
                    }
                    totalMoney -= 1.0;
                    Console.WriteLine($"Purchased {product.ToLower()}");

                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
            }
        }
    }
}
