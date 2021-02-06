using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine().Split().ToArray();

                string model = carData[0];
                double fuel = double.Parse(carData[1]);
                double fuelPerKm = double.Parse(carData[2]);

                Car car = new Car(model, fuel, fuelPerKm);

                cars.Add(car);
            }


            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] commands = line.Split().ToArray();

                if (commands[0] == "Drive")
                {
                    string model = commands[1];
                    double distance = double.Parse(commands[2]);

                    var car = cars.Where(c => c.Model == model).FirstOrDefault();

                    car.Drive(distance);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
