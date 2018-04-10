using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = File.ReadAllLines(@"1.txt", Encoding.Default)
                             .GroupBy(n => int.Parse(n.Split()[3]))
                             .OrderByDescending(n => n.Key)
                             .Last()
                             .Last()
                             .Split();

            var s = new[] { t[3] + " " + t[1] + " " + t[2] };
            File.WriteAllLines(@"1out.txt", s, Encoding.Default);
        }
    }
}
