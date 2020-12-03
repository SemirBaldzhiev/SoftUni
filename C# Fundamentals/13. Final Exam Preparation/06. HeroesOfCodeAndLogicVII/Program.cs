using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06._HeroesOfCodeAndLogicVII
{
    public class Hero
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int Mana { get; set; }

        public Hero(string name, int hp, int mana)
        {
            Name = name;
            HitPoints = hp;
            Mana = mana;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name}");
            sb.AppendLine($"  HP: {HitPoints}");
            sb.AppendLine($"  MP: {Mana}");

            return sb.ToString().Trim();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Hero> heroes = new List<Hero>();

            for (int i = 0; i < n; i++)
            {
                string[] heroInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Hero hero = new Hero(heroInfo[0], int.Parse(heroInfo[1]), int.Parse(heroInfo[2]));
                heroes.Add(hero);
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] commands = line
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int amount = 0;
                string heroName = commands[1];

                Hero hero = heroes.Where(h => h.Name == heroName).FirstOrDefault();

                switch (commands[0])
                {
                    case "CastSpell":
                        int manaNeeded = int.Parse(commands[2]);
                        string spell = commands[3];

                        if (manaNeeded <= hero.Mana)
                        {
                            hero.Mana -= manaNeeded;
                            Console.WriteLine($"{hero.Name} has successfully cast {spell} and now has {hero.Mana} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{hero.Name} does not have enough MP to cast {spell}!");
                        }

                        break;
                    case "TakeDamage":
                        int damage = int.Parse(commands[2]);
                        string attacker = commands[3];

                        hero.HitPoints -= damage;

                        if (hero.HitPoints > 0)
                        {
                            Console.WriteLine($"{hero.Name} was hit for {damage} HP by {attacker} and now has {hero.HitPoints} HP left!");
                        }
                        else
                        {
                            heroes.Remove(hero);
                            Console.WriteLine($"{hero.Name} has been killed by {attacker}!");
                        }

                        break;
                    case "Recharge":
                        amount = int.Parse(commands[2]);

                        if (hero.Mana + amount > 200)
                        {
                            amount = 200 - hero.Mana;
                            hero.Mana = 200;
                            
                        }
                        else
                        {
                            hero.Mana += amount;
                        }

                        Console.WriteLine($"{hero.Name} recharged for {amount} MP!");

                        break;
                    case "Heal":
                        amount = int.Parse(commands[2]);

                        if (hero.HitPoints + amount > 100)
                        {
                            amount = 100 - hero.HitPoints;
                            hero.HitPoints = 100;
                        }
                        else
                        {
                            hero.HitPoints += amount;
                        }

                        Console.WriteLine($"{hero.Name} healed for {amount} HP!");
                        break;
                }
            }

            foreach (var hero in heroes.OrderByDescending(h => h.HitPoints).ThenBy(h => h.Name))
            {
                Console.WriteLine(hero.ToString());
            }
        }
    }
}
