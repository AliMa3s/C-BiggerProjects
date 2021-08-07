using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using Domain;

namespace UI {
    class DiagramControl : Control {
        private Diagram Diagram { get; set; }

        public DiagramControl(Diagram diagram) {
            // stel in dat deze control zichzelf zal hertekenen igv resize
            this.ResizeRedraw = true;

            // stel de achtergrondkleur in op lichtgrijs
            this.BackColor = Color.White;

            // stel het diagram in dat deze control zal visualiseren
            this.Diagram = diagram;
        }

        // DEZE METHOD WORDT OPGEROEPEN TELKENS DE CONTROL MOET HERTEKEND WORDEN
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            // merk op dat Console.WriteLine niet werkt in een GUI applicatie (bij gebrek aan console venster)
            System.Diagnostics.Debug.WriteLine("onPaint opgeroepen");

            Graphics gfx = e.Graphics;

            // zorg dat er mooi kan getekend worden (anti-aliasing e.d.)
            gfx.PixelOffsetMode = PixelOffsetMode.Half;
            gfx.SmoothingMode = SmoothingMode.HighQuality;

            // de breedte en hoogte van deze control kun je
            // achterhalen met this.Width en this.Height

            // HIERONDER PLAATS JE JE EIGEN CODE OM TE TEKENEN

            this.Diagram.DrawAll(gfx);
        }
    }
}