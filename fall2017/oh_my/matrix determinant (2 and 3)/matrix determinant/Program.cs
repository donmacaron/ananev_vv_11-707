using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix_determinant
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Determinant of matrix\nEnter the rank of matrix (2 or 3)...");
            int rank = int.Parse(Console.ReadLine());
            int[,] m = new int[rank, rank];
            int det = 0;
            Console.WriteLine("Enter your matrix (line by line with spaces)");
            for (int i = 0; i < m.GetLength(0); i++)
            {
                string enterString = Console.ReadLine();
                string[] massiveString = enterString.Split(new Char[] { ' ' });
                for (int j = 0; j < massiveString.Length; j++)
                {
                    m[i, j] = int.Parse(massiveString[j]);
                }
            }

            switch (rank)
            {
                case 2:
                    det = ThirdOder(m);
                    Console.WriteLine("Determinant of 2x2 matrix is... {0}", (det));
                    break;
                case 3:
                    det = SecondOrder(m);
                    Console.WriteLine("Determinant of 3x3 matrix is... {0}",(det));
                    break;
                default:
                    Console.WriteLine("Maybe later.. see you space cowboy..");
                    break;
            }
            
            Console.ReadKey();
        }

        static int ThirdOder(int[,]m)
        {
            int det = 0;
            Console.WriteLine("");
            det = (m[0, 0] * m[1, 1] * m[2, 2] + m[0, 1] * m[1, 2] * m[2, 0] + m[0, 2] * m[1, 0] * m[2, 1]) - (m[0, 2] * m[1, 1] * m[2, 0] + m[0, 0] * m[1, 2] * m[2, 1] + m[0, 1] * m[1, 0] * m[2, 2]);
            return det;
        }
        static int SecondOrder(int[,]m)
        {
            int det = 0;
            Console.WriteLine("");
            det = m[0, 0] * m[1, 1] - m[0, 1] * m[1, 0];
            return det;
        }

        static void MassOut(int[,]m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    Console.Write("{0,3}", m[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
