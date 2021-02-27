using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "Beast!")
            {
                string animal = input;
                string[] animalData = Console.ReadLine().Split();

                if (string.IsNullOrEmpty(animalData[0]) || string.IsNullOrEmpty(animalData[2]) || int.Parse(animalData[1]) < 0)
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }

                switch (animal)
                {
                    case "Dog":
                        Dog dog = new Dog(animalData[0], int.Parse(animalData[1]), animalData[2]);
                        Console.WriteLine(dog);
                        break;
                    case "Cat":
                        Cat cat = new Cat(animalData[0], int.Parse(animalData[1]), animalData[2]);
                        Console.WriteLine(cat);
                        break;
                    case "Frog":
                        Frog frog = new Frog(animalData[0], int.Parse(animalData[1]), animalData[2]);
                        Console.WriteLine(frog);
                        break;
                    case "Kitten":
                        Kitten kitten = new Kitten(animalData[0], int.Parse(animalData[1]));
                        Console.WriteLine(kitten);
                        break;
                    case "Tomcat":
                        Tomcat tomcat = new Tomcat(animalData[0], int.Parse(animalData[1]));
                        Console.WriteLine(tomcat);
                        break;
                    
                }

                input = Console.ReadLine();
            }
        }
    }
}
