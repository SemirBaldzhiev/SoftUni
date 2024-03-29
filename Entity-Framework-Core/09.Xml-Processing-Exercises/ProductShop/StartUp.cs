﻿using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string usersXml = File.ReadAllText("../../../Datasets/users.xml");
            string productsXml = File.ReadAllText("../../../Datasets/products.xml");
            string categoryProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            string categoryXml = File.ReadAllText("../../../Datasets/categories.xml");

            //Console.WriteLine(ImportUsers(context, usersXml));
            //Console.WriteLine(ImportProducts(context, productsXml));
            //Console.WriteLine(ImportCategories(context, categoryXml));
            Console.WriteLine(ImportCategoryProducts(context, categoryProductsXml));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            int count = 0;
            using (var reader = new StringReader(inputXml))
            {
                var serializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));

                var users = (ImportUserDto[])serializer.Deserialize(reader);

                var mappedUsers = users
                    .Select(u => new User
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Age = u.Age
                    })
                    .ToList();

                context.Users.AddRange(mappedUsers);
                context.SaveChanges();

                count = mappedUsers.Count();
            }

            return $"Successfully imported {count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            int count = 0;
            using (var reader = new StringReader(inputXml))
            {
                var serializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));

                var products = (ImportProductDto[])serializer.Deserialize(reader);

                var mappedProducts = products
                    .Select(u => new Product
                    {
                        Name = u.Name, 
                        Price = u.Price,
                        SellerId = u.SellerId,
                        BuyerId = u.BuyerId
                    })
                    .ToList();

                context.Products.AddRange(mappedProducts);
                context.SaveChanges();

                count = mappedProducts.Count();
            }


            return $"Successfully imported {count}";
        }
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {

            int count = 0;
            using (var reader = new StringReader(inputXml))
            {
                var serializer = new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));

                var categories = (ImportCategoryDto[])serializer.Deserialize(reader);

                var mappedCategories = categories
                    .Select(u => new Category
                    {
                        Name = u.Name
                    })
                    .ToList();

                context.Categories.AddRange(mappedCategories);
                context.SaveChanges();

                count = mappedCategories.Count();
            }
            return $"Successfully imported {count}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            int count = 0;
            using (var reader = new StringReader(inputXml))
            {
                var serializer = new XmlSerializer(
                typeof(ImportCategoryProductDto[]),
                new XmlRootAttribute("CategoryProducts"));
                var categoryProductDtos = (ImportCategoryProductDto[])serializer.Deserialize(reader);

                var cateogryProducts = categoryProductDtos
                    .Select(d => new CategoryProduct
                    {
                        CategoryId = d.CategoryId,
                        ProductId = d.ProductId
                    })
                    .ToList();


                context.CategoryProducts.AddRange(cateogryProducts);
                context.SaveChanges();

                count = cateogryProducts.Count();
            }

            return $"Successfully imported {count}";
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ExportProductsInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .Take(10)
                .ToArray();

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add(string.Empty, string.Empty);

                var serializer = new XmlSerializer(
                    typeof(ExportProductsInRangeDto[]),
                    new XmlRootAttribute("Products"));
                serializer.Serialize(writer, products, ns);
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new ExportUserDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Where(ps => ps.Buyer != null)
                        .Select(ps => new ExportUserProductDto
                        {
                            Name = ps.Name,
                            Price = ps.Price
                        })
                        .ToArray()
                })
                .Take(5)
                .ToArray();

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add(string.Empty, string.Empty);

                var serializer = new XmlSerializer(typeof(ExportUserDto[]), new XmlRootAttribute("Users"));
                serializer.Serialize(writer, users, ns);
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoryDtos = context.Categories
                .Select(c => new ExportCategoryByProductDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts
                        .Average(p => p.Product.Price),
                    TotalRevenue = c.CategoryProducts
                        .Sum(p => p.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add(string.Empty, string.Empty);

                var serializer = new XmlSerializer(
                    typeof(ExportCategoryByProductDto[]),
                    new XmlRootAttribute("Categories"));
                serializer.Serialize(writer, categoryDtos, ns);
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(p => p.ProductsSold.Count())
                .Select(u => new UserWithProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductDto
                    {
                        Count = u.ProductsSold.Count(),
                        Products = u.ProductsSold
                            .Select(p => new ProductDto
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .OrderByDescending(p => p.Price)
                            .ToArray()
                    }
                })
                .Take(10)
                .ToArray();

            var userAndProducts = new UserAndProductsDto
            {
                Count = context.Users.Count(u => u.ProductsSold.Any()),
                Users = users
            };

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add(string.Empty, string.Empty);

                var serializer = new XmlSerializer(typeof(UserAndProductsDto), new XmlRootAttribute("Users"));
                serializer.Serialize(writer, userAndProducts, ns);
            }

            return sb.ToString().TrimEnd();
        }

    }
}