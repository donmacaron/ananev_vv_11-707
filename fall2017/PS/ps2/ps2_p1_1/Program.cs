using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ps2_p1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter power of  e...");
            double x = double.Parse(Console.ReadLine());
   
            Console.WriteLine("Enter approximation of calculations...");
            double e = double.Parse(Console.ReadLine());

            Console.WriteLine("e^x = {0}", Sum(x,e));
            Console.ReadKey();
        }
        
        static double Sum(double x, double e)
        {
            double result = 0;
            double temp = result;
            int i = 0;
            do
            {
                temp = result;
                result += (Pow(x, i) / (Factorial(i)));
                i++;
            }
            while ((result - temp) > e);
            Console.WriteLine(StepsCount(i));
            return result;
        }

        static string StepsCount(int steps)
        {
            var result = $"Number of steps: {steps}";
            return result; 
        }

        static double Factorial(double n)
        {
            double result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        static double Pow(double n, int j)
        {
            double result=n;
            if (j > 0)
            {
                for (int i = 1; i < j; i++)
                {
                    result *= n;
                }
                return result;
            }
            else if (j == 0) { return 1; }

            return -1;
        }
    }
}
