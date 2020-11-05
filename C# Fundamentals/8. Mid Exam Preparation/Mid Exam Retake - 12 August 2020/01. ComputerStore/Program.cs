using System;

namespace _01._ComputerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalPrice = 0;
            double taxes = 0;
            double finalPrice = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "regular" || input == "special")
                {
                    taxes = totalPrice * 0.2;
                    finalPrice = totalPrice + taxes;

                    if (input == "special")
                    {
                        finalPrice = finalPrice - (finalPrice * 0.1);
                    }

                    if (finalPrice > 0)
                    {
                        Console.WriteLine("Congratulations you've just bought a new computer!");
                        Console.WriteLine($"Price without taxes: {totalPrice:f2}$");
                        Console.WriteLine($"Taxes: {taxes:f2}$");
                        Console.WriteLine("-----------");
                        Console.WriteLine($"Total price: {finalPrice:f2}$");
                    }
                    else
                    {
                        Console.WriteLine("Invalid order!");
                    }

                    break;
                }

                double price = double.Parse(input);

                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    continue;
                }

                totalPrice += price;
            }
        }
    }
}
