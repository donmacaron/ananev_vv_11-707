using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ps1_p4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            a = 0;
            b = 0;
            bool check = false;
            Console.WriteLine("Enter an even integer...");
            int n = int.Parse(Console.ReadLine());
            if (n % 2 != 0)
            {
                Console.WriteLine("Number you have entered is not even or integer...");
                n = int.Parse(Console.ReadLine());
            }

            for(int i = 0; i < n; ++i)
            {
                if (!check)
                {
                    if (PrimeDetector(i))
                    { a = i; }
                    for (int j = 0; j < n; j++)
                    {
                        if (PrimeDetector(j)) { b = j; }
                        if (a + b == n)
                        {
                            if (!check)
                            {
                                Console.WriteLine("The lowest prime is.. " + Math.Min(a, b));
                                check = true;
                            }

                        }
                    }
                }
            }
            Console.ReadKey();
        }

        private static bool PrimeDetector(int N)
        {
            for (int i = 2; i < (int)(N / 2); i++)
            {
                if (N % i == 0)
                    return false;
            }
            return true;
        }
    }
}
