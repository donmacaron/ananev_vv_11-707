using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ps2_p1_16
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter approximation of calculations...");
            double e = double.Parse(Console.ReadLine());

            Console.WriteLine("Catalan Constant = {0}", Sum(e));
            Console.ReadKey();
        }

        static double Sum(double e)
        {
            double result = 0;
            double temp;
            int i = 0;
            do
            {
                temp = result;
                result += (Pow(-1, i) / (Pow((2*Convert.ToDouble(i)+1),2)));
                i++;
            }
            while ((Abs(result, temp) > e));
            Console.WriteLine(StepsCount(i));
            return result;
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
    }
}

