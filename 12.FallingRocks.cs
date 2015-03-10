using System;
using System.Collections.Generic;
using System.Threading;

struct Hero
{
    public int x;
    public int y;
    public string heroOutlook;
    public ConsoleColor color;
}
struct Rocks
{
    public int x;
    public int y;
    public char fallingRock;
    public ConsoleColor color;
}
class FallingRocks
{
    static void PrintOnPosition(int x, int y, string str, ConsoleColor color = ConsoleColor.DarkBlue) // for strings
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(str);
    }
    static void PrintOnPositionChar(int x, int y, char c, ConsoleColor color = ConsoleColor.DarkBlue) // for characters
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(c);
    }
    static List<char> RocksChars = new List<char>()
        {
        '\u005e',
        '\u0040',
        '\u002a',
        '\u0026',
        '\u002b',
        '\u0025',
        '\u0024',
        '\u0023',
        '\u0021',
        '\u002e',
        '\u003b',
        '\u002d'
        };
    static List<ConsoleColor> RocksColors = new List<ConsoleColor>()
    {
        ConsoleColor.Green,
        ConsoleColor.DarkBlue,
        ConsoleColor.DarkMagenta,
        ConsoleColor.Cyan,
        ConsoleColor.Magenta,
        ConsoleColor.Gray,
        ConsoleColor.Blue
    };
    static int playfieldWith = 40;
    static Random randomGenerator = new Random();

    public static object Properties { get; private set; }

    static void Main()
    {
        //Remove scroll bars
        Console.BufferHeight = Console.WindowHeight = 30;
        Console.BufferWidth = Console.WindowWidth = 61;
        Console.CursorVisible = false;

        //Initializing statistics
        int livesCount = 5;
        ulong score = 0U;

        Hero dwarf = new Hero();
        dwarf.x = 21;
        dwarf.y = Console.WindowHeight - 1;
        dwarf.heroOutlook = "(O)";
        dwarf.color = ConsoleColor.Yellow;

        List<Rocks> rocks = new List<Rocks>();
        PrintOnPosition(23, 14, "GET READY !!!", ConsoleColor.Red);
        Thread.Sleep(500);

        //Music for begining
        //Tones.PlaySong(Tetris());


        Console.Clear();
        PrintOnPosition(24, 14, "Go", ConsoleColor.Red);
        Thread.Sleep(400);
        PrintOnPosition(27, 14, "Go", ConsoleColor.Red);
        Thread.Sleep(400);
        PrintOnPosition(30, 14, "Go", ConsoleColor.Red);
        Thread.Sleep(400);
        PrintOnPosition(33, 14, "!", ConsoleColor.Red);
        Thread.Sleep(400);
        PrintOnPosition(35, 14, "!", ConsoleColor.Red);
        Thread.Sleep(400);
        PrintOnPosition(37, 14, "!", ConsoleColor.Red);
        Thread.Sleep(400);

        while (true)
        {
            bool hitted = false;
            {
                int chanceForCluster = randomGenerator.Next(0, 100);
                if (chanceForCluster < 30)
                {
                    int clusterSize = randomGenerator.Next(1, 4);
                    Rocks newRock = new Rocks();
                    newRock.fallingRock = RocksChars[randomGenerator.Next(0, RocksChars.Count)];
                    newRock.color = RocksColors[randomGenerator.Next(0, RocksColors.Count)];
                    newRock.x = randomGenerator.Next(3, playfieldWith - 3);
                    rocks.Add(newRock);
                    for (int i = 0; i < clusterSize; i++)
                    {
                        newRock.x -= i;
                        int hight = randomGenerator.Next(0, 100);
                        if (hight < 50)
                        { newRock.y++; }
                        rocks.Add(newRock);
                    }
                }
                else
                {
                    Rocks newRock = new Rocks();
                    newRock.color = RocksColors[randomGenerator.Next(0, RocksColors.Count)];
                    newRock.x = randomGenerator.Next(0, playfieldWith);
                    newRock.y = 0;
                    newRock.fallingRock = RocksChars[randomGenerator.Next(0, RocksChars.Count)]; ;
                    rocks.Add(newRock);
                }
            }

            //Move our hero (key pressed)
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable) Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (dwarf.x - 1 >= 0)
                    {
                        dwarf.x = dwarf.x - 1;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (dwarf.x + 3 < playfieldWith)
                    {
                        dwarf.x = dwarf.x + 1;
                    }
                }
            }

            List<Rocks> newList = new List<Rocks>();
            //Move rocks
            for (int i = 0; i < rocks.Count; i++)
            {
                Rocks oldRock = rocks[i];
                Rocks newRock = new Rocks();
                newRock.x = oldRock.x;
                newRock.y = oldRock.y + 1;
                newRock.fallingRock = oldRock.fallingRock;
                newRock.color = oldRock.color;
                if (newRock.y == dwarf.y && (newRock.x == (dwarf.x) ^ newRock.x == (dwarf.x + 1) ^ newRock.x == (dwarf.x + 2))) //Check if rocks hit us
                {
                    livesCount--;
                    hitted = true;
                    if (livesCount < 0)
                    {
                        Console.Clear();
                        Console.Beep(625, 225);
                        PrintOnPosition(26, 14, "GAME OVER", ConsoleColor.Red);
                        Thread.Sleep(500);
                        PrintOnPosition(14, 16, "Do you want to play again? [y/n]", ConsoleColor.Red);
                        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                        while (Console.KeyAvailable) Console.ReadKey(true);
                        if (pressedKey.Key == ConsoleKey.Y)
                        {
                            score = 0U;
                            livesCount = 5;
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                    }
                    break;
                }
                if (newRock.y < Console.WindowHeight)
                {
                    newList.Add(newRock);
                }
                else
                {
                    score++;
                }
            }
            rocks = newList;

            //Clear the console
            Console.Clear();

            //Redraw playfield
            if (hitted)
            {
                Console.Beep(625, 225);
                rocks.Clear();
                PrintOnPosition(dwarf.x, dwarf.y, "(X)", ConsoleColor.DarkRed);
            }
            else
            {
                PrintOnPosition(dwarf.x, dwarf.y, dwarf.heroOutlook, dwarf.color);
            }
            foreach (Rocks rock in rocks)
            {
                PrintOnPositionChar(rock.x, rock.y, rock.fallingRock, rock.color);
            }
            //for (int i = 0; i < Console.WindowHeight; i++)
            //{
            //    PrintOnPositionChar(playfieldWith, i, '|', ConsoleColor.White);
            //}
            //Draw info
            PrintOnPosition(44, 12, "Lives: " + livesCount, ConsoleColor.DarkYellow);
            PrintOnPosition(44, 16, "Score: " + score, ConsoleColor.DarkYellow);

            //Slow down program 
            Thread.Sleep(150);
        }
    }
}
