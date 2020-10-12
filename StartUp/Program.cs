using System;

namespace StartUp
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList myList = new CustomList();
            for (int i = 0; i < 4; i++)
            {
                myList.Add(i);
            }
            myList.Insert(1, 6);
            myList.RemoveAt(1);
        }
    }
}
