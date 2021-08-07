using System;
using System.Collections.Generic;
using System.Text;

namespace forTest {
    class rechthoek {
        private double hoogte;
        public void SetHoogte(double value) {
            this.hoogte = value;
        }
        public double GetHoogte() {
            return this.hoogte;
        }
        private double breedte;
        public void SetBreedte(double value) {
            this.breedte = value;
        }
        public double GetBreedte() {
            return this.breedte;
        }
        public double Oppervlakte() {
            return GetHoogte() * GetBreedte();
        }
    }
}
