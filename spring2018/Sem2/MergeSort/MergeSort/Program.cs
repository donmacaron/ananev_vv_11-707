using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            


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
