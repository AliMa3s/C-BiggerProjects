using System.Collections.Generic;
using System.Drawing;

namespace Domain {
    public class Diagram {

        private List<Rectangle> Rectangles { get; set; }

        public Diagram() {
            this.Rectangles = new List<Rectangle>();
        }

        public void AddRectangle(Rectangle r) {
            // Rechthoek toevoegen aan de lijst
            // TODO : aanvullen
            this.Rectangles.Add(r);
        }

        public void DrawAll(Graphics gfx) {
            // Alle rechthoeken overlopen en van elke rechthoek de Draw method oproepen
            // TODO : aanvullen
            foreach(Rectangle r in Rectangles) {
                r.Draw(gfx);
            }
        }
    }
}
