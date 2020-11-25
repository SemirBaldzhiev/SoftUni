using System;
using System.Text;
using System.Linq;

namespace _07._StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int strength = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    strength += int.Parse(input[i + 1].ToString());
                    continue;
                }

                if (strength > 0)
                {
                    input = input.Remove(i, 1);
                    strength--;
                    i--;
                }
            }

            Console.WriteLine(input);
        }
    }
}
