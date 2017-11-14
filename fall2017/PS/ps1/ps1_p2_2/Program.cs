using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input first two elements of sequence and number K");
            int a0 = int.Parse(Console.ReadLine());
            int a1 = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int ak = 0;
            int d = 0;
            d = (a1 - a0);
            ak = a0 + d * (k - 1);
            Console.WriteLine("The K element is "+ak);
            Console.ReadKey();

        }
    }
}
