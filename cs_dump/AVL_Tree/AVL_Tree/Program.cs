using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            AVL b = new AVL();
            b.Add(4);
            b.Add(5);
            b.Add(3);
            b.Add(23);
            b.Add(87);
            b.Add(54);
            b.Add(5);
            b.DisplayTree();
            Console.WriteLine();

            b.Delete(5);
            b.DisplayTree();
            Console.WriteLine();

            b.Find(23);
            b.DisplayTree();
            Console.WriteLine();
        }
    }
}
