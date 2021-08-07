using System;
using System.Collections.Generic;
using System.Text;

namespace forTest {
    class Counter {
        private int _waarde;
        public void SetWaarde(int value) {
            this._waarde = value;
        }
        public int GetWaarde() {
            return this._waarde;
        }
        private int _stapValue = 1;
        public void SetStap(int stapValue) {
            this._stapValue = stapValue;
        }
        public int GetStap() {
            return this._stapValue;
        }
        public void Advance() {
            this._waarde += this._stapValue;
        }
    }
}
