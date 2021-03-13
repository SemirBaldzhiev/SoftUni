using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption, double airConditioner, double tankCapacity)
        {
            FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
            FuelConsumption = fuelConsumption;
            AirConditioner = airConditioner;
            TankCapacity = tankCapacity;
        }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public double AirConditioner { get; set; }

        public double TankCapacity { get; set; }

        public void Drive(double distance)
        {
            double neededFuel = (FuelConsumption + AirConditioner) * distance;

            if (neededFuel > FuelQuantity)
            {
                throw new InvalidOperationException($"{GetType().Name} needs refueling");
            }

            FuelQuantity -= neededFuel;
        }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (FuelQuantity + amount > TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {amount} fuel in the tank");
            }

            FuelQuantity += amount;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
