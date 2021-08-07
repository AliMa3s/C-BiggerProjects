using System;
using System.Collections.Generic;
using System.Text;

namespace forTest {
    class Artikel {
        private decimal pijsExclBtw;
        public void SetpriceExclBtw(decimal value) {
            this.pijsExclBtw = value;

        }
        public decimal GetpriceExclBtw() {
            return this.pijsExclBtw;
        }
        private decimal procentBtw = 21m;
        public void SetProcentBtw(decimal value) {
            procentBtw = value;
        }
        public decimal GetProcentBtw() {
            return this.procentBtw;
        }
        public decimal prijsIncBtw() {
            return GetpriceExclBtw() * ((GetProcentBtw() / 100) + 1);
        }
    }
}
