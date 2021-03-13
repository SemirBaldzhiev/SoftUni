using System;
using System.Linq;

namespace VehiclesExtension
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();
            Vehicle bus = CreateVehicle();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputData = Console.ReadLine().Split().ToArray();

                string command = inputData[0];
                string vehicleType = inputData[1];

                if (command == "Drive")
                {
                    double distance = double.Parse(inputData[2]);
                    try
                    {
                        if (vehicleType == nameof(Car))
                        {
                            car.Drive(distance);
                        }
                        else if (vehicleType == nameof(Truck))
                        {
                            truck.Drive(distance);
                        }
                        else if (vehicleType == nameof(Bus))
                        {
                            bus.Drive(distance);
                        }

                        Console.WriteLine($"{vehicleType} travelled {distance} km");
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "Refuel")
                {
                    double amount = double.Parse(inputData[2]);

                    try
                    {
                        if (vehicleType == nameof(Car))
                        {
                            car.Refuel(amount);
                        }
                        else if (vehicleType == nameof(Truck))
                        {
                            truck.Refuel(amount);
                        }
                        else if (vehicleType == nameof(Bus))
                        {
                            bus.Refuel(amount);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                }
                else if (command == "DriveEmpty")
                {
                    double distance = double.Parse(inputData[2]);
                    try
                    {
                        ((Bus)bus).DriveEmpty(distance);

                        Console.WriteLine($"{vehicleType} travelled {distance} km");
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        public static Vehicle CreateVehicle()
        {
            string[] parts = Console.ReadLine().Split().ToArray();

            string type = parts[0];
            double fuelQuantity = double.Parse(parts[1]);
            double fuelConsumption = double.Parse(parts[2]);
            double tankCapacity = double.Parse(parts[3]);

            Vehicle vehicle = null;

            if (type == nameof(Car))
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == nameof(Truck))
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == nameof(Bus))
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }
            return vehicle;
        }
    }
    
}
