using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            List<Vehicle> vehicles = new List<Vehicle>();

            while (line != "End")
            {
                string[] tokens = line.Split().ToArray();

                Vehicle vehicle = new Vehicle(tokens[0], tokens[1], tokens[2], int.Parse(tokens[3]));

                vehicles.Add(vehicle);

                line = Console.ReadLine();
            }

            string model = Console.ReadLine();

            while (model != "Close the Catalogue")
            {
                var printVehicle = vehicles.Where(x => x.Model == model).FirstOrDefault();

                Console.WriteLine($"Type: {printVehicle.Type[0].ToString().ToUpper() + printVehicle.Type[1..printVehicle.Type.Length]}");
                Console.WriteLine($"Model: {printVehicle.Model}");
                Console.WriteLine($"Color: {printVehicle.Color}");
                Console.WriteLine($"Horsepower: {printVehicle.Horsepower}");

                model = Console.ReadLine();
            }

            double sumCarsHorsepower = vehicles.Where(x => x.Type == "car").Sum(x => x.Horsepower);
            double countTypeOfCars = vehicles.Where(x => x.Type == "car").Count();
            double averageCarHorsepower = sumCarsHorsepower / (double)countTypeOfCars;

            double sumTrucksHorsepower = vehicles.Where(x => x.Type == "truck").Sum(x => x.Horsepower);
            double countTypeOfTrucks = vehicles.Where(x => x.Type == "truck").Count();
            double averageTruckHorsepower = (double)sumTrucksHorsepower / (double)countTypeOfTrucks;

            if (countTypeOfCars <= 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {averageCarHorsepower:f2}.");
            }
            if (countTypeOfTrucks <= 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {averageTruckHorsepower:f2}.");
            }
            
        }
        
    }

    public class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }

        public Vehicle(string type, string model, string color, int horsepower)
        {
            Type = type;
            Model = model;
            Color = color;
            Horsepower = horsepower;
        }

    }
}
