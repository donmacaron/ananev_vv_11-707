using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ps2_p2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter approximation of calculations...");
            double e = double.Parse(Console.ReadLine());

            Console.WriteLine("Wallis product = {0}", Product(e));
            Console.ReadKey();
        }

        static double Product(double e)
        {
            double result = 1;
            double temp;
            int i = 1;
            do
            {
                temp = result;
                result *= (4*Pow(Convert.ToDouble(i), 2) / (4*Pow(Convert.ToDouble(i), 2)-1));
                i++;
            }
            while ((Abs(result, temp) > e));
            return result*2;
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
