using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame
{
    class Menu
    {
        private int SelectedIndex;
        private string[] Items;
        private string Title;

        public Menu(string title, string[] items )
        {
            Title = title;
            Items = items;
            SelectedIndex = 0;
        }
        public void DisplayOptions()
        {
            Console.WriteLine(Title);
            for (int i = 0; i < Items.Length; i++)
            {
                string currentOption = Items[i];
                string prefix;

                if (i == SelectedIndex)
                {
                    prefix = "*";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else
                {
                    prefix = " ";
                }
                Console.WriteLine($"{prefix}<<{currentOption}>>");
                Console.ResetColor();
            }
            
        }
        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow || keyPressed == ConsoleKey.W)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Items.Length - 1;
                    }

                }
                else if (keyPressed == ConsoleKey.DownArrow || keyPressed == ConsoleKey.S)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Items.Length)
                    {
                        SelectedIndex = 0;
                    }
                }    

            } while (keyPressed != ConsoleKey.Enter);
            return SelectedIndex;
        }
    }

}
