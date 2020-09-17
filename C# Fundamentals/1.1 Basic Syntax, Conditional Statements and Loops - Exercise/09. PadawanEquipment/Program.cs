using System;

namespace _09._PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double sabersPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());

            int freeBelts = (int)(studentsCount / 6);
            double sabers = sabersPrice * (studentsCount + Math.Ceiling(studentsCount * 0.1));
            double robes = robesPrice * studentsCount;
            double belts = beltsPrice * (studentsCount - freeBelts);
            double equipmentPrice = sabers + robes + belts;


            if (money >= equipmentPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {equipmentPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {(equipmentPrice - money):f2}lv more.");
            }
        }
    }
}
