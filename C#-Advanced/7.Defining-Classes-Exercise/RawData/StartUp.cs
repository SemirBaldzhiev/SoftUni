using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine().Split().ToArray();

                string model = carData[0];
                int speed = int.Parse(carData[1]);
                int power = int.Parse(carData[2]);
                int weight = int.Parse(carData[3]);
                string type = carData[4];

                Engine engine = new Engine(speed, power);
                Cargo cargo = new Cargo(weight, type);

                List<Tire> tires = new List<Tire>();

                for (int j = 5; j < carData.Length; j++)
                {
                    double pressure = double.Parse(carData[j]);
                    int age = int.Parse(carData[j + 1]);
                    Tire tire = new Tire(pressure, age);
                    tires.Add(tire);
                    j++;
                }

                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string criteria = Console.ReadLine();

            List<string> models = new List<string>(); ;

            if (criteria == "fragile")
            {
                models = cars.Where(c => c.Cargo.Type == criteria).Where(c => c.Tires.Any(t => t.Pressure < 1)).Select(c => c.Model).ToList();
            }
            else if (criteria == "flamable")
            {
                models = cars.Where(c => c.Cargo.Type == criteria).Where(c => c.Engine.Power > 250).Select(c => c.Model).ToList();
            }

            foreach (var model in models)
            {
                Console.WriteLine(model);
            }
        }
    }
}
