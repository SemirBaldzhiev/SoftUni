using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            string usersXml = File.ReadAllText("../../../Datasets/users.xml");

            Console.WriteLine(ImportUsers(context, usersXml));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            int count = 0;
            using (var reder = new StringReader(inputXml))
            {
                var serializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));

                var users = (ImportUserDto[])serializer.Deserialize(reder);

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

            return $"Successfully imported {count}";
        }
    }
}