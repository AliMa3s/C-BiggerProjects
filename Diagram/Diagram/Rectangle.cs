using System.Drawing;

namespace Domain {
    public class Rectangle {
        private int Top { get; set; }
        private int Left { get; set; }
        private int Width { get; set; }
        private int Height { get; set; }
        private Color Color { get; set; }
        private bool IsFilled { get; set; }

        public Rectangle(int left, int top, int width, int height, Color color, bool isFilled) {
            this.Top = top;
            this.Left = left;
            this.Width = width;
            this.Height = height;
            this.Color = color;
            this.IsFilled = isFilled;
        }

        public void Draw(Graphics g) {
            if (this.IsFilled) {
                Brush brush = new SolidBrush(this.Color);
                g.FillRectangle(brush, this.Left, this.Top, this.Width, this.Height);
            } else {
                Pen pen = new Pen(this.Color);
                g.DrawRectangle(pen, this.Left, this.Top, this.Width, this.Height);
            }
        }

    }
}
