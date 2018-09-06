using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge2Lists
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }

    public class LinkedList<T> : IEnumerable
    {
        public int Count { get; private set; }

        public Node<T> Head { get; set; }

        public Node<T> Tail { get; set; }

        public void Add(T item)
        {
            Node<T> node = new Node<T>() { Data = item };

            if (Head == null)
            {
                Head = Tail = node;
            }

            else
            {
                Tail.Next = node;
                Tail = node;
            }

            Count++;
        }

        public bool Remove(T item)
        {
            Node<T> previous = null;
            Node<T> current = Head;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                            Tail = previous;
                    }
                    else
                    {
                        Head = Head.Next;
                        if (Head == null)
                            Tail = null;
                    }

                    Count--;

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0)
                    throw new IndexOutOfRangeException();

                var item = Head;

                for (int i = 0; i < index; i++)
                    if (item.Next == null)
                        throw new IndexOutOfRangeException();
                    else
                        item = item.Next;

                return item.Data;
            }
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            Node<T> current = Head;

            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    class TwoSortedListsMerge<T> where T : IComparable<T>
    {
        public static LinkedList<T> Merge(LinkedList<T> First, LinkedList<T> Second)
        {
            var newList = new LinkedList<T>();
            var firstElem = First.Head;
            var secondElem = Second.Head;
            while (firstElem != null && secondElem != null)
            {
                if (firstElem.Data.CompareTo(secondElem.Data) < 0)
                {
                    newList.Add(firstElem.Data);
                    firstElem = firstElem.Next;
                }
                else
                {
                    newList.Add(secondElem.Data);
                    secondElem = secondElem.Next;
                }
            }
            if (firstElem != null)
            {
                while (firstElem != null)
                {
                    newList.Add(firstElem.Data);
                    firstElem = firstElem.Next;
                }
            }
            else if (secondElem != null)
            {
                while (secondElem != null)
                {
                    newList.Add(secondElem.Data);
                    secondElem = secondElem.Next;
                }
            }
            return newList;
        }
    }
}
