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
            Console.WriteLine("Enter 1st coordinates");
            int num0 = Console.Read()-48;
            char inLet0 = (char)Console.Read();
            Console.ReadLine();
            Console.WriteLine("Enter 2nd coordinates");
            int num1 = Console.Read() - 48;
            char inLet1 = (char)Console.Read();
            if (InputCheck(num0, num1, inLet0, inLet1))
            {
                int let0 = Convert.ToInt32(inLet0) - 96;
                int let1 = Convert.ToInt32(inLet1) - 96;
                if ((num0-let0 == 0)&& (num1 - let1 == 0)) { Console.WriteLine("Same"); }
                else if ((Math.Abs(num0 - let0)== 1)&&(Math.Abs(num1 - let1) == 1)) { Console.WriteLine("Neighbour"); }
                else { Console.WriteLine("Nothing here"); }
            }
            else { Console.WriteLine("something gone wrong"); }
            Console.ReadKey();
        }
        static bool InputCheck(int num1, int num2, char let1, char let2)
        {
            bool corCheck1 = false;
            bool corCheck2 = false;
            if ((((num1 >= 1) & (num1 <= 8)) & (((let1 >= 'A') & (let1 <= 'H')) || ((let1 >= 'a') & (let1 <= 'h'))))) { corCheck1 = true; }
            if ((((num2 >= 1) & (num2 <= 8)) & (((let2 >= 'A') & (let2 <= 'H')) || ((let2 >= 'a') & (let2 <= 'h'))))) { corCheck2 = true; }
            return corCheck1 && corCheck2;
        }
    }
}
