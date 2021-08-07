using System;
using System.Collections.Generic;


namespace Testing {
    class Snake {

        int Height = 20;
        int Width = 30;
        int[] X = new int[50];
        int[] Y = new int[50];

        int fruitX;
        int fruitY;

        int parts = 3;

        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        char key = 'Z';

        Random rand = new Random();

        Snake() {
            X[0] = 5;
            Y[0] = 5;
            Console.CursorVisible = false;
            fruitX = rand.Next(2, (Width - 2));
            fruitY = rand.Next(2, (Height - 2));
        }

        public void WriteBoard() {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 1; i <=(Width+2); i++) {
                Console.SetCursorPosition(i, 1);
                Console.WriteLine("-");
            }
            for (int i = 1; i <= (Width + 2); i++) {
                Console.SetCursorPosition(i, Height+2);
                Console.WriteLine("-");
            }
            for (int i = 1; i <= (Height + 1); i++) {
                Console.SetCursorPosition(1, i);
                Console.WriteLine("|");
            }
            for (int i = 1; i <= (Height + 1); i++) {
                Console.SetCursorPosition((Width+2),i);
                Console.WriteLine("|");
            }
            Console.ResetColor();
        }
        public void Input() {
            if (Console.KeyAvailable) {
                keyInfo = Console.ReadKey(true);
                key = keyInfo.KeyChar;
            }
        }
        public void WritePoint(int x, int y) {
            Console.SetCursorPosition(x, y);
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("*");
            Console.ResetColor();
        }
        public void Logic() {
            if (X[0] == fruitX) {
                if (Y[0] == fruitY) {
                    parts++;
                    fruitX = rand.Next(2, (Width - 2));
                    fruitY = rand.Next(2, (Height - 2));
                    
                }
            }
            for (int i = parts; i >1; i--) {
                X[i - 1] = X[i - 2];
                Y[i - 1] = Y[i - 2];
            }
            switch (key) {
                case 'z':
                    Y[0]--;
                    break;
                case 's':
                    Y[0]++;
                    break;
                case 'q':
                    X[0]--;
                    break;
                case 'd':
                    X[0]++;
                    break;
            }
            for (int i = 0; i <=(parts-1); i++) {
                WritePoint(X[i],Y[i]);
                WritePoint(fruitX, fruitY);

            }
            System.Threading.Thread.Sleep(100);
        }


        static void Main(string[] args) {
            Snake snake = new Snake();
            while (true) { 
            snake.WriteBoard();
            snake.Input();
            snake.Logic();
            }
            Console.ReadKey();
            
        }
    }


    internal class ConsoleKeyINfo {
        public ConsoleKeyINfo() {
        }
    }
}
