using System;
using System.Linq;

namespace _02._MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dungeonRooms = Console.ReadLine().Split('|').ToArray();
            int health = 100;
            int bitcoins = 0;

            bool isDead = false;

            int length = dungeonRooms.Length;

            for (int i = 0; i < length; i++)
            {
                string[] room = dungeonRooms[i].Split().ToArray();

                switch (room[0])
                {
                    case "potion":
                        int potionAmount = int.Parse(room[1]);
                        
                        if (health + potionAmount <= 100)
                        {
                            health += potionAmount;
                        }
                        else
                        {
                            potionAmount = 100 - health;
                            health += potionAmount;
                        }

                        Console.WriteLine($"You healed for {potionAmount} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                        break;
                    case "chest":
                        int amount = int.Parse(room[1]);
                        bitcoins += amount;
                        Console.WriteLine($"You found {amount} bitcoins.");
                        break;
                    default:
                        string monster = room[0];
                        int attack = int.Parse(room[1]);
                        health -= attack;

                        if (health > 0)
                        {
                            Console.WriteLine($"You slayed {monster}.");
                        }
                        else
                        {
                            Console.WriteLine($"You died! Killed by {monster}.");
                            Console.WriteLine($"Best room: {i + 1}");
                            isDead = true;
                            
                        }
                        break;
                }

                if (isDead)
                {
                    break;
                }

            }

            if (isDead == false)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}
