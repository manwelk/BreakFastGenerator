﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenV0._1
{
    class ConsoleMenus
    {
        // code take from http://www.c-sharpcorner.com/uploadfile/b942f9/creating-a-console-listbox-in-C-Sharp/ thanks Vulpes

        public static int ChooseListBoxItem(string[] items, int ucol, int urow, ConsoleColor back, ConsoleColor fore)
        {
            int numItems = items.Length;
            int maxLength = items[0].Length;
            for (int i = 1; i < numItems; i++)
            {
                if (items[i].Length > maxLength)
                {
                    maxLength = items[i].Length;
                }
            }
            int[] rightSpaces = new int[numItems];
            for (int i = 0; i < numItems; i++)
            {
                rightSpaces[i] = maxLength - items[i].Length + 1;
            }
            int lcol = ucol + maxLength + 3;
            int lrow = urow + numItems + 1;
            WriteColorString(" " + items[0] + new string(' ', rightSpaces[0]), ucol + 1, urow + 1, fore, back);
            for (int i = 2; i <= numItems; i++)
            {
                WriteColorString(items[i - 1], ucol + 2, urow + i, back, fore);
            }
            ConsoleKeyInfo cki;
            char key;
            int choice = 1;

            while (true)
            {
                cki = Console.ReadKey(true);
                key = cki.KeyChar;
                if (key == '\r') // enter 
                {
                    return choice;
                }
                else if (cki.Key == ConsoleKey.DownArrow)
                {
                    WriteColorString(" " + items[choice - 1] + new string(' ', rightSpaces[choice - 1]), ucol + 1, urow + choice, back, fore);
                    if (choice < numItems)
                    {
                        choice++;
                    }
                    else
                    {
                        choice = 1;
                    }
                    WriteColorString(" " + items[choice - 1] + new string(' ', rightSpaces[choice - 1]), ucol + 1, urow + choice, fore, back);
                }
                else if (cki.Key == ConsoleKey.UpArrow)
                {
                    WriteColorString(" " + items[choice - 1] + new string(' ', rightSpaces[choice - 1]), ucol + 1, urow + choice, back, fore);
                    if (choice > 1)
                    {
                        choice--;
                    }
                    else
                    {
                        choice = numItems;
                    }
                    WriteColorString(" " + items[choice - 1] + new string(' ', rightSpaces[choice - 1]), ucol + 1, urow + choice, fore, back);
                }
            }

        }
        public static void WriteColorString(string s, int col, int row, ConsoleColor back, ConsoleColor fore)
        {
            SetColors(back, fore);
            // write string 
            Console.SetCursorPosition(col, row);
            Console.Write(s);
        }
        public static void SetColors(ConsoleColor back, ConsoleColor fore)
        {
            Console.BackgroundColor = back;
            Console.ForegroundColor = fore;
        }

    }
}
