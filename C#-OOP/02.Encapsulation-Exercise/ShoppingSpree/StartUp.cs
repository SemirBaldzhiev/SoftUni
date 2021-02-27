using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                string[] peopleInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string[] productsInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();

                foreach (var person in peopleInput)
                {
                    string[] personData = person.Split("=");

                    Person personToAdd = new Person(personData[0], decimal.Parse(personData[1]));


                    people.Add(personToAdd);
                }

                foreach (var product in productsInput)
                {
                    string[] productData = product.Split("=");

                    Product productToAdd = new Product(productData[0], decimal.Parse(productData[1]));

                    products.Add(productToAdd);
                }


                while (true)
                {
                    string line = Console.ReadLine();

                    if (line == "END")
                    {
                        break;
                    }

                    string[] commands = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string name = commands[0];
                    string productName = commands[1];

                    Person buyer = people.Find(x => x.Name == name);

                    Product productToBuy = products.Find(x => x.Name == productName);

                    if (buyer != null && productToBuy != null)
                    {
                        buyer.Bought(productToBuy);
                    }

                }

                people.ForEach(p => Console.WriteLine(p));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
