using System;

namespace CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();

            for (int i = 1; i <= 10; i++)
            {
                list.Add(i);
            }

            Console.WriteLine(list.Count);

            list.Insert(12, 3);

            Console.WriteLine(list.Count);

            list.RemoveAt(3);

            Console.WriteLine(list.Count);


            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
