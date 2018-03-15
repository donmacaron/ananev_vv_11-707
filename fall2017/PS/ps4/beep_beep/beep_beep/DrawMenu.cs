using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beep_beep
{
    class DrawMenu
    {
        public void MenuShow(string duration)
        {
            Console.Clear();
            int centerX = Console.BufferWidth / 2 - 6;
            int centerY = Console.BufferHeight / 2;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(centerX, 0);
            Console.WriteLine("CONTROLS:");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(0, 2);
            Console.Write("Buttons from 1 to 5 are changing duration\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("\nQ W\t E R T\t    Y U\t     I O P\t[ ]\nA Asharp B C Csharp D Dsharp E" +
                          " F Fsharp G Gsharp\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Press M to play SMB - WORLD 1-1 Theme.\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Duration: {0}", duration);

        }
    }
}
