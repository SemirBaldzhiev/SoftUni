using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            var type = new ComponentType();

            var computer = computers.FirstOrDefault(c => c.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            if (components.Select(c => c.Id).Contains(id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComponent component = null;
 
            if (!Enum.TryParse(componentType, out type))
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }
            else if (type == ComponentType.CentralProcessingUnit)
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (type == ComponentType.Motherboard)
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (type == ComponentType.PowerSupply)
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (type == ComponentType.RandomAccessMemory)
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (type == ComponentType.SolidStateDrive)
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (type == ComponentType.VideoCard)
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }

            components.Add(component);
            computer.AddComponent(component);

            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            var type = new ComputerType();

            if (this.computers.Select(c => c.Id).Contains(id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            IComputer computer = null;

            if (!Enum.TryParse(computerType, out type))
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }
            else if (type == ComputerType.Laptop)
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if (type == ComputerType.DesktopComputer)
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }

            computers.Add(computer);
            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            var type = new PeripheralType();

            var computer = computers.FirstOrDefault(c => c.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            if (peripherals.Select(c => c.Id).Contains(id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IPeripheral peripheral = null;

            if (!Enum.TryParse(peripheralType, out type))
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }
            else if (type == PeripheralType.Headset)
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (type == PeripheralType.Keyboard)
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (type == PeripheralType.Monitor)
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (type == PeripheralType.Mouse)
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }

            peripherals.Add(peripheral);
            computer.AddPeripheral(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);

        }

        public string BuyBest(decimal budget)
        {
            if (computers.Count == 0 || !computers.Any(c => c.Price <= budget))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            var computer = computers.Where(c => c.Price <= budget).OrderByDescending(c => c.OverallPerformance).FirstOrDefault();

            computers.Remove(computer);

            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            var computer = computers.FirstOrDefault(c => c.Id == id);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            var computer = computers.FirstOrDefault(c => c.Id == id);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            var computer = computers.FirstOrDefault(c => c.Id == computerId);
            var item = components.FirstOrDefault(p => p.GetType().Name == componentType);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            computer.RemoveComponent(componentType);
            components.Remove(item);

            return string.Format(SuccessMessages.RemovedComponent, componentType, item.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            var computer = computers.FirstOrDefault(c => c.Id == computerId);
            //var item = peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            var pheripheral = computer.RemovePeripheral(peripheralType);
            peripherals.Remove(pheripheral);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, pheripheral.Id);
        }
    }
}
