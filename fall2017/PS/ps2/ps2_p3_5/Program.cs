using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ps2_p3_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter x for k... ちょっと");
            double k = double.Parse(Console.ReadLine());
            double temp = 1;
            Console.WriteLine("Enter approximation of calculations (e)...");
            double e = double.Parse(Console.ReadLine());

            for(int i=1; i<=k; i++)
            {
                Console.WriteLine("(Handmade Cosine) X{0} = {1}", i, Cosine(temp - 1, e));
                Console.WriteLine("(Math.Cos) X{0} = {1}/n/n", i, Math.Cos(temp - 1));
                temp = i;
            }
            Console.ReadKey();
        }


        static string StepsCount(int steps)
        {
            var result = $"Number of steps: {steps}";
            return result;
        }

        static double Abs(double x, double y)
        {
            if ((x - y) > 0) { return x - y; }
            else return (x - y) * (-1);
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
            double result = n;
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

        static double Cosine(double x, double e)
        {
            double result = 0;
            double temp;
            int i = 0;
            do
            {
                temp = result;
                result += Pow(-1, i) * ((Pow(x, 2 * i)) / (Factorial(2 * i)));
                i++;
            }
            while ((Abs(result, temp) > e));
            //Console.WriteLine(StepsCount(i));
            return result;
        }
    }
}
