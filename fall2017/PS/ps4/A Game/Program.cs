using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            //=========== Window ==============//
            Console.Title = "Umm... probably something.. dunno...";
            Console.SetWindowSize(55,20);
            Console.SetBufferSize(55, 20);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = false;


            //=========== Things are here ===========//
            Menu menuManager = new Menu();
            menuManager.MenuLoop();
        }
    }
}
