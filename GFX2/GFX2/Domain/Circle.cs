using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GFX2.Domain {
    public class Circle {
        public int CenterX { get; set; }
        public int CenterY { get; set; }
        public int Radius { get; set; }
        public Color Color { get; set; }
        public bool IsFilled { get; set; }

        public Circle(int centerX, int centerY, int radius, Color color, bool isFilled) {
            this.CenterX = centerX;
            this.CenterY = centerY;
            this.Radius = radius;
            this.Color = color;
            this.IsFilled = isFilled;
        }

        public void Draw(Graphics gfx) {
            int topLeftX = this.CenterX - this.Radius;
            int topLeftY = this.CenterY - this.Radius;
            int diameter = 2 * this.Radius;
            if (this.IsFilled) {
                Brush brush = new SolidBrush(this.Color);
                gfx.FillEllipse(brush, topLeftX, topLeftY, diameter, diameter);
            } else {
                Pen pen = new Pen(this.Color);
                gfx.DrawEllipse(pen, topLeftX, topLeftY, diameter, diameter);
            }
        }

    }
}
