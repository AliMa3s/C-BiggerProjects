using System;
using System.Threading;

namespace gamedevConsole {

    class Snake {
        int Height = 20;
        int width = 30;
        int[] X = new int[50];
        int[] Y = new int[50];

        int fruitX;
        int fruitY;

        int parts = 3;

        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        char key = 'W';
        Random rand = new Random();

        Snake() {
            X[0] = 5;
            Y[0] = 5;
            Console.CursorVisible = false;
            fruitX = rand.Next(2, (width - 2));
            fruitY = rand.Next(2, (Height - 2));
        }
        public void WriteBoard() {
            Console.Clear();
            for (int i = 1; i <= (width + 2); i++) {
                Console.SetCursorPosition(i, 1);
                Console.Write("-");
            }
            for (int i = 1; i <= (width + 2); i++) {
                Console.SetCursorPosition(i, (Height + 2));
                Console.Write("-");
            }
            for (int i = 1; i <= (Height + 1); i++) {
                Console.SetCursorPosition(1, i);
                Console.Write("|");
            }
            for (int i = 1; i <= (Height + 1); i++) {
                Console.SetCursorPosition((width + 2), i);
                Console.Write("|");
            }
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
            Console.Write("#");
        }
        public void apple(int x, int y) {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@");
        }

        public void Logic() {
            if (X[0] == fruitX) {
                if (Y[0] == fruitY) {
                    parts++;
                    fruitX = rand.Next(2, (width - 2));
                    fruitY = rand.Next(2, (Height - 2));
                }
            }
            for (int i = parts; i > 1; i--) {
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
                case 'd':
                    X[0]++;
                    break;
                case 'q':
                    X[0]--;
                    break;
            }
            
            for (int i = 0; i <= (parts - 1); i++) {
                WritePoint(X[i], Y[i]);
                apple(fruitX, fruitY);
            }
            Thread.Sleep(100);
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
}
