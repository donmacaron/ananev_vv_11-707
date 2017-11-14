using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3_8
{
    class Program
    {
        static void Main(string[] args)
        {
            //sawtooth sequence
            Console.WriteLine("Enter amount of elements in the sequence:");
            bool check = false;
            int n = int.Parse(Console.ReadLine());
            int[] seq = new int[n];
            ArrayInput(seq.Length).CopyTo(seq,0);
            /*
            Console.WriteLine("Sequence: ");
            for (int i = 0; i < seq.Length; i++)
            {
                Console.Write(seq[i] + " ");
            }
            */
            for(int i = 1; i < seq.Length-1; i++)
            {
                if ((seq[i - 1] > seq[i]) && (seq[i] < seq[i + 1])|| (seq[i - 1] < seq[i]) && (seq[i] > seq[i + 1])) { check = !check; }              
            }
            if (check) { Console.WriteLine("The sequence is a sawtooth sequence."); }
            else { Console.WriteLine("The sequence is not a sawtooth sequence :<"); }
            Console.ReadKey();
        }

        static int[] ArrayInput(int arrLen)
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
    }
}
