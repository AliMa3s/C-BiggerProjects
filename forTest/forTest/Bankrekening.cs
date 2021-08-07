using System;
using System.Collections.Generic;
using System.Text;

namespace forTest {
    class Bankrekening {
        private decimal _saldo;
        public void Stort(decimal bedrag) {
            this._saldo = this._saldo + bedrag;
        }
        public void HaalAf(decimal bedrag) {
            this._saldo = this._saldo - bedrag;

        }
        public decimal Saldo() {
            return this._saldo;
        }
        public void SchrijfOver(decimal bedrag, Bankrekening doelRekening) {
            this.HaalAf(bedrag);
            doelRekening.Stort(bedrag);
        }
    }
}
