using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sem1
{
    public class Node<T>
    {
        public Node(int data)
        {
            Data = data;
        }
        public int Data { get; set; }
        public Node<T> Previous { get; set; }
        public Node<T> Next { get; set; }
    }

    public class DLinkedList<T> //: IEnumerable<T>
    {
        Node<int> head;
        Node<int> tail;
        int count;

        public void Add(int data)
        {
            Node<int> node = new Node<int>(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }

        public void AddFirst(int data)
        {
            Node<int> node = new Node<int>(data);
            Node<int> temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previous = node;
            count++;
        }

        public bool Delete(T data)
        {
            Node<int> current = head;
            //search
            while(current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }
            //if node is not last
            if (current != null)
            {
                if (current.Next != null)
                    current.Next.Previous = current.Previous;
                else
                    //if last
                    tail = current.Previous;

                //if node's not 1st
                if (current.Previous != null)
                    current.Previous.Next = current.Next;
                else
                    head = current.Next;

                count--;
                return true;
            }
            return false;
        }

        public int Count { get { return count; } }

        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            Node<int> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void CreateFromIntArr (int[] data)
        {
            for (int i = 0; i<data.Length; i++)
            {
                Add(data[i]);
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Double linked list from int array created ");
            Console.ForegroundColor = ConsoleColor.White;
            ShowList();
        }

        public void Decode(int[] data)
        {
            FileStream fs1 = new FileStream("C:\\decode.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs1);
            for (int i = 0; i < data.Length; i++)
            {
                writer.Write($"{data[i].ToString()} ");
            }
            writer.Write($"null");
            writer.Close();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Double linked list's values are written to C:\\decode.txt");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ShowList()
        {
            Node<int> current = head;
            while (current != null)
            {
                Console.Write($"{current.Data}->");
                current = current.Next;
            }
            Console.WriteLine("null");
        }

        /*
        public IEnumerator<T> GetEnumerator()
        {
            DLinkedList<T> list = new DLinkedList<T>();
            return list.Cast<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        */
    }

    class Program
    {
        static void Main(string[] args)
        {
            DLinkedList<int> linkedList = new DLinkedList<int>();
            DLinkedList<int> likedList2 = new DLinkedList<int>();
            int k;
            int n;

            Console.WriteLine("Input size of array..");
            n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            Console.WriteLine("Input array elements..");
            for(int i = 0; i<array.Length;i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }


            //#1
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("sTask #1\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            linkedList.CreateFromIntArr(array);

            //#2
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\n\nTask #2\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            linkedList.Decode(array);

            //#3
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\n\nTask #3\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write("Input 'k'...");
            k = int.Parse(Console.ReadLine());
            linkedList.Add(k);
            linkedList.ShowList();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Added {k}");
            Console.ForegroundColor = ConsoleColor.White;

            //#4
            { 
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\n\nTask #4\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            linkedList.Delete(k);
            linkedList.ShowList();

            Console.ReadKey();
        }
    }
}
