using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hash_table
{
    class Program
    {
        static void Main(string[] args)
        {
            MyHashTable<int, string> hashTable = new MyHashTable<int, string>(20);
            hashTable.Add(19, "boop");
            hashTable.Add(11, "sausages");
            Console.WriteLine(hashTable.GetByKey(19));
            Console.WriteLine(hashTable.GetByKey(11));
            //hashTable.Delete(19);



            Console.ReadKey();
        }
    }
}
