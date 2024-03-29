﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO.Input;
using CarDealer.DTO.Output;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{

    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //string suppliersJson = File.ReadAllText("../../../Datasets/suppliers.json");
            //string partsJson = File.ReadAllText("../../../Datasets/parts.json");
            //string carsJson = File.ReadAllText("../../../Datasets/cars.json");
            //string customesrJson = File.ReadAllText("../../../Datasets/customers.json");
            //string salesJson = File.ReadAllText("../../../Datasets/sales.json");


            //string suppliersResult = ImportSuppliers(context, suppliersJson);
            //string partsResult = ImportParts(context, partsJson);
            //string carsResult = ImportCars(context, carsJson);
            //string customersResult = ImportCustomers(context, customesrJson);
            //string salesResult = ImportSales(context, salesJson);


            //Console.WriteLine(suppliersResult);
            //Console.WriteLine(partsResult);
            //Console.WriteLine(carsResult);
            //Console.WriteLine(customersResult);
            //Console.WriteLine(salesResult);

            //Console.WriteLine(GetOrderedCustomers(context));
            //Console.WriteLine(GetCarsFromMakeToyota(context));
            //Console.WriteLine(GetLocalSuppliers(context));
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));

            Console.WriteLine(GetSalesWithAppliedDiscount(context));


        }

        // Import Problems
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IEnumerable<SupplierInputDto> suppliers = JsonConvert.DeserializeObject<IEnumerable<SupplierInputDto>>(inputJson);

            InitializeMapper();

            var mappedSuppliers = mapper.Map<IEnumerable<Supplier>>(suppliers);

            context.Suppliers.AddRange(mappedSuppliers);
            context.SaveChanges();

            return $"Successfully imported {mappedSuppliers.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<IEnumerable<PartInputDto>>(inputJson)
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId));

            InitializeMapper();

            var mappedParts = mapper.Map<IEnumerable<Part>>(parts);

            context.Parts.AddRange(mappedParts);
            context.SaveChanges();

            return $"Successfully imported {mappedParts.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<IEnumerable<CarInputDto>>(inputJson);

            foreach (var car in cars)
            {
                var newCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                context.Cars.Add(newCar); 

                foreach (var id in car.PartsId)
                {
                    var partCar = new PartCar
                    {
                        PartId = id,
                        CarId = newCar.Id
                    };

                    if (newCar.PartCars.FirstOrDefault(pc => pc.PartId == id) == null)
                    {
                        context.PartCars.Add(partCar);
                    }
                }
            }

            context.SaveChanges();


            return $"Successfully imported {cars.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<IEnumerable<CustomerInputDto>>(inputJson);

            InitializeMapper();

            var mappedCustomrers = mapper.Map<IEnumerable<Customer>>(customers);

            context.Customers.AddRange(mappedCustomrers);

            context.SaveChanges();

            return $"Successfully imported {mappedCustomrers.Count()}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<IEnumerable<SalesInputDto>>(inputJson);

            InitializeMapper();

            var mappedSales = mapper.Map<IEnumerable<Sale>>(sales);

            context.Sales.AddRange(mappedSales);
            context.SaveChanges();

            return $"Successfully imported {mappedSales.Count()}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .ToList();

            InitializeMapper();

            
            var mappedCustomers = mapper.Map<List<OrderdCustomerDto>>(customers);

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                DateFormatString = "dd/MM/yyyy",
                Formatting = Formatting.Indented
            };

            var customersAsJson = JsonConvert.SerializeObject(mappedCustomers, settings);

            return customersAsJson;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var carsWithMake = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();

            InitializeMapper();

            var mappedCars = mapper.Map<List<CarsWithMakeDto>>(carsWithMake);

            var carsAsJson = JsonConvert.SerializeObject(mappedCars, Formatting.Indented);

            return carsAsJson;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new SuppliersDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            var suppliersAsJson = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return suppliersAsJson;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new CarWithPartsDto
                {
                    car = new CarDto
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    parts = c.PartCars.Select(pc => new PartDto
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price.ToString("F2"),
                    }).ToList()
                })
                .ToList();

            var allCarsJson = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return allCarsJson;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                   .Where(c => c.Sales.Any(s => s.Car != null))
                   .Select(c => new
                   {
                       fullName = c.Name,
                       boughtCars = c.Sales.Count,
                       spentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                   })
                   .ToList();

            var customersAsJson = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return customersAsJson;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = $"{s.Discount:F2}",
                    price = $"{s.Car.PartCars.Sum(pc => pc.Part.Price):F2}",
                    priceWithDiscount = $"{s.Car.PartCars.Sum(pc => pc.Part.Price) * (1 - (s.Discount / 100)):F2}",
                })
                .ToList();

            var salesAsJson = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return salesAsJson;
        }

        public static void InitializeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = new Mapper(config);
        }
    }
}