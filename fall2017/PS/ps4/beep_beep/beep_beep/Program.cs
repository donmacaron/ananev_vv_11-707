using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace beep_beep
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "HAWT DAWGZ";
            Console.SetWindowSize(55, 20);
            Console.SetBufferSize(55, 20);
            Console.CursorVisible = false;
            int centerX = Console.BufferWidth / 2 - 6;
            int centerY = Console.BufferHeight / 2;
            MarioTheme playMario = new MarioTheme();
            DrawMenu drawMenu = new DrawMenu();

            bool loop = true;
            /*string menu = "Controls (notes below buttons on keyboard):" +
                          "\nQ W\t E R T\t    Y U\t     I O P\t[ ]\nA Asharp B C Csharp D Dsharp E" +
                          " F Fsharp G Gsharp\n\nM - Mario theme"; */
            drawMenu.MenuShow("WHOLE");
            int dur = (int)Duration.WHOLE;
            while (loop)
            {
                ConsoleKeyInfo ui = Console.ReadKey(true);
                switch (ui.Key)
                {
                    case ConsoleKey.M:
                        playMario.MarioThemePlay();
                        break;

                    #region DURATION
                    case ConsoleKey.D1:
                        drawMenu.MenuShow("WHOLE");
                        dur = (int)Duration.WHOLE;
                        break;
                    case ConsoleKey.D2:
                        drawMenu.MenuShow("HALF");
                        dur = (int)Duration.HALF;
                        break;
                    case ConsoleKey.D3:
                        drawMenu.MenuShow("QUARTER");
                        dur = (int)Duration.QUARTER;
                        break;
                    case ConsoleKey.D4:
                        drawMenu.MenuShow("EIGHTH");
                        dur = (int)Duration.EIGHTH;
                        break;
                    case ConsoleKey.D5:
                        drawMenu.MenuShow("SIXTEENTH");
                        dur = (int)Duration.SIXTEENTH;
                        break;
                    #endregion

                    #region NOTES
                    case ConsoleKey.Q:
                        Console.Beep((int)Tone.A, dur);
                        break;
                    case ConsoleKey.W:
                        Console.Beep((int)Tone.Asharp, dur);
                        break;
                    case ConsoleKey.E:
                        Console.Beep((int)Tone.B, dur);
                        break;
                    case ConsoleKey.R:
                        Console.Beep((int)Tone.C, dur);
                        break;
                    case ConsoleKey.T:
                        Console.Beep((int)Tone.Csharp, dur);
                        break;
                    case ConsoleKey.Y:
                        Console.Beep((int)Tone.D, dur);
                        break;
                    case ConsoleKey.U:
                        Console.Beep((int)Tone.Dsharp, dur);
                        break;
                    case ConsoleKey.I:
                        Console.Beep((int)Tone.E, dur);
                        break;
                    case ConsoleKey.O:
                        Console.Beep((int)Tone.F, dur);
                        break;
                    case ConsoleKey.P:
                        Console.Beep((int)Tone.Fsharp, dur);
                        break;
                    case ConsoleKey.Oem4:
                        Console.Beep((int)Tone.G, dur);
                        break;
                    case ConsoleKey.Oem6:
                        Console.Beep((int)Tone.Gsharp, dur);
                        break;
                    #endregion
                }
            }
        }

        protected enum Duration
        {
            WHOLE = 1600,
            HALF = WHOLE / 2,
            QUARTER = HALF / 2,
            EIGHTH = QUARTER / 2,
            SIXTEENTH = EIGHTH / 2,
        }

        protected enum Tone
        {
            REST = 0,
            GbelowC = 196,
            A = 220,
            Asharp = 233,
            B = 247,
            C = 262,
            Csharp = 277,
            D = 294,
            Dsharp = 311,
            E = 330,
            F = 349,
            Fsharp = 370,
            G = 392,
            Gsharp = 415,
        }
    }
}
/*

        protected static void Play(Note[] tune)
        {
            foreach (Note n in tune)
            {
                if (n.NoteTone == Tone.REST)
                    Thread.Sleep((int)n.NoteDuration);
                else
                    Console.Beep((int)n.NoteTone, (int)n.NoteDuration);
            }
        }

        protected struct Note
        {
            Tone toneVal;
            Duration durVal;

            // Define a constructor to create a specific note.
            public Note(Tone frequency, Duration time)
            {
                toneVal = frequency;
                durVal = time;
            }

            // Define properties to return the note's tone and duration.
            public Tone NoteTone { get { return toneVal; } }
            public Duration NoteDuration { get { return durVal; } }
        }
    */
