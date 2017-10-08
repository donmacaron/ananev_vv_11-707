using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] pol = new int[8, 8];
            //положение ферзя вводится парой координат от 1 до 8
            Console.WriteLine("Введите положение ферзя (через Enter):");
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            //приводи координаты к виду от 0 до 7
            x--;
            y--;
            //забиваем массив 0
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    pol[i, j] = 0;
                }
            //обозначаем положение ферзя и затем заполняем диогонали 1 в матрице
            if (Convert.ToBoolean(pol[x, y] = 2))
            {
                for (int q = x - 1, w = y - 1; (q >= 0) && (w >= 0); q--, w--)
                    pol[q, w] = 1;
                for (int q = x - 1, w = y + 1; (q >= 0) && (w < 8); q--, w++)
                    pol[q, w] = 1;
                for (int q = x + 1, w = y - 1; (q < 8) && (w >= 0); q++, w--)
                    pol[q, w] = 1;
                for (int q = x + 1, w = y + 1; (q < 8) && (w < 8); q++, w++)
                    pol[q, w] = 1;
            }
            //выводим матрицу
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write("{0} ", pol[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
