using System;
using System.Collections.Generic;
using System.Text;

namespace forTest {
    class Cirkel {
        private double straal;
        public void SetStraal(double straal) {
            this.straal = straal;
        }
        public double GetStraal() {
            return this.straal;
        }
        public double GetOmtrek() {
            return GetStraal() * System.Math.PI * 2;
        }
        public double GetOpp() {
            return GetStraal() * GetStraal() * System.Math.PI;
        }
    }
}
