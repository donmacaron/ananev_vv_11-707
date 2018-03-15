using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace A_Game
{
    class Menu
    {
        public int menuScreen = 1;
        public int menuOption = 1;
        public int menuNum = 4;
        public bool menuStepEvent = true;
        private int centerX = Console.BufferWidth / 2 - 6;
        private int centerY = Console.BufferHeight / 2;

        public void MenuLoop()
        {
            while (menuStepEvent)
            {
                switch (menuScreen)
                {
                    case 1:
                        SplashScreen();
                        break;
                    case 2:
                        TitleScreen();
                        break;
                    case 3:
                        MainMenu();
                        break;

                    case 4:
                        NewGame();
                        break;

                    case 5:
                        Scores();
                        break;

                    case 6:
                        About();
                        break;

                    case 7:
                        Exit();
                        break;
                }
                userInput();
            }
        }

        //####### <MENU> #############
        public void SplashScreen()
        {
            Console.Clear();
           // Console.SetCursorPosition(centerX, centerY);
            var fileStream = new FileStream(@"Splash.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.Unicode))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        public void TitleScreen()
        {
            Console.Clear();
            Console.SetCursorPosition(0, centerY-4);
            var fileStream = new FileStream(@"Title.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.Unicode))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        public void MainMenu()
        {
            switch (menuOption)
            {
                case 1:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(centerX, 0);
                    Console.Write("MAIN MENU");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(centerX, 4);
                    Console.WriteLine("Start Game");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.SetCursorPosition(centerX, 5);
                    Console.WriteLine("Scores");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.SetCursorPosition(centerX, 6);
                    Console.WriteLine("About");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(centerX, 7);
                    Console.WriteLine("Exit");
                    break;
                case 2:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(centerX, 0);
                    Console.Write("MAIN MENU");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.SetCursorPosition(centerX, 4);
                    Console.WriteLine("Start Game");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(centerX, 5);
                    Console.WriteLine("Scores");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.SetCursorPosition(centerX, 6);
                    Console.WriteLine("About");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(centerX, 7);
                    Console.WriteLine("Exit");
                    break;
                case 3:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(centerX, 0);
                    Console.Write("MAIN MENU");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.SetCursorPosition(centerX, 4);
                    Console.WriteLine("Start Game");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.SetCursorPosition(centerX, 5);
                    Console.WriteLine("Scores");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(centerX, 6);
                    Console.WriteLine("About");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(centerX, 7);
                    Console.WriteLine("Exit");
                    break;
                case 4:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(centerX, 0);
                    Console.Write("MAIN MENU");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.SetCursorPosition(centerX, 4);
                    Console.WriteLine("Start Game");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.SetCursorPosition(centerX, 5);
                    Console.WriteLine("Scores");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.SetCursorPosition(centerX, 6);
                    Console.WriteLine("About");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(centerX, 7);
                    Console.WriteLine("Exit");
                    break;
            }
        }

        public void NewGame()
        {
            Console.Clear();
            Console.SetCursorPosition(centerX, centerY);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("NEW GAME");
        }

        public void Scores()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(centerX, 0);
            Console.Write("HI-scores");
        }

        public void About()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(centerX, 0);
            Console.Write("About");
        }

        public void Exit()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(centerX, 0);
            Console.Write("Already leaving?");
            Console.SetCursorPosition(centerX-4, centerY);
            Console.Write("Are you sure about that?");
            Console.SetCursorPosition(centerX, centerY + 3);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Nay!");
            Console.SetCursorPosition(centerX, centerY + 4);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Naaah...!");
            switch (menuOption)
            {
                case 1:
                    Console.SetCursorPosition(centerX, centerY+3);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("Nay!");
                    Console.SetCursorPosition(centerX, centerY+4);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Naaah...!");
                    break;
                case 2:
                    Console.SetCursorPosition(centerX, centerY+3);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Nay!");
                    Console.SetCursorPosition(centerX, centerY+4);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("Naaah...!");
                    break;
            }

        }
        //####### < /MENU> #############

        //####### < INPUT > ############
        public void userInput()
        {
            ConsoleKeyInfo ui = Console.ReadKey(true);
            switch (ui.Key)
            {
                case ConsoleKey.Enter:
                    MenuEnter();
                    break;
                case ConsoleKey.UpArrow:
                    MenuUp();
                    break;
                case ConsoleKey.DownArrow:
                    MenuDown();
                    break;
            }
        }

        void MenuUp()
        {
            switch (menuScreen)
            {
                case 3:
                    if (menuOption > 1)
                    {
                        menuOption--;
                    }
                    else
                        menuOption = menuNum;
                    break;
                case 7:
                    if (menuOption > 1)
                    {
                        menuOption--;
                    }
                    else
                        menuOption = 2;
                    break;
            }
        }

        void MenuDown()
        {
            switch (menuScreen)
            {
                case 3:
                    if (menuOption < menuNum)
                    {
                        menuOption++;
                    }
                    else
                        menuOption = 1;
                    break;
                case 7:
                    if (menuOption < 2)
                    {
                        menuOption++;
                    }
                    else
                        menuOption = 1;
                    break;
            }
        }

        void MenuEnter()
        {
            switch (menuScreen)
            {
                case 1: //splash screen
                    menuScreen = 2; 
                    break;

                case 2: //title screen
                    menuScreen = 3; 
                    break;

                case 3: //main menu
                    switch (menuOption)
                    {
                        case 1:
                            menuScreen = 4; // new game
                            break;

                        case 2:
                            menuScreen = 5; // scores
                            break;

                        case 3:
                            menuScreen = 6; // about
                            break;

                        case 4:
                            menuScreen = 7; // exit
                            break;
                    } 
                    break;

                case 5: //scores
                    menuScreen = 3; // return from scores
                    menuOption = 1;
                    break;
                case 6: //about
                    menuScreen = 3; // retrun from about
                    menuOption = 1;
                    break;
                case 7: //exit menu
                    switch(menuOption)
                    {
                        case 1: // exiting game
                            menuStepEvent = false;
                            break;
                        case 2: // return to main menu
                            menuScreen = 3; 
                            menuOption = 1;
                            break;
                    }
                    break;
            }
        }

        //####### < /INPUT > ###########
    }
}
