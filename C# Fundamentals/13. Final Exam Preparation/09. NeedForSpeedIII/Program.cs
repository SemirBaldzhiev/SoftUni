using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._NeedForSpeedIII
{
    public class Car
    {
        public string Model { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }

        public Car(string model, int mileage, int fuel)
        {
            this.Model = model;
            this.Mileage = mileage;
            this.Fuel = fuel;
        }

        public override string ToString()
        {
            return $"{this.Model} -> Mileage: {this.Mileage} kms, Fuel in the tank: {this.Fuel} lt.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int nuberOfcars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < nuberOfcars; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Car car = new Car(tokens[0], int.Parse(tokens[1]), int.Parse(tokens[2]));

                cars.Add(car);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Stop")
                {
                    break;
                }

                string[] commands = input
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var car = cars.Where(x => x.Model == commands[1]).FirstOrDefault();
                int fuel = 0;

                switch (commands[0])
                {
                    case "Drive":
                        int distance = int.Parse(commands[2]);
                        fuel = int.Parse(commands[3]);

                        if (car.Fuel >= fuel)
                        {
                            car.Mileage += distance;
                            car.Fuel -= fuel;
                            Console.WriteLine($"{car.Model} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                        }
                        else
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }

                        if (car.Mileage >= 100000)
                        {
                            cars.Remove(car);
                            Console.WriteLine($"Time to sell the {car.Model}!");
                        }
                        break;
                    case "Refuel":
                        fuel = int.Parse(commands[2]);

                        if (car.Fuel + fuel <= 75)
                        {
                            car.Fuel += fuel;
                        }
                        else
                        {
                            fuel = 75 - car.Fuel;
                            car.Fuel += fuel;
                        }

                        Console.WriteLine($"{car.Model} refueled with {fuel} liters");
                        break;
                    case "Revert":
                        int kilometers = int.Parse(commands[2]);

                        car.Mileage -= kilometers;

                        if (car.Mileage < 10000)
                        {
                            car.Mileage = 10000;
                        }
                        else
                        {
                            Console.WriteLine($"{car.Model} mileage decreased by {kilometers} kilometers");
                        }

                        break;
                }
            }

            foreach (var car in cars.OrderByDescending(x => x.Mileage).ThenBy(x => x.Model)) 
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
