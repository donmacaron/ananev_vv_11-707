using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {

            Task2();

        }







        static void Task2()
        {
            string str = "00000 11111 011111 " +
                         "00000 11000110001 " +
                         "101010 010101 10101 010 " +
                         "0 1";
            List<string> list = new List<string>();
            String pattern = @"^(01)*0?$|^(10)*0?$";
            String pattern2 = @"(\b1*1\b)|(\b0*0\b)";
            foreach (Match match in Regex.Matches(str, pattern2))
            {
                list.Add(match.ToString()); 
            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        static void Task3C()
        {
            Random rand = new Random();
            string str = rand.Next(100).ToString();
            string pattern = @"^\d*[02468]$";
            if (Regex.IsMatch(str, pattern)) Console.WriteLine("Y "+str);
            else Console.WriteLine("N "+str);
        }

        static void Task3B()
        { }
    }
}
