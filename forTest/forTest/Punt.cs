using System;
using System.Collections.Generic;
using System.Text;

namespace forTest {
    class Punt {
        private double _x;
        public void SetX(double x) {
            this._x = x;
        }
        public double GetX() {
            return this._x;
        }
        private double _y;
        public void SetY(double y) {
            this._y = y;
        }
        public double GetY() {
            return this._y;
        }
        public static double GetAfstandTussen(Punt punt1, Punt punt2) {
            double x1 = punt1.GetX();
            double x2 = punt2.GetX();
            double y1 = punt1.GetY();
            double y2 = punt2.GetY();
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }
    }
}
