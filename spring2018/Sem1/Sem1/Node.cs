using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int CompareTo(Node<T> other)
        {
            var b = other.Data.ToString();
            var a = Data.ToString();
            if ((a[0] == '-') && (b[0] != '-'))
                return -1;
            else if ((a[0] != '-') && (b[0] == '-'))
                return 1;
            else if (a.Length < b.Length)
                return -1;
            else if (a.Length > b.Length)
                return 1;
            else
            {
                for (int i = 0; i < a.Length; i++)
                    if (char.ToLower(a[i]) < char.ToLower(b[i]))
                        return -1;
                    else if (a[i] > b[i])
                        return 1;
            }
            return 0;
        }
    }
}
