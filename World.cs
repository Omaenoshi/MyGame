﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame
{
    class World
    {
        private static string[,] Grid;
        private static int Rows;
        private static int Cols;

        public World(string[,] grid)
        {
            Grid = grid;
            Rows = grid.GetLength(0);
            Cols = grid.GetLength(1);
        }
        public void Draw()
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Cols; x++)
                {
                    string element = Grid[y, x];
                    Console.SetCursorPosition(x, y);
                    Console.Write(element);
                }
            }
        }
        public string GetElementAt(int x, int y)
        {
            return Grid[y, x];
        }
        public bool IsPositionWalkable(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Cols || y >= Rows)
            {
                return false;
            }
            return Grid[y, x] == " " || Grid[y, x] == "X";
        }
    }
}
