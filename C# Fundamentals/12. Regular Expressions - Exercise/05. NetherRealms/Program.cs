using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05._NetherRealms
{
    public class Demon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }

        public Demon(string name, int health, double damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public override string ToString()
        {
            return $"{Name} - {Health} health, {Damage:f2} damage";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[+-]?[0-9]+\.?[0-9]*";

            string[] demons = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            
            Regex regex = new Regex(pattern);

            List<Demon> demonsList = new List<Demon>();

            foreach (var demon in demons)
            {
                string filter = "0123456789+-*/.";

                int health = demon.Where(x => !filter.Contains(x)).Sum(x => x);

                double damage = CalculateDamage(regex, demon);

                Demon demonToAdd = new Demon(demon, health, damage);

                demonsList.Add(demonToAdd);
            }

            foreach (var demon in demonsList.OrderBy(x => x.Name))
            {
                Console.WriteLine(demon.ToString());
            }

        }

        private static double CalculateDamage(Regex regex, string demon)
        {
            var matches = regex.Matches(demon);

            double damage = 0.0;

            foreach (Match match in matches)
            {
                damage += double.Parse(match.Value);
            }

            foreach (var ch in demon)
            {
                if (ch == '*')
                {
                    damage *= 2;
                }
                else if (ch == '/')
                {
                    damage /= 2;
                }
            }

            return damage;
        }
    }
}
