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
    }
}