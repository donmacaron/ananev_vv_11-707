using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3_15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter amount of elements in the sequence:");
           
            int n = int.Parse(Console.ReadLine());
            int[] seq = new int[n];

            Console.WriteLine("Automatic or manual input of sequence? a/m");
            string choice = Console.ReadLine();
            if (choice == "m" || choice == "M") { ManualArrFill(seq.Length).CopyTo(seq, 0); }
            else if (choice == "a" || choice == "A") { AutoArrFill(seq.Length).CopyTo(seq, 0); }

            Console.WriteLine("Sequence: ");
            for (int i = 0; i < seq.Length; i++)
            {
                Console.Write(seq[i] + " ");
            }
            Console.WriteLine("\nEnter number which max chain you want to find:");
            int k = int.Parse(Console.ReadLine());

            int counter = 0;
            int max = 0;
            for(int i=0; i<seq.Length-1;i++)
            {
                if((seq[i] == k)&&(seq[i]==seq[i+1]))
                {
                    counter++;
                    if (counter > max) { max = counter; }
                }
                else { counter = 0; }
            }
            Console.WriteLine($"The max chain of {k} is {max+1}");
            Console.ReadKey();
        }
        static int[] ManualArrFill(int arrLen)
        {
            Console.WriteLine("Input the elements through the gap.");
            string sqString = Console.ReadLine();
            string[] splitString = sqString.Split(' ');
            int[] res = new int[arrLen];

            for (int i = 0; i < arrLen; i++)
            {
                int x;
                int.TryParse(splitString[i], out x);
                res[i] = x;
            }
            return res;
        }
        static int[] AutoArrFill(int arrLen)
        {
            int[] res = new int[arrLen];
            Random rand = new Random();
            for (int i = 0; i < res.Length; i++)
                res[i] = rand.Next(0,10);
            return res;
        }
    }
}
