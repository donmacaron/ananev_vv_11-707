using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ps4_p4_3_5
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, a1, b1,step;
            int n;
            Console.WriteLine("Enter amount of steps...");
            step = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter N for Monte Carlo Method...");
            n = int.Parse(Console.ReadLine());
            b = 2.5;
            a = 0.5;
            b1 = 3;
            a1 = 1;

            Console.WriteLine("Task 3: -tan(1/x+x)\nLeft Riemann rule: {0}\nRight Riemann rule: {1}\nTrapeziodal: {2}\nSimpson's rule: {3}\nMonte Carlo Method: {4}\n\n", LeftRiemann(1, a, b, step),RightRiemann(1, a, b, step),Trapezoidal(1, a, b, step),SimpsonRule(1, a, b, step), MonteCarlo(1, a, b, n));
            Console.WriteLine("Task 5: cos(sin(x))\nLeft Riemann rule: {0}\nRight Riemann rule: {1}\nTrapeziodal: {2}\nSimpson's rule: {3}\nMonte Carlo Method: {4}", LeftRiemann(2, a1, b1, step), RightRiemann(2, a1, b1, step), Trapezoidal(2, a1, b1, step), SimpsonRule(2, a1, b1, step), MonteCarlo(2, a1, b1, n));

            Console.ReadKey();

        }
        static double IntegCalc(double x, int t)
        {
            switch(t)
            {
                case 1:
                    return (-1) * (Math.Tan(1.0 / x + x));
                case 2:
                    return Math.Cos(Math.Sin(x));
            }
            return -1;
        }
        static double LeftRiemann(int t, double a, double b, double step)
        {
            double res = 0;
            for (double x = a; x < b; x += step)
            {
                res += IntegCalc(x, t) * step;

            }
            return res;
        }
        static double RightRiemann(int t, double a, double b, double step)
        {
            double res = 0;
            for (double x = a; x < b; x += step)
            {
                res += IntegCalc(x+step, t) * step;
            }
            return res;
        }
        static double Trapezoidal(int t, double a, double b, double step)
        {
            double res = 0;
            for (double x = a; x < b; x += step)
            {
                res += step * (IntegCalc(x, t) + IntegCalc(x + step, t)) / 2;
            }
            return res;
        }
        static double SimpsonRule(int t, double a, double b, double step)
        {
            double h = 0;
            double x = a + step;
            while (x < b)
            {
                h = h + 4 * IntegCalc(x, t);
                x = x + step;
                h = h + 2 * IntegCalc(x, t);
                x = x + step;
            }
            return step / 3 * (h + IntegCalc(a, t) - IntegCalc(b, t));
        }
        static double MonteCarlo(int t, double a, double b, int n)
        {
            double res = 0;
            var random = new Random(0);
            for (int i = 0; i < n; i++)
            {
                double number = random.Next(Convert.ToInt32(b));
                res += IntegCalc(number, t);
            }
            return res * (b - a) / n;
        }
        /*
         * там внизу куча математических бесполезных методовб
         * котрые никому не нужны.

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
                result += Pow(-1, i) * ((Pow(x, 2 * i)) / (Factorial(2*i)));
                i++;
            }
            while ((Abs(result, temp) > e));
            return result;
        }
        static double Sine(double x, double e)
        {
            double result = 0;
            double temp;
            int i = 0;
            do
            {
                temp = result;
                result += Pow(-1, i) * ((Pow(x, 2 * i+1)) / (Factorial(2 * i+1)));
                i++;
            }
            while ((Abs(result, temp) > e));
            return result;

        }
        */
    }
}
