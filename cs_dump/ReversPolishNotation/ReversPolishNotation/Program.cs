using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversPolishNotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string arg;
            Stack<double> st = new Stack<double>();
            Console.WriteLine("Enter your reverse polish notation.\n" +
                              "To get result enter \"do\" or \"=\"\n" +
                              "To close program enter \"exit\"");
            while ((arg = Console.ReadLine()) != "exit")
            {
                double num;
                bool isNum = double.TryParse(arg, out num);
                if (isNum)
                    st.Push(num);
                else
                {
                    double op2;
                    switch (arg)
                    {
                        case "+":
                            st.Push(st.Pop() + st.Pop());
                            break;
                        case "*":
                            st.Push(st.Pop() * st.Pop());
                            break;
                        case "-":
                            op2 = st.Pop();
                            st.Push(st.Pop() - op2);
                            break;
                        case "/":
                            op2 = st.Pop();
                            if (op2 != 0.0)
                                st.Push(st.Pop() / op2);
                            else
                                Console.WriteLine("division by zero is not acceptable");
                            break;
                        case "do":
                            Console.WriteLine("Result: " + st.Pop());
                            break;
                        case "=":
                            Console.WriteLine("Result: " + st.Pop());
                            break;
                        default:
                            Console.WriteLine("Unknown Command");
                            break;
                    }
                }
            }
        }
    }
}
