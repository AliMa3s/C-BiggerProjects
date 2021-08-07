﻿using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Maze {
    class Player {
        public int X { get; set; }
        public int Y { get; set; }
        private String PlayerMarker;
        private ConsoleColor PlayerColor;

        public Player(int initialX, int initialY) {
            X = initialX;
            Y = initialY;

            PlayerMarker = "0";
            PlayerColor = ConsoleColor.Red;
        }
        public void Draw() {
            ForegroundColor = PlayerColor;
            SetCursorPosition(X, Y);
            Write(PlayerMarker);
            ResetColor();
        }
    }
}
