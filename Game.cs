using System;
using System.Collections.Generic;
using System.Text;


namespace MyGame
{
    class Game
    {
        private World MyWorld;
        private Player CurrentPlayer;
        public void Start()
        {
            RunMainMenu();
        }
        public void RunMainMenu()
        {
            string title = @"██████████████████████████████████████████████
█───██───██─████─███─██────██────██────███───█
█─█████─███─████─███─██─██─██─██─██─██──██─███
█───███─███─████─█─█─██─██─██────██─██──██───█
█─█████─███─████─────██─██─██─█─███─██──████─█
█─████───██───███─█─███────██─█─███────███───█
██████████████████████████████████████████████";
            string[] items = { "New Game", "Info", "Exit" };
            Menu mainMenu = new Menu(title, items);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    RunGame();
                    break;
                case 1:
                    DisplayInfo();
                    break;
                case 2:
                    ExitGame();
                    break;

            }
        }
        private void ExitGame()
        {
            Console.Clear();
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey(true);
            Environment.Exit(0);
        }
        private void DisplayInfo()
        {
            Console.Clear();
            Console.WriteLine(@"Hellooooooooooo тут когда-нибудь что-нибудь будет.....
Разработка by Максим корпарейшн");
            Console.WriteLine("\nPress any key to return to the menu");
            Console.ReadKey(true);
            RunMainMenu();
        }
        private void RunGame()
        {
            Console.Clear();
            string[,] grid = {
                {"┌","─","┬ ","─","─","─","┬","─","─","─","┬","─","┐"},
                {"│"," ","│"," "," "," ","│"," "," "," ","│","X","│"},
                {"│"," ","│"," ","│"," ","│"," ","│"," ","│"," ","│"},
                {"│"," ","│"," ","│"," ","│"," ","│"," ","│"," ","│"},
                {"│"," ","│"," ","│"," ","│"," ","│"," ","│"," ","│"},
                {"│"," ","│"," ","│"," ","│"," ","│"," ","│"," ","│"},
                {"│"," ","│"," ","│"," ","│"," ","│"," ","│"," ","│"},
                {"│"," ","│"," ","│"," ","│"," ","│"," ","│"," ","│"},
                {"│"," "," "," ","│"," "," "," ","│"," "," "," ","│"},
                {"└","─","─","─","┴","─","─","─","┴","─","─","─","┘"},
            };
            MyWorld = new World(grid);
            CurrentPlayer = new Player(1, 1);

            RunGameLoop();
            Console.ReadKey(true);
            RunMainMenu();
        }
        private void DrawFrame()
        {
            Console.Clear();
            MyWorld.Draw();
            CurrentPlayer.Draw();

        }
        private void HandlePlayerInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch(key)
            {
                case ConsoleKey.UpArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.Y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X - 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X += 1;
                    }
                    break;
                default:
                    break;
            }
        }
        private void DisplayOutro()
        {
            Console.Clear();
            Console.WriteLine("YOU WOOOON!!!");
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(true);
            RunMainMenu();
        }
        private void RunGameLoop()
        {
            while(true)
            {
                DrawFrame();
                HandlePlayerInput();
                string elementAtPlayerPos = MyWorld.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if (elementAtPlayerPos == "X")
                {
                    break;
                }

                System.Threading.Thread.Sleep(20);
            }
            DisplayOutro();
        }
    }
}
