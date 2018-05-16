using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;


namespace AtomicStation
{
    public class Police
    {
        public bool Arriving { get; set; }
    }
    public class Firmen
    {
        public bool Arriving { get; set; }
    }
    public class Emergency
    {
        public bool Arriving { get; set; }
    }
    public delegate void Deleg1();

    public class MyEvent
    {

        public event Deleg1 UserEvent;

        public void OnUserEvent()
        {
            if (UserEvent != null)
                UserEvent();

        }
    }


    class Program
    {
        static public int temperature = 1300;
        static public bool stepEvent = true;
        static public bool coolDown = false;
        static public int turns = 0;
        static public string text = "Keep Atomic Station's temperature above 700 C and below 1400 C!\n" +
            "After 4 turns of unstable work, station's going to stop working";
        static public string[] conditionTxt = { "High temperature!", "Normal temperature", "Low temperature" };

        static void Main(string[] args)
        {
            //Console.OutputEncoding = System.Text.Encoding.Unicode;
            while (stepEvent)
            {
                DrawText(0);
                UserInput();
                if (temperature > 1400)
                {
                    turns++;
                    Console.WriteLine(conditionTxt[0]);
                }
                if (temperature <= 1300 && temperature >= 700)
                {
                    turns = 0;
                    Console.WriteLine(conditionTxt[1]);
                } 
                if (temperature < 1000)
                {
                    turns++;
                    Console.WriteLine(conditionTxt[2]);
                }
                DrawText(0);
                if (turns >= 4 && temperature > 1400)
                {
                    stepEvent = false;
                    End("high");
                    break;
                }
                if (turns >= 4 && temperature < 700)
                {
                    stepEvent = false;
                    End("low");
                    break;
                }
                DrawText(1);
                Console.ReadKey();
                TempChange();
                DrawText(1);
                DrawText(2);
                Console.ReadKey();
                Console.Clear();
            }
        }

        static public void UserInput()
        {
            ConsoleKeyInfo ui = Console.ReadKey(true);
            switch (ui.Key)
            {
                case ConsoleKey.UpArrow:
                    TempUp("usr");
                    break;
                case ConsoleKey.DownArrow:
                    TempDown("usr");
                    break;
            }
        }
        //temperature changing
        static public void TempChange()
        {
            var r = new Random();
            var m = r.Next(0, 2);
            switch (m)
            {
                case 1:
                    TempUp("comp");
                    break;
                case 0:
                    TempDown("comp");
                    break;
            }
        }
        static public void TempUp(string cond)
        {
            var r = new Random();
            switch (cond)
            {
                case "usr":
                    temperature += r.Next(50, 300);
                    break;

                case "comp":
                    temperature += r.Next(0, 450);
                    break;
            }
        }
        static public void TempDown(string cond)
        {
            var r = new Random();
            switch (cond)
            {
                case "usr":
                    temperature -= r.Next(50, 300);
                    break;

                case "comp":
                    temperature -= r.Next(0, 450);
                    break;
            }
        }
        //drawing
        static public void TempColour()
        {
            if (temperature < 500)
                Console.ForegroundColor = ConsoleColor.Cyan;
            if (temperature < 600)
                Console.ForegroundColor = ConsoleColor.Blue;
            if (temperature < 700)
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            if (temperature > 700 && temperature < 1400)
                Console.ForegroundColor = ConsoleColor.Green;
            if (temperature > 1400)
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (temperature > 1500)
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (temperature > 1500)
                Console.ForegroundColor = ConsoleColor.Yellow;
            if (temperature > 1600)
                Console.ForegroundColor = ConsoleColor.DarkRed;
            if (temperature > 1700)
                Console.ForegroundColor = ConsoleColor.Red;
        }
        static public void TurnsColour()
        {
            switch(turns)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
        }
        static public void DrawText(int extra)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write($"{text}\n\nTemperature: ");
            TempColour();
            Console.Write($"{ temperature}\n");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Turns: ");
            TurnsColour();
            Console.Write($"{turns}\n\n");
            Console.ForegroundColor = ConsoleColor.White;

            if(extra == 0)
                Console.WriteLine("Press Up or Down to change temperature for the next turn");
            if(extra == 1)
                Console.WriteLine("Chaotic forces are interrupting temperature changin!\n" +
    "Press any key to accept your destiny...");
            if(extra == 2)
                Console.Write("Temperature has changed!\n" +
    "Press any key to proceed to the next turn...");
        }

        static public void End(string cond)
        {
            switch(cond)
            {
                case "high":
                    Console.Clear();
                    //Console.SetCursorPosition(0, centerY - 4);
                    Console.ForegroundColor = ConsoleColor.Red;
                    var fileStream = new FileStream(@"explosion.txt", FileMode.Open, FileAccess.Read);
                    using (var streamReader = new StreamReader(fileStream, Encoding.Unicode))
                    {
                        string line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                    Console.ReadKey();
                    break;
                case "low":
                    Console.Clear();
                    //Console.SetCursorPosition(0, centerY - 4);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    var fileStream0 = new FileStream(@"frozen.txt", FileMode.Open, FileAccess.Read);
                    using (var streamReader = new StreamReader(fileStream0, Encoding.Unicode))
                    {
                        string line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                    Console.WriteLine("BOOM!");
                    Console.ReadKey();
                    break;
            }
            Console.Clear();
            
        }
    }
}
