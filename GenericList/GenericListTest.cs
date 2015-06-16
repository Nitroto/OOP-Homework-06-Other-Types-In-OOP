using System;

namespace GenericList
{
    class GenericListTest
    {
        static void Main()
        {
            GenericList<int> list = new GenericList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Insert(1, 4);
            Console.WriteLine(list[1]);
            Console.WriteLine(list[2]);
            Console.WriteLine(list.Contain(2));
            list.Remove(2);
            Console.WriteLine(list.Contain(2));
            Console.WriteLine(list.IndexOf(4));
            Console.WriteLine(GenericList<IComparable>.Max(list));
            Console.WriteLine(GenericList<IComparable>.Min(list));
            Console.WriteLine(list.ToString());
            list.Clear();
            Console.WriteLine(list.ToString());
        }
    }
}
