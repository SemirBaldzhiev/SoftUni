using System;

namespace _06._ForeignLanguages
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();

            string language = string.Empty;

            switch (country)
            {
                case "USA":
                case "England":
                    language = "English";
                    break;
                case "Spain":
                case "Mexico":
                case "Argentina":
                    language = "Spamish";
                    break;

                default:
                    language = "unknown";
                    break;
            }

            Console.WriteLine(language);
        }
    }
}
