using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO.Input;
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

            string suppliersJson = File.ReadAllText("../../../Datasets/suppliers.json");
            string partsJson = File.ReadAllText("../../../Datasets/parts.json");


            string suppliersResult = ImportSuppliers(context, suppliersJson);
            string partsResult = ImportParts(context, partsJson);


            Console.WriteLine(suppliersResult);
            Console.WriteLine(partsResult);

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