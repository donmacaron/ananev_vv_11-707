using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2_14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input decimal number (<= 10^7 and notation (from 2 to 10)");
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Decimal number is " + n);
            int res = DecTrans(n, k);
            if ((n > 0)&&(k>=2)&&(k<=10))
            {
                Console.WriteLine($"The product of all digits is {res}");
            }
            Console.ReadKey(); // задержка экрана
            
        }

        static int DecTrans(int num, int not)
        {
            string result = "";
            int temp = 0;
            int prod = 1;
            int oNum = num;
            while (num >= (not - 1))
            {
                temp = num % not;
                num = (num - temp) / not;
                prod *= temp;
                result = Convert.ToString(temp) + result;
            }
            result = Convert.ToString(num) + result;
            Console.WriteLine($"{oNum} in {not} notation is {result} ");
            return prod;
        }
    }
}
