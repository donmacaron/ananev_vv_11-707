using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;

namespace ThreadsStudy
{
    public class Matrix
    {
        double[,] matrix;
        public int Row { get; protected set; }
        public int Column { get; protected set; }
        public int Threads { get; protected set; }
        public int Iterations = 0;




        public Matrix(int row, int column)
        {
            Row = row;
            Column = column;
            Threads = 4;
            matrix = new double[row, column];
        }

        public void Create()
        {
            Random rand = new Random();
            for (int i = 0; i < Row; i++)
                for (int j = 0; j < Column; j++)
                    matrix[i, j] = rand.Next(0, 100);
        }

        public void Print(bool r)
        {
            if (r == true)
            {
                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Column; j++)
                        Console.Write($"{matrix[i, j]} ");
                    Console.WriteLine("\n");
                }
            }
            else
            {
                if (Row > 1)
                    Console.WriteLine($"Matrix: {Column}x{Row}");
                else
                    Console.WriteLine($"Vector: {Column}");
            }

        }


        public Matrix Multiple(Matrix value)
        {
            Matrix result = new Matrix(Row, value.Column);
            for (int i = 0; i < Row; i++)
                for (int j = 0; j < value.Column; j++)
                    for (int k = 0; k < value.Row; k++)
                        result.matrix[i, j] += matrix[i, k] * value.matrix[k, j];
            return result;
        }

       

        public Matrix MultipleParallelFor(Matrix value)
        {
            Matrix result = new Matrix(Row, value.Column);
            Parallel.For(0, Row, i =>
            {
                for (int j = 0; j < value.Column; j++)
                    for (int k = 0; k < value.Row; k++)
                        result.matrix[i, j] += matrix[i, k] * value.matrix[k, j];
            }
            );        
            return result;
        }


        public Matrix MultipleFunc1(Matrix value)
        {
            Matrix result = new Matrix(Row, value.Column);
            int d = value.Column / 4, sum = 0;
            int id = Convert.ToInt32(Task.CurrentId) - 1;
            int i1 = d * id;
            int i2 = d * (id + 1);

            for (int i = i1; i < i2; i++)
                for (int j = 0; j < value.Column; j++)
                    for (int k = 0; k < i2; k++)
                        result.matrix[i, j] += matrix[i, k] * value.matrix[k, j];



            return result;
        }

    }

    class Program
    {

        static void Main(string[] args)
        {
            Task[] tasks = new Task[4];
            var n = new int[]{4, 1000, 2000, 3000, 4000, 5000};
            Matrix vector0 = new Matrix(1, n[0]);
            Matrix matrix0 = new Matrix(n[0], n[0]);
            Matrix vector1 = new Matrix(1, n[1]);
            Matrix matrix1 = new Matrix(n[1], n[1]);
            Matrix vector2 = new Matrix(1, n[2]);
            Matrix matrix2 = new Matrix(n[2], n[2]);
            Matrix vector3 = new Matrix(1, n[3]);
            Matrix matrix3 = new Matrix(n[3], n[3]);
            Matrix vector4 = new Matrix(1, n[4]);
            Matrix matrix4 = new Matrix(n[4], n[4]);
            Matrix vector5 = new Matrix(1, n[5]);
            Matrix matrix5 = new Matrix(n[5], n[5]);
            Stopwatch stopwatch = new Stopwatch();

            vector0.Create();
            matrix0.Create();
            vector1.Create();
            matrix1.Create();
            vector2.Create();
            matrix2.Create();
            vector3.Create();
            matrix3.Create();
            vector4.Create();
            matrix4.Create();
            vector5.Create();
            matrix5.Create();

            string text0 = "Elapsed time without trhreadings in milliseconds:";
            string text1 = "Elapsed time with Parallel.For in milliseconds:";


            #region Parallel.For
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Calculations with using Parallel.For");
            Console.ForegroundColor = ConsoleColor.White;

            {
                stopwatch.Start();
                Matrix result0 = vector0.MultipleParallelFor(matrix0);
                stopwatch.Stop();
                var t0 = stopwatch.ElapsedMilliseconds;
                vector0.Print(false);
                matrix0.Print(false);
                result0.Print(false);
                Console.WriteLine($"{text1} {t0}");
                Console.WriteLine("\n");
            }

            {
                stopwatch.Restart();
                Matrix result1 = vector1.MultipleParallelFor(matrix1);
                stopwatch.Stop();
                var t1 = stopwatch.ElapsedMilliseconds;
                vector1.Print(false);
                matrix1.Print(false);
                result1.Print(false);
                Console.WriteLine($"{text1} {t1}");
                Console.WriteLine("\n");
            }

            {
                stopwatch.Restart();
                Matrix result2 = vector2.MultipleParallelFor(matrix2);
                stopwatch.Stop();
                var t2 = stopwatch.ElapsedMilliseconds;
                vector2.Print(false);
                matrix2.Print(false);
                result2.Print(false);
                Console.WriteLine($"{text1} {t2}");
                Console.WriteLine("\n");
            }

            {
                stopwatch.Restart();
                Matrix result3 = vector3.MultipleParallelFor(matrix3);
                stopwatch.Stop();
                var t3 = stopwatch.ElapsedMilliseconds;
                vector3.Print(false);
                matrix3.Print(false);
                result3.Print(false);
                Console.WriteLine($"{text1} {t3}");
                Console.WriteLine("\n");
            }

            {
                stopwatch.Restart();
                Matrix result4 = vector4.MultipleParallelFor(matrix4);
                stopwatch.Stop();
                var t4 = stopwatch.ElapsedMilliseconds;
                vector4.Print(false);
                matrix4.Print(false);
                result4.Print(false);
                Console.WriteLine($"{text1} {t4}");
                Console.WriteLine("\n");
            }

            {
                stopwatch.Restart();
                Matrix result5 = vector5.MultipleParallelFor(matrix5);
                stopwatch.Stop();
                var t5 = stopwatch.ElapsedMilliseconds;
                vector5.Print(false);
                matrix5.Print(false);
                result5.Print(false);
                Console.WriteLine($"{text1} {t5}");
                Console.WriteLine("\n");
            }
            #endregion


            #region without threadings
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Calculations without using threads'n'tasks");
            Console.ForegroundColor = ConsoleColor.White;

            {
                stopwatch.Restart();
                Matrix result0 = vector0.Multiple(matrix0);
                stopwatch.Stop();
                var t0 = stopwatch.ElapsedMilliseconds;
                vector0.Print(false);
                matrix0.Print(false);
                result0.Print(false);
                Console.WriteLine($"{text0} {t0}");
                Console.WriteLine("\n");
            }

            {
                stopwatch.Restart();
                Matrix result1 = vector1.Multiple(matrix1);
                stopwatch.Stop();
                var t1 = stopwatch.ElapsedMilliseconds;
                vector1.Print(false);
                matrix1.Print(false);
                result1.Print(false);
                Console.WriteLine($"{text0} {t1}");
                Console.WriteLine("\n");
            }

            {
                stopwatch.Restart();
                Matrix result2 = vector2.Multiple(matrix2);
                stopwatch.Stop();
                var t2 = stopwatch.ElapsedMilliseconds;
                vector2.Print(false);
                matrix2.Print(false);
                result2.Print(false);
                Console.WriteLine($"{text0} {t2}");
                Console.WriteLine("\n");
            }

            {
                stopwatch.Restart();
                Matrix result3 = vector3.Multiple(matrix3);
                stopwatch.Stop();
                var t3 = stopwatch.ElapsedMilliseconds;
                vector3.Print(false);
                matrix3.Print(false);
                result3.Print(false);
                Console.WriteLine($"{text0} {t3}");
                Console.WriteLine("\n");
            }

            {
                stopwatch.Restart();
                Matrix result4 = vector4.Multiple(matrix4);
                stopwatch.Stop();
                var t4 = stopwatch.ElapsedMilliseconds;
                vector4.Print(false);
                matrix4.Print(false);
                result4.Print(false);
                Console.WriteLine($"{text0} {t4}");
                Console.WriteLine("\n");
            }

            {
                stopwatch.Restart();
                Matrix result5 = vector5.Multiple(matrix5);
                stopwatch.Stop();
                var t5 = stopwatch.ElapsedMilliseconds;
                vector5.Print(false);
                matrix5.Print(false);
                result5.Print(false);
                Console.WriteLine($"{text0} {t5}");
                Console.WriteLine("\n");
            }
            #endregion

            Console.WriteLine("\n\n\n");



            stopwatch.Stop();

            //Task<Matrix> task1 = new Task<Matrix>((m5)=>MultipleFunc1(m5));


            Console.ReadKey();
        }
    }
}