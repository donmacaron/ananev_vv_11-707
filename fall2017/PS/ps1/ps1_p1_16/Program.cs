using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1_16
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input ticket number: six digits in a row without spaces");
            int ticket = int.Parse(Console.ReadLine());
            int half0, half1, sum0, sum1;
            half0 = half1 = sum0 = sum1 = 0;
            if (ticket < 999999)
            {
                half0 = ticket / 1000;
                half1 = ticket % 1000;
                while (half0 != 0 && half1 != 0)
                {
                    sum0 += half0 % 10;
                    half0 /= 10;
                    sum1 += half1 % 10;
                    half1 /= 10;
                }
                if ((sum0==sum1+1) || (sum0 == sum1 - 1)) { Console.WriteLine("Almost lucky. Task Complete"); }
                else if (sum0 == sum1) { Console.WriteLine("Lucky ticket here! We have no need in this"); }
                else { Console.WriteLine("Better luck next time, pal!"); }
            }
            else { Console.WriteLine("Incorrect data on input"); }
            Console.ReadKey();
        }
    }
}
