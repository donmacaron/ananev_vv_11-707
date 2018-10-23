using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            string pattern = "[あ-ん]*[ア-ン]*[";
            string str = "やさいのカタカナ";
            Console.WriteLine(Regex.IsMatch(str, pattern));
            Console.WriteLine(Regex.Match(str, pattern).Value);
            Console.WriteLine(Regex.Matches(str, pattern).Count);
            Console.WriteLine("\n\n\n")



        }
    }
}
