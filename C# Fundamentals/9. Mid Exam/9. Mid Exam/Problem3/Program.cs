using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = Console.ReadLine().Split(", ").ToList();
            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] commands = Console.ReadLine().Split(", ").ToArray();

                string value = commands[1];

                switch (commands[0])
                {
                    case "Add":

                        if (!ChekHeOwnsCard(value, cards))
                        {
                            cards.Add(value);
                            Console.WriteLine("Card successfully bought");
                        }
                        else
                        {
                            Console.WriteLine("Card is already bought");
                        }
                        break;
                    case "Remove":
                        if (ChekHeOwnsCard(value, cards))
                        {
                            cards.Remove(value);
                            Console.WriteLine("Card successfully sold");
                        }
                        else
                        {
                            Console.WriteLine("Card not found");
                        }
                        break;
                    case "Remove At":
                        int index = int.Parse(value);
                        
                        if (ChekIndexInRange(index, cards))
                        {
                            cards.RemoveAt(index);
                            Console.WriteLine("Card successfully sold");
                        }
                        else
                        {
                            Console.WriteLine("Index out of range");
                        }
                        break;
                    case "Insert":
                        int newIndex = int.Parse(value);
                        string card = commands[2];

                        if (!ChekIndexInRange(newIndex, cards))
                        {
                            Console.WriteLine("Index out of range");
                            continue;
                        }

                        if (ChekIndexInRange(newIndex, cards) && !ChekHeOwnsCard(card, cards))
                        {
                            cards.Insert(newIndex, card);
                            Console.WriteLine("Card successfully bought");
                        }
                        else if (ChekIndexInRange(newIndex, cards)  && ChekHeOwnsCard(card, cards))
                        {
                            Console.WriteLine("Card is already bought");
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", cards));
        }

        public static bool ChekIndexInRange(int index, List<string> list)
        {
            if (index >= 0 && index < list.Count())
            {
                return true;
            }

            return false;
        } 

        public static bool ChekHeOwnsCard(string card, List<string> cards)
        {
            if (cards.Contains(card))
            {
                return true;
            }

            return false;
        }
    }
}
