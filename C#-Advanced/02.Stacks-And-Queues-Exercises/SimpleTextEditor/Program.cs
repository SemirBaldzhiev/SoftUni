using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string text = string.Empty;

            Stack<string> textStates = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split().ToArray();

                switch (commands[0])
                {
                    case "1":
                        textStates.Push(text);
                        text += commands[1];
                        break;
                    case "2":
                        textStates.Push(text);
                        int count = int.Parse(commands[1]);
                        text = text.Remove(text.Length - count, count);
                        
                        break;
                    case "3":
                        int index = int.Parse(commands[1]);
                        Console.WriteLine(text[index-1]);
                        break;
                    case "4":
                        text = textStates.Pop();
                        break;
                }
            }
        }
    }
}
