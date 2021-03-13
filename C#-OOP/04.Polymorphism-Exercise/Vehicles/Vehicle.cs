using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption, double airConditioner)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            AirConditioner = airConditioner;
        }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public double AirConditioner { get; set; }

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
            FuelQuantity += amount;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
