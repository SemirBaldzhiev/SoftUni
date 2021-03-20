
using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<BaseHero> raidGroup = new List<BaseHero>();

            while(raidGroup.Count != n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                BaseHero hero = null;

                if (type == nameof(Druid))
                {
                    hero = new Druid(name);
                }
                else if (type == nameof(Paladin))
                {
                    hero = new Paladin(name);
                }
                else if (type == nameof(Rogue))
                {
                    hero = new Rogue(name);
                }
                else if (type == nameof(Warrior))
                {
                    hero = new Warrior(name);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }

                raidGroup.Add(hero);
            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach (var hero in raidGroup)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int allHeroesPower = raidGroup.Sum(h => h.Power);

            if (allHeroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
