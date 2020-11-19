using System;

namespace _03._ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Console.ReadLine();

            int index = filePath.LastIndexOf("\\");

            string[] file = filePath.Substring(index + 1).Split('.');

            string fileName = file[0];
            string extension = file[1];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
