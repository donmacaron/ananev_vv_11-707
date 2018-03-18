using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sem1
{ 
    class Program
    {
        static void Main(string[] args)
        {
            DLinkedList<int> linkedList = new DLinkedList<int>();
            DLinkedList<int> likedList2 = new DLinkedList<int>();
            int k;
            int n;

            Console.WriteLine("Input size of array..");
            n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            Console.WriteLine("Input array elements..");
            for(int i = 0; i<array.Length;i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            //#1
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("sTask #1\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            linkedList.CreateFromIntArr(array);

            //#2
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\n\nTask #2\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            linkedList.Decode(array);

            //#3
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\n\nTask #3\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write("Input 'k'...");
            k = int.Parse(Console.ReadLine());
            linkedList.Add(k);
            linkedList.ShowList();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Added {k}");
            Console.ForegroundColor = ConsoleColor.White;

            //#4
            { 
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\n\nTask #4\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            linkedList.Delete(k);
            linkedList.ShowList();

            //#5 Merge



            //#6 Max n. of same elements in DLinkedList



            //#7 divide DLinkedList into 2: multiples of 3 and everyone else. return array of 2 links with begining of list



            //#8 orderd list with one rule: every element is j*(n-j)



            Console.ReadKey();
        }
    }
}
