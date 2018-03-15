using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix_determinant_n
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter order of your matrix...");
            int rank = int.Parse(Console.ReadLine());
            double[,] m = new double[rank, rank];
            Console.WriteLine("Enter your matrix (line by line with spaces between elements)");
            for (int i = 0; i < m.GetLength(0); i++)
            {
                string stringInput = Console.ReadLine();
                string[] massiveString = stringInput.Split(new Char[] {' '});
                for (int j = 0; j < massiveString.Length; j++)
                {
                    m[i, j] = double.Parse(massiveString[j]);
                }
            }
            double det = DetCalc(m);
            Console.WriteLine("Determinant of your matrix is... {0}",(det));
            Console.ReadKey();
        }

        static int Sign(int i, int j)
        {
            if ((i + j) % 2 == 0) { return 1; }
            else { return -1; }
        }
        static double[,] CreateSubMat(double[,] m, int i, int j)
        {
            int order = int.Parse(System.Math.Sqrt(m.Length).ToString());
            double[,] result = new double[order - 1, order - 1];
            int x = 0, y = 0;
            for (int l = 0; l < order; l++, x++)
            {
                if (l != i)
                {
                    y = 0;
                    for (int n = 0; n < order; n++)
                    {
                        if (n != j)
                        {
                            result[x, y] = m[l, n];
                            y++;
                        }
                    }
                }
                else { x--; }
            }
            return result;
        }
        
        static double DetCalc(double[,] m)
        {
            int order = int.Parse(System.Math.Sqrt(m.Length).ToString());

            if (order > 2)
            {
                double value = 0;
                for (int j = 0; j < order; j++)
                {
                    double[,] temp = CreateSubMat(m, 0, j);
                    value = value + m[0, j] * (Sign(0, j) * DetCalc(temp));
                }
                return value;
            }
            else if (order == 2)
            {
                return ((m[0, 0] * m[1, 1]) - (m[1, 0] * m[0, 1]));
            }
            else
            {
                return (m[0, 0]);
            }
        }












    }
}
