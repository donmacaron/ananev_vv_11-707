using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversPolishNotation
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
}
