using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Dtos;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //string usersJsonString = File.ReadAllText("../../../Datasets/users.json");
            //string productsJsonString = File.ReadAllText("../../../Datasets/products.json");
            //string categoriesJsonString = File.ReadAllText("../../../Datasets/categories.json");
            //string categorProductJsonString = File.ReadAllText("../../../Datasets/categories-products.json");

            //Console.WriteLine(ImportUsers(context, usersJsonString));
            //Console.WriteLine(ImportProducts(context, productsJsonString));
            //Console.WriteLine(ImportCategories(context, categoriesJsonString));
            //Console.WriteLine(ImportCategoryProducts(context, categorProductJsonString));

            //Console.WriteLine(GetProductsInRange(context));
            //Console.WriteLine(GetSoldProducts(context));
            Console.WriteLine(GetCategoriesByProductsCount(context));

        }

        // Import Problems
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IEnumerable<InputUserDto> users = JsonConvert.DeserializeObject<IEnumerable<InputUserDto>>(inputJson);
            InitializeMapper();

            IEnumerable<User> mappedUsers = mapper.Map<IEnumerable<User>>(users);

            context.Users.AddRange(mappedUsers);
            context.SaveChanges();

            return $"Successfully imported {mappedUsers.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<InputProductDto> products = JsonConvert.DeserializeObject<IEnumerable<InputProductDto>>(inputJson);

            InitializeMapper();

            IEnumerable<Product> mappedProducts = mapper.Map<IEnumerable<Product>>(products);

            context.Products.AddRange(mappedProducts);
            context.SaveChanges();

            return $"Successfully imported {mappedProducts.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IEnumerable<InputCategoryDto> categories  = JsonConvert.DeserializeObject<IEnumerable<InputCategoryDto>>(inputJson)
                .Where(x => !string.IsNullOrEmpty(x.Name));

            InitializeMapper();

            var mappedCategories = mapper.Map<IEnumerable<Category>>(categories);

            context.Categories.AddRange(mappedCategories);
            context.SaveChanges();

            return $"Successfully imported {mappedCategories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<InputCategoryProductDto> categoryProducts = 
                JsonConvert.DeserializeObject<IEnumerable<InputCategoryProductDto>>(inputJson);

            InitializeMapper();

            var mappedCategoryProducts = mapper.Map<IEnumerable<CategoryProduct>>(categoryProducts);

            context.CategoryProducts.AddRange(mappedCategoryProducts);
            context.SaveChanges();

            return $"Successfully imported {mappedCategoryProducts.Count()}";
        }

        public static void InitializeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = new Mapper(config);
        }

        // Export Problems
        public static string GetProductsInRange(ProductShopContext context)
        {

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };


            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price,
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .OrderBy(p => p.Price)
                .ToList();

            var productAsJson = JsonConvert.SerializeObject(products, settings);

            return productAsJson;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var users = context
                .Users
                .Include(u => u.ProductsSold)
                .Where(u => u.ProductsSold.Count >= 1 && u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                    .Select(p => new
                    {
                        Name = p.Name,
                        Price = p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName
                    })
                    .ToList()
                })
                .ToList();

            var usersAsJson = JsonConvert.SerializeObject(users, settings);

            return usersAsJson;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoryProducts.Count(),
                    AveragePrice = $"{c.CategoryProducts.Sum(x => x.Product.Price) / c.CategoryProducts.Count:f2}",
                    TotalRevenue = $"{c.CategoryProducts.Sum(x => x.Product.Price):f2}"
                })
                .OrderByDescending(x => x.ProductsCount)
                .ToList();

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var categoriesAsJson = JsonConvert.SerializeObject(categories, settings);

            return categoriesAsJson;
        }

    }
}