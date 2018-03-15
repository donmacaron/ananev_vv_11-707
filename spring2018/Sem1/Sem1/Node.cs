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
    }
}
