using System;
using System.Threading;
using static System.Console;

namespace ConsoleApp6
{
    public abstract class dkopaAlamParaSaan
    {
        public void displayTitleScreen()
        {

            string output = "WELCOME TO HELL";
            ForegroundColor = ConsoleColor.DarkRed;
            Write(output);
            ResetColor();


            WriteLine("\n\nLOADING");

            int loadingBarLength = 38;

            for (int i = 0; i <= loadingBarLength; i++)
            {
                Random rand = new Random();
                int loadingTime = rand.Next(50, 100);
                Thread.Sleep(loadingTime);

                int percentage = (int)((float)i / loadingBarLength * 100);


                SetCursorPosition(0, 2);

                ForegroundColor = ConsoleColor.DarkBlue;
                Write("LOADING ");
                ResetColor();

                WriteLine("  ");
                Console.ForegroundColor = ConsoleColor.White;
                BackgroundColor = ConsoleColor.Black;
                Write(new string('▄', i) + "  " + percentage + "%");
            }
            ResetColor();
            WriteLine();
        }

        public abstract void NewGame();
        public abstract void LoadGame();
        public abstract void CampaignMode();
        public abstract void Credits();
        public abstract void Exit();
    }
}