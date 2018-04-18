using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;


namespace MergeSort
{
    class Program
    { 
        public static int iterations = 0;
        static void Main(string[] args)
        {
            int size = 1000;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Magenta;
            //BunchOfArrays(size);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Arrays are generated!\n" +
                "              Moving to the sorting...");
            long t = 0;

            Stopwatch watch = new Stopwatch();

            for (int i = 1; i < size; i++)
            {
                var array = (File.ReadAllLines($@"arrays\{i}.txt", Encoding.Default)
                    .Select(x => Convert.ToInt32(x))
                    .ToArray());
                watch.Start();
                var res = MergeSort(array);
                watch.Stop();
                t = watch.ElapsedMilliseconds;

                StreamWriter writer = new StreamWriter("Totals.txt", true, Encoding.Default);
                StreamWriter writer2 = new StreamWriter("Time.txt", true, Encoding.Default);
                StreamWriter writer3 = new StreamWriter("Iterations.txt", true, Encoding.Default);
                StreamWriter writer4 = new StreamWriter("Array size.txt", true, Encoding.Default);
                writer.WriteLine($"{t} - Time (milliseconds\n" +
                    $"             {t / 1000} - Time (seconds)" +
                    $"             {iterations} - Iterations\n" +
                    $"             {i} - Number of array\n" +
                    $"             {array.Length} - Length of array\n\n");
                writer.Flush();
                writer.Close();

               
                writer2.WriteLine($"{t}");
                writer2.Flush();
                writer2.Close();

                writer3.WriteLine($"{iterations}");
                writer3.Flush();
                writer3.Close();

                writer4.WriteLine($"{array.Length}");
                writer4.Flush();
                writer4.Close();

                File.WriteAllLines($@"arrays_sorted\{i}Sorted.txt", res
                    .Select(x => x
                    .ToString())
                    .ToArray(),
                    Encoding.Default);

                iterations = 0;
                watch.Reset();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Done!\n" +
                "Press any key to close this window");

            Console.ReadKey();


        }

        static void BunchOfArrays(int length)//creating A LOT of arrays
        {
            Console.WriteLine("Creating..");
            int names = 1;
            int size = 10000;
            for(int i = 1; i<length; i+=1)
            {

                ArrCreate(size, names);
                names++;
                Console.Write($"{names} ");
                size += 1000;
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("MASSIVE NUMBER OF ARRAYS IS CREATED! THEY ALL WANNA BE SORTED!  ( ͡° ͜ʖ ͡°)");
        }


        static void ArrCreate (int s, int name)
        {
            int[] array = new int[s];
            Random randNum = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = randNum.Next(1, 10000);
            }
            File.WriteAllLines($@"arrays\{name.ToString()}.txt",
                array.Select(x => x
                .ToString())
                .ToArray(),
                Encoding.Default);
            //Console.WriteLine("\nDONE!");
        }




        static int[] MergeSort(int[] arr)
        {
            if (arr.Length == 1)
                return arr;
            int mid_point = arr.Length / 2;
            return Merge(MergeSort(arr.Take(mid_point).ToArray()),
                MergeSort(arr.Skip(mid_point).ToArray()));
        }

        static int[] Merge(int[] arr1, int[] arr2)
        {
            int a = 0, b = 0;
            int[] merged = new int[arr1.Length + arr2.Length];
            for (int i = 0; i < arr1.Length + arr2.Length; i++)
            {
                if (b < arr2.Length && a < arr1.Length)
                    if (arr1[a] > arr2[b])
                    {
                        merged[i] = arr2[b++];
                        iterations++;
                    }
                    else //if int go for
                    {
                        merged[i] = arr1[a++];
                        iterations++;
                    }
                       
                else
                  if (b < arr2.Length)
                {
                    merged[i] = arr2[b++];
                    iterations++;
                }
                    
                else
                {
                    merged[i] = arr1[a++];
                    iterations++;
                } 
            }
            return merged;
        }
    }
}
