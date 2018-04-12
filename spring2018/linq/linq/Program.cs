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
            //task 1
            var t1 = File.ReadAllLines(@"1.txt", Encoding.Default)
                .GroupBy(n => int.Parse(n.Split()[3]))
                .OrderByDescending(n => n.Key)
                .Last()
                .Last()
                .Split();
            File.WriteAllLines(@"1out.txt", 
                new[] { t1[3] + " " + t1[1] + " " + t1[2] },
                Encoding.Default);

            //task 11
            /*
            var t11 = File.ReadAllLines(@"1.txt", Encoding.Default)
                .GroupBy(n => int.Parse(n.Split()[3]))
                .OrderBy(n => n.Key)
                .Where(n => n[1] == n+1[1])
                */




        }
    }
}
