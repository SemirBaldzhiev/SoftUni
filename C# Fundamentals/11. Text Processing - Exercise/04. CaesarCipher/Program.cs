using System;
using System.Text;

namespace _04._CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            foreach (var ch in text)
            {
                sb.Append((char)(ch + 3));
            }

            Console.WriteLine(sb);
        }
    }
}
