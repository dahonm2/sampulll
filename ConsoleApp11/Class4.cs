using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp6
{
    class Menu
    {
        Game game = new Game();
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;
        public Menu(string Prompt, string[] Options)
        {
            this.Prompt = Prompt;
            this.Options = Options;
            SelectedIndex = 0;

        }
        private void DisplayOptions()
        {
            ForegroundColor = ConsoleColor.Gray;
            WriteLine(Prompt);
            ResetColor();
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;

                if (i == SelectedIndex)
                {
                    prefix = "> ";
                    ForegroundColor = ConsoleColor.Yellow;
                    BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    prefix = " ";
                    ForegroundColor = ConsoleColor.Cyan;
                    BackgroundColor = ConsoleColor.Black;
                }
                WriteLine(prefix + currentOption);
            }
            ResetColor();
        }
        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex < 0)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);
            return SelectedIndex;
        }
        public static string SelectOptions(string prompt, string[] options)
        {
            while (true)
            {
                try
                {
                    ForegroundColor = ConsoleColor.Cyan;
                    WriteLine(prompt);
                    for (int i = 0; i < options.Length; i++)
                    {
                        ForegroundColor = ConsoleColor.Yellow;
                        WriteLine($"[{i + 1}] {options[i]}");
                    }
                    ForegroundColor = ConsoleColor.White;
                    byte choice = Convert.ToByte(ReadLine());
                    ResetColor();
                    if (choice < 0 || choice > options.Length)
                    {

                        throw new UserOutOfIndexSelection(choice + "IS NOT A VALID OPTION. PLEASE CHOOSE APPROPRIATELY");
                    }

                    return options[choice - 1];
                }
                catch (UserOutOfIndexSelection error)
                {
                    ForegroundColor = ConsoleColor.DarkRed;
                    WriteLine("\nERROR: " + error.Message + "\n");
                    ResetColor();
                }
                catch (OverflowException)
                {
                    ForegroundColor = ConsoleColor.DarkRed;
                    WriteLine("\nERROR: PLEASE CHOOSE ONLY FROM THE GIVEN OPTIONS.\n");
                    ResetColor();
                }
                catch (FormatException)
                {
                    ForegroundColor = ConsoleColor.DarkRed;
                    WriteLine("\nERROR: PLEASE ENTER A VALID NUMBER.\n");
                    ResetColor();
                }
            }
        }
        public static byte AllocatePoints(byte currentStat, int remainingPoints)
        {
            while (true)
            {
                try
                {
                    ForegroundColor = ConsoleColor.DarkRed;
                    WriteLine("Points remaining: " + remainingPoints);
                    ResetColor();
                    ForegroundColor = ConsoleColor.White;
                    byte allocation = Convert.ToByte(ReadLine());
                    ResetColor();

                    if (allocation + currentStat > 3)
                    {
                        ForegroundColor = ConsoleColor.DarkRed;
                        WriteLine("YOU CAN ONLY ALLOCATE UP TO 3 POINTS TO THIS STAT.");
                        ResetColor();
                    }
                    else if (allocation > remainingPoints)
                    {
                        ForegroundColor = ConsoleColor.DarkRed;
                        WriteLine("YOU DON'T HAVE ENOUGH POINTS REMAINING.");
                        ResetColor();
                    }
                    else
                    {
                        return (byte)(currentStat + allocation);
                    }
                }
                catch (FormatException)
                {
                    ForegroundColor = ConsoleColor.DarkRed;
                    WriteLine("\nERROR: PLEASE ENTER A VALID NUMBER.\n");
                    ResetColor();
                }
                catch (OverflowException)
                {
                    ForegroundColor = ConsoleColor.DarkRed;
                    WriteLine("\nERROR: PLEASE CHOOSE ONLY FROM THE GIVEN OPTIONS.");
                    ForegroundColor = ConsoleColor.DarkRed;
                }
            }
        }

    }
}