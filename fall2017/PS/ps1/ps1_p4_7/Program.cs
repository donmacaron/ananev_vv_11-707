using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number from 1 to 20:");
            int k = int.Parse(Console.ReadLine());
            int[] arr = new int[20];
            for (int i = 0; i < arr.Length; i++) { arr[i] = i + 1; }

            int lcm = 1;
            int gcd = 1;
            for (int i = 0; i < arr[k]-1; i++)
            {
                gcd = GetGCD(gcd, arr[i]);
                lcm = GetLCM(lcm, arr[i]);
            }
            Console.WriteLine($"The least common multiple for nums from 1 to {k} is {lcm} \nThe greatest common divider for nums from 1 to {k} is {gcd}");
            Console.ReadKey();
        }
        static int GetGCD(int a, int b)
        {
            int min = Math.Min(a, b);
            for (int i = min; i > 1; i--)
                if (((a % i) == 0) && ((b % i) == 0))
                {
                    return i;
                }
            return 1;
        }
        static int GetLCM(int a, int b)
        {
            int lcm = a * b / GetGCD(a, b);
            return lcm;
        }
    }
}
