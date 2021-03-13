using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double BusAirConditionerModifier = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, BusAirConditionerModifier, tankCapacity)
        {
        }
        public void DriveEmpty(double distance)
        {
            double neededFuel = (FuelConsumption) * distance;

            if (neededFuel > FuelQuantity)
            {
                throw new InvalidOperationException($"{GetType().Name} needs refueling");
            }

            FuelQuantity -= neededFuel;
        }

    }
}
