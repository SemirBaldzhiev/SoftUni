using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
        

        public Parking(int capacity)
        {
            this.Capacity = capacity;
            this.Cars = new List<Car>();
            this.Count = 0;
        }


        public int Count { get; set; }
        public int Capacity
        {
            get => this.capacity;
            set => this.capacity = value;
        }
        public List<Car> Cars 
        { 
            get => this.cars; 
            set => this.cars = value; 
        }

        public string AddCar(Car car)
        {
            if (ChekRegistrationNumberExist(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (cars.Count >= capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car);
            this.Count++;

            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";

        }

        public string RemoveCar(string regNumber)
        {
            if (!ChekRegistrationNumberExist(regNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }

            Car car = GetCar(regNumber);

            cars.Remove(car);
            this.Count--;

            return $"Successfully removed {car.RegistrationNumber}";
        }

        public Car GetCar(string regNumber)
        {
            Car car = cars.Where(c => c.RegistrationNumber == regNumber).FirstOrDefault();

            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> regNumbers)
        {
            foreach (var number in regNumbers)
            {
                if (cars.Select(c => c.RegistrationNumber).Contains(number))
                {
                    RemoveCar(number);
                }
            }
        }

        private bool ChekRegistrationNumberExist(string regNumber)
        {
            return cars.Select(c => c.RegistrationNumber).Contains(regNumber);
        }

    }
}
