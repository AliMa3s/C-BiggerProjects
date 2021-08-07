using System;
using System.Collections.Generic;
using System.Text;

namespace forTest {
    class Uitlening {
        private string _omschrijving;
        public void SetOmschrijving(string omschrijving) {
            this._omschrijving = omschrijving;
        }
        public string GetOmschrijving() {
            return this._omschrijving;
        }

        private DateTime _ontleenDatum;
            public void SetOntleendatum(DateTime datum) {
            this._ontleenDatum = datum;
        }
        public DateTime GetOntleendatum() {
            return this._ontleenDatum;
        }

        public DateTime GetUitersteInleverdatum() {
            return GetOntleendatum().AddDays(14);
        }
    }
}
