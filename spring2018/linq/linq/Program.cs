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
            //task 1 Работает
            /*
            var t1 = File.ReadAllLines(@"1.txt", Encoding.Default)
                .GroupBy(n => int.Parse(n.Split()[3]))
                .OrderByDescending(n => n.Key)
                .Last()
                .Last()
                .Split();
            File.WriteAllLines(@"1out.txt", 
                new[] { t1[3] + " " + t1[1] + " " + t1[2] },
                Encoding.Default);
            */
            var t01 = File.ReadAllLines(@"1.txt", Encoding.Default)
                .Select(s => new Fitness(s))
                .GroupBy(n => n.hours)
                .OrderBy(n => n.Key)
                .Select(s => new { s.Key, s.Last().month, s.Last().year })
                .Take(1)
                .Select(s => $"Min houts:{s.Key} || Month:{s.month} || Year:{s.year}")
                .ToArray();

            File.WriteAllLines(@"1out.txt",
                t01,
                Encoding.Default);
            //System.Diagnostics.Process.Start(@"1out.txt");



            // Task 11 не рабоает
            var t11 = File.ReadAllLines(@"1.txt", Encoding.Default)
                .Select(s => new Fitness(s))
                .GroupBy(x => x.year)
                .OrderBy(n => n.Key)
                .Select(x => new { x.Key, x.First().month, x.First().hours})
                .Where(x => x.month == x.month)
                .Select(s => $"Total Hours:{s.hours} || Year:{s.Key} || Month:{s.month}")
                .ToArray();
           
            File.WriteAllLines(@"11out.txt",
                t11,
                Encoding.Default);
            //System.Diagnostics.Process.Start(@"11out.txt");



            // Task 21  ОНО РАБОТАТЕ!!11!!1 пыщь пыщь!111
            var t21 = File.ReadAllLines(@"21.txt", Encoding.Default)
                .Select(s => new Students(s))
                .OrderBy(n => n.enrYear)
                .GroupBy(x=>x.schoolN)
                .Select(x => new { x.Key, x.First().lastName, x.First().enrYear })
                .Select(s => $"Last Name:{s.lastName} || School №:{s.Key}")
                .ToArray();

            File.WriteAllLines(@"21out.txt",
                t21,
                Encoding.Default);
            //System.Diagnostics.Process.Start(@"21out.txt");



            //Task 31 НЕ РАБОТАЕТ
            var t31 = File.ReadAllLines(@"31.txt", Encoding.Default)
               .Select(s => new Deptors(s))
               .Select( x=>
                   {
                       if (x.flatN < 37)
                       {
                           x.entrance = 1;
                           return new { x.arrears, x.lastName, x.flatN, x.entrance };
                       }
                       if ((x.flatN > 36) && (x.flatN < 73))
                       {
                           x.entrance = 2;
                           return new { x.arrears, x.lastName, x.flatN, x.entrance };
                       }
                       if ((x.flatN > 72) && (x.flatN < 109))
                       {
                           x.entrance = 3;
                           return new { x.arrears, x.lastName, x.flatN, x.entrance };
                       }
                       if ((x.flatN > 108) && (x.flatN < 145))
                       {
                           x.entrance = 4;
                           return new { x.arrears, x.lastName, x.flatN, x.entrance };
                       }

                       return null;
                   })
               .Where(x=> x.entrance == 1)
               .OrderByDescending(x => x.arrears)
               .Take(3)
               .Select(s => $"Arrear:{s.arrears} || Entrance:{s.entrance} || Flat#:{s.flatN} || Last name:{s.lastName}")
               .ToArray();

            File.WriteAllLines(@"31out.txt",
                t31,
                Encoding.Default);
            //System.Diagnostics.Process.Start(@"31out.txt");



            // Task 41  
            var t41 = File.ReadAllLines(@"41.txt", Encoding.Default)
                .Select(s => new Petrol(s))
                .
                .ToArray();

            File.WriteAllLines(@"41out.txt",
                t41,
                Encoding.Default);
            System.Diagnostics.Process.Start(@"41out.txt");


            Console.WriteLine("Press any key...");

        }
    }
}
