using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        class MyStack<T>
        {
            private T[] items;
            private int count;

            public MyStack()
            {
                items = new T[count];
            }

            public MyStack(int length)
            {
                items = new T[length];
            }

            public bool IsEmpty
            {
                get { return count == 0; }
            }

            public int Count
            {
                get { return count; }
                set { }
            }

            public void Push(T item)
            {
                items[count++] = item;
            }

            public T Pop()
            {
                T item = items[--count];
                items[count] = default(T); // сбрасываем ссылку
                return item;
            }

            public T Peek()
            {
                return items[count - 1];
            }
        }

        class Clone
        {
            public int Id { get; set; }
            public Stack<string> Programs = new Stack<string>();
            public Stack<string> ArchivePrograms;
        }
        static void Main(string[] args)
        {

            List<string> list = new List<string>{ "Bewba", "Boomer", "Bronsky", "Bobert", "Booger" };
            MyStack<string> stack = new MyStack<string>(list.Count);

            foreach (var x in list)
            {
                stack.Push(x);
                Console.WriteLine($"Current stack peek: {stack.Peek()}");
            }

            Console.WriteLine($"\n\nStack count: {stack.Count}\n");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"Stack Count: {stack.Count}, Element: {stack.Pop()}");
            }




            Console.WriteLine("\n\n\n\n");

            //foreach(var x in ss)
            //{
            //    //Console.WriteLine(x);
            //    switch(x)
            //    {
            //        case "ME":
            //            Console.WriteLine($"this element contains: {ss[4]}");
            //            break;
            //    }
            //}


            Clone clone = new Clone();
            clone.Id = 2;
            clone.Programs.Push("Delta Force");
            clone.Programs.Push("213123");
            clone.Programs.Push("Bananoid");
            clone.Programs.Push("32423");
            clone.Programs.Pop();
            Console.WriteLine($"{clone.Programs.Peek()}");

            var s = "ME IS CHIEF OF BEWBA TRIBE";
            var ss = s.Split(' ');
            switch (ss[3])
            {
                case "OF":
                    clone.Programs.Push(ss[2]);
                    Console.WriteLine(clone.Programs.Pop());
                    
                    break;
            }


        }
    }
}
