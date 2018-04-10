using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sem1
{
    public class DLinkedList<T> 
    {
        Node<T> head;
        Node<T> tail;
        Node<T> data;
        int count;

        public void Add(int data)
        {
            Node<T> node = new Node<T>(data);

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
            Node<T> node = new Node<T>(data);
            Node<T> temp = head;
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
            Node<T> current = head;
            //search
            while (current != null)
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
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void CreateFromIntArr(int[] data)
        {
            for (int i = 0; i < data.Length; i++)
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
            FileStream fs1 = new FileStream("D:\\decode.txt", FileMode.OpenOrCreate, FileAccess.Write);
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
            Node<T> current = head;
            while (current != null)
            {
                Console.Write($"{current.Data}->");
                current = current.Next;
            }
            Console.WriteLine("null");
        }

        public DLinkedList<T> NewList(int j) 
        {
            DLinkedList<T> NewList = new DLinkedList<T>();
            NewList.Add(0);
            Node<T> NewCur = NewList.head;
            Node<T> current = head;
            int counter = 0;
            while (counter != j)
            {
                counter++;
                current = current.Next;
            }
            j = current.Data;
            current = head;
            while (counter != count)
            {
                NewCur.Data = j * (count - current.Data);
                counter++;
                NewList.Add(0);
                NewCur = NewCur.Next;
            }
            return NewList;
        }

        public int MaxNum() //done
        {
            int res = 0;
            int max = 1;
            int temp = 0;
            Node<T> current = head;
            while (current != null)
            {
                if (current.Next != null)
                {
                    if (current.Data == current.Next.Data)
                    {
                        res++;
                        if((res>max)&&(res!=0))
                        {
                            max = res;
                        }
                    }
                    else
                        res = 0; 
                }
                temp = current.Data;
                current = current.Next;
            }
            return max;
        }

        public Node<T>[] Divide()
        {
            Node<T> current = head;
            DLinkedList<T> multipleThree = new DLinkedList<T>();
            DLinkedList<T> normalDigits = new DLinkedList<T>();

            while (current != null)
            {
                if (current.Data % 3 == 0)
                {
                    multipleThree.Add(current.Data);
                }
                else
                {
                    normalDigits.Add(current.Data);
                }
                current = current.Next;
            }

            return new Node<T>[] { multipleThree.head, normalDigits.head };
        }


        public void Merge(DLinkedList<T> list2)
        {
            var elem1 = head;
            while (list2.head != null)
            {
                var current = list2.head;
                if (current.CompareTo(elem1) < 0)
                {
                    list2.head = current.Next;
                    current.Next = head;
                    head.Previous = current;
                    head = current;
                }
                else if (current.CompareTo(elem1) > 0)
                {
                    var elem2 = head.Next;
                    while (current.CompareTo(elem2) > 0)
                    {
                        if (elem2.Next == null)
                        {
                            break;
                        }
                        elem2 = elem2.Next;

                    }
                    list2.head = current.Next;

                    elem2.Previous.Next = current;
                    current.Previous = elem2.Previous;
                    current.Next = elem2;
                    elem2.Previous = current;
                }
                else if (current.CompareTo(elem1) == 0)
                {
                    list2.head = current.Next;
                    current.Next = head.Next;
                    current.Previous = head;
                    head.Next = current;

                }
            }

        }
    }
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
        

