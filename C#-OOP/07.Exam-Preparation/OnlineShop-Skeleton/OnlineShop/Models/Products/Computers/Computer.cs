using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public override double OverallPerformance => CalculateOverallPerformance();
        public override decimal Price => CalculatePrice();
        
        public IReadOnlyCollection<IComponent> Components => components.ToList().AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.ToList().AsReadOnly();

        public void AddComponent(IComponent component)
        {
            if (this.Components.Contains(component))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, 
                    component.GetType().Name, this.GetType().Name, this.Id));
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Contains(peripheral))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, 
                    peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var component = this.Components.FirstOrDefault(c => c.GetType().Name == componentType);

            if (this.components.Count == 0 || component == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent,
                    componentType, this.GetType().Name, this.Id));
            }

            this.components.Remove(component);

            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var peripheral = this.peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);

            if (this.peripherals.Count == 0 || peripheral == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral,
                    peripheralType, this.GetType().Name, this.Id));
            }

            this.peripherals.Remove(peripheral);

            return peripheral;
        }

        private double CalculateOverallPerformance()
        {
            if (this.Components.Count == 0)
            {
                return base.OverallPerformance;
            }
            else
            {
                return base.OverallPerformance + this.Components.Average(c => c.OverallPerformance);
            }
        }

        private decimal CalculatePrice()
        {
            return base.Price + this.Components.Sum(c => c.Price) + Peripherals.Sum(p => p.Price);
        }


        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Overall Performance: {this.OverallPerformance:F2}. Price: {this.Price:F2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");
            sb.AppendLine($" Components ({this.components.Count}):");
            if (components.Count != 0)
            {
                this.components.ToList().ForEach(c => sb.AppendLine($"  {c.ToString()}"));
            }

            if (peripherals.Count != 0)
            {
                sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({this.peripherals.Average(p => p.OverallPerformance):F2}):");
                this.peripherals.ToList().ForEach(p => sb.AppendLine($"  {p.ToString()}"));
            }
            else
            {
                sb.AppendLine($" Peripherals (0); Average Overall Performance (0.00):");

            }

            return sb.ToString().TrimEnd();
        }
    }
}
