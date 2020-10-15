using System;

namespace _12._DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();

            if (dataType == "int")
            {
                int num = int.Parse(Console.ReadLine());
                Multiply(num);
            }
            else if (dataType == "double")
            {
                double num = double.Parse(Console.ReadLine());
                Multiply(num);
            }
            else if (dataType == "string")
            {
                string text = Console.ReadLine();
                Surround(text);
            }
        }

        private static void Surround(string text)
        {
            Console.WriteLine($"${text}$");
        }

        private static void Multiply(int num)
        {
            Console.WriteLine(num * 2);
        }
        private static void Multiply(double num)
        {
            Console.WriteLine($"{(num * 1.5):f2}");
        }
    }
}
