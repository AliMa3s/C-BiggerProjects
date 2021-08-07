using GFX2.Domain;
using System.Collections.Generic;
using System.Drawing;

namespace Domain {
    public class Diagram {
        private List<Rectangle> Rectangles { get; set; }
        private List<Circle> Circles { get; set; }

        public Diagram() {
            this.Rectangles = new List<Rectangle>();
            this.Circles = new List<Circle>();
        }

        public void AddRectangle(Rectangle r) {
            // Rechthoek toevoegen aan de lijst
            this.Rectangles.Add(r);
        }

        public void AddCircle(Circle c) {
            // Cirkel toevoegen aan de lijst
            this.Circles.Add(c);
        }


        public void DrawAll(Graphics gfx) {
            // Alle rechthoeken overlopen en van elke rechthoek de Draw method oproepen
            foreach (Rectangle r in Rectangles) {
                r.Draw(gfx);
            }

            // Alle cirkels overlopen en van elke cirkel de Draw method oproepen
            foreach (Circle c in Circles) {
                c.Draw(gfx);
            }
        }
    }
}
