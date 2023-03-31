using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII_Navigator
{
    internal class ConsoleDrawer
    {
        private Tuple<int, int> Coordinates { get; set; }
        private char[,] fillCharacters;
        public ConsoleDrawer(int width, int height)
        {
            Console.SetWindowSize(width, height);
        }

        public ConsoleDrawer() { }



        public void FillConsole(char fillChar)
        {
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;

            fillCharacters = new char[width, height];

            for(int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(fillChar);
                    fillCharacters[i,j] = fillChar;

                }
            }
        }

        internal void ListenToConsole()
        {
            int x = 0;
            int y = 0;

            bool newLoc = true;

            Console.SetCursorPosition(x, y);
            Console.CursorVisible = false;

            do
            {
                if(newLoc)
                {
                    // Update the character at the new location to be green!
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(fillCharacters[x, y]);
                    newLoc = false;
                }

                ConsoleKey key = Console.ReadKey(true).Key;

                // Reset the color of the character at the old location
                Console.ResetColor();
                Console.SetCursorPosition(x, y);
                Console.Write(fillCharacters[x, y]);

                switch (key)
                {
                    case ConsoleKey.UpArrow:    // Select previous option (looping around)
                        {
                            if (y > 0)
                            {
                                y--;
                                newLoc = true;
                            }
                            else
                            {
                                Console.Beep();
                                continue;
                            }
                            break;
                        }
                    case ConsoleKey.DownArrow:  // Select Next Option (looping arround)
                        {
                            if (y < (Console.WindowHeight - 1))
                            {
                                y++;
                                newLoc = true;
                            }
                            else
                            {
                                Console.Beep();
                                continue;
                            }
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                        {
                            if (x > 0)
                            {
                                x--;
                                newLoc = true;
                            }
                            else
                            {
                                Console.Beep();
                                continue;
                            }
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (x < (Console.WindowWidth - 1))
                            {
                                x++;
                                newLoc = true;
                            }
                            else
                            {
                                Console.Beep();
                                continue;
                            }
                            break;
                        }
                    case ConsoleKey.Q:
                    case ConsoleKey.Escape:
                        {
                            Console.Clear();
                            Console.WriteLine("Exiting ASCII-Navigator Software...");
                            System.Environment.Exit(1);
                            break;
                        }
                    default:
                        break;
                }

            } while (true);
        }
    }
}
