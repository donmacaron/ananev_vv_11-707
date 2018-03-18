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
            int k; // k element
            int n; //array size
            int j; // j for the last task
            int[] array;
            


            Console.WriteLine("Input size of array..");
            n = int.Parse(Console.ReadLine());
            array = new int[n];
            Console.WriteLine("Input array elements..");
            for(int i = 0; i<array.Length;i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            array = Merge_Sort(array);

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
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\n\nTask #7\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write($"Max same numbers in list is {linkedList.MaxNum()}");


            //#7 divide DLinkedList into 2: multiples of 3 and everyone else. return array of 2 links with begining of list
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\n\nTask #7\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            linkedList.Divide();



            //#8 orderd list with one rule: every element is j*(n-j)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\n\nTask #8\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write("Input 'j'...\n");
            j = int.Parse(Console.ReadLine());
            linkedList.NewList(j);
            linkedList.ShowList();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Every element is {j}*(n-{j})");
            Console.ForegroundColor = ConsoleColor.White;


            Console.ReadKey();
        }







        static int[] Merge_Sort(int[] arr)
        {
            if (arr.Length == 1)
                return arr;
            int mid_point = arr.Length / 2;
            return Merge(Merge_Sort(arr.Take(mid_point).ToArray()),
                Merge_Sort(arr.Skip(mid_point).ToArray()));
        }

        static int[] Merge(int[] arr1, int[] arr2)
        {
            int a = 0, b = 0;
            int[] merged = new int[arr1.Length + arr2.Length];
            for (int i = 0; i < arr1.Length + arr2.Length; i++)
            {
                if (b < arr2.Length && a < arr1.Length)
                    if (arr1[a] > arr2[b])
                        merged[i] = arr2[b++];
                    else //if int go for
                        merged[i] = arr1[a++];
                else
                  if (b < arr2.Length)
                    merged[i] = arr2[b++];
                else
                    merged[i] = arr1[a++];
            }
            return merged;
        }
    }
}
