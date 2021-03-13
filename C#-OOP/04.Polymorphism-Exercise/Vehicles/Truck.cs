using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double AirConditionerModifier = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption, AirConditionerModifier)
        {
        }

        public override void Refuel(double amount)
        {
            base.Refuel(amount * 0.95);
        }
    }
}
