using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Maze {
    class Game {
        private World MyWorld;
        private Player CurrentPlayer;
        public void Start() {
            Title = "Welkom in the Maze!";
            CursorVisible = false;
            //SetCursorPosition(4, 2);
            //Write("X");
            string[,] grid = LevelParser.ParseFileToArray("Level1.txt");
            //String[,] grid = {
            //    {"█", "█","█","█","█","█","█"},
            //    {"█", " ","█"," "," "," ","X"},
            //    {" ", " ","█"," ","█"," ","█"},
            //    {"█", " ","█"," ","█"," ","█"},
            //    {"█", " "," "," ","█"," ","█"},
            //    {"█", "█","█","█","█","█","█"},
                
            //};

            MyWorld = new World(grid);

            CurrentPlayer = new Player(1, 2);
            

            //WriteLine($"\n\n  Toets iets om te sluiten...");
            ReadKey(true);

            RunGameLoop();
        }

        private void DisplayIntro() {
            WriteLine("Welkom in de maze!");
            WriteLine("Instructies");
            WriteLine("> Gebruik de Arrow keys om te verplaatsen");
            WriteLine("> Probeer dit te behalen: ");
            ForegroundColor = ConsoleColor.Green;
            WriteLine("X");
            ResetColor();
            WriteLine("Toets iets om te starten");
            ReadKey(true);
        }

        private void DisplayOutro() {
            Clear();
            WriteLine("Je hebt de doel beriekt");
            WriteLine("Dank je om te spelen");
            WriteLine("Toets iets om te sluiten");
            ReadKey(true);
        }
        private void DrawFrame() {
            Clear();
            MyWorld.Draw();
            CurrentPlayer.Draw();
        }

        private void HandlePlayerInput() {

            ConsoleKey key;
            do {
                ConsoleKeyInfo keyInfo = ReadKey(true);
                key = keyInfo.Key;
            } while (KeyAvailable);
            
                switch (key) {
                case ConsoleKey.UpArrow:
                    if(MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1)) {
                        CurrentPlayer.Y -= 1;
                    }
                    
                    break;
                case ConsoleKey.DownArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1)) {
                        CurrentPlayer.Y += 1;
                    }
                    
                    break;
                case ConsoleKey.LeftArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X - 1, CurrentPlayer.Y )) {
                        CurrentPlayer.X -= 1;
                    }
                    
                    break;
                case ConsoleKey.RightArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y)) {
                        CurrentPlayer.X += 1;
                    }
                    
                    break;
                default:
                    break;
            }
        }
        private void RunGameLoop() {
            DisplayIntro();
            while (true) {
                //Draw everything
                DrawFrame();

                //Check player input
                HandlePlayerInput();


                //Check if player reached Exit
                string elementAtPlayerPos = MyWorld.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if(elementAtPlayerPos == "X") {
                    break;
                }
                //Give the console chance to render
                System.Threading.Thread.Sleep(20);
            }
            DisplayOutro();
        }
    }
}
