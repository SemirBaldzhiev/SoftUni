using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] websites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var number in phoneNumbers)
            {
                if (number.Length == 7)
                {
                    StationaryPhone sp = new StationaryPhone();

                    Console.WriteLine(sp.Call(number));
                }
                else if (number.Length == 10)
                {
                    Smartphone smartPhone = new Smartphone();

                    Console.WriteLine(smartPhone.Call(number));
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (var site in websites)
            {
                Smartphone smartPhone = new Smartphone();

                Console.WriteLine(smartPhone.Browse(site));
            }


        }
    }
}
