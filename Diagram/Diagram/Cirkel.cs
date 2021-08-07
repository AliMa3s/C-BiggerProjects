using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Diagram.Domain {
    class Cirkel {
        public int CenterX { get; set; }
        public int CenterY { get; set; }
        public int Radius { get; set; }
        public Color Color { get; set; }
        public bool isFilled { get; set; }

        public Cirkel(int centerX, int ccenterY, int radius, Color color, bool isFilled) {
            this.CenterX = centerX;
            this.CenterY = CenterY;
            this.Radius = radius;
            this.Color = color;
            this.isFilled = isFilled;

        }
        public void Draw(Graphics gfx) {
            int topLeftX = this.CenterX - this.Radius;
            int topLeftY = this.CenterY - this.Radius;
            int diameter = 2 * this.Radius;
            if (this.isFilled) {
                Brush brush = new SolidBrush(this.Color);
                gfx.FillEllipse(brush, topLeftX, topLeftY, diameter, diameter);
            } else {
                Pen pen = new Pen(this.Color);
                gfx.DrawEllipse(pen, topLeftX, topLeftY, diameter, diameter);
            }
        }
    }
}
