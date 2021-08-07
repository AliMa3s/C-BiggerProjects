using System;
using System.Collections.Generic;
using System.Text;

namespace RekeningKantoor {
    class Rekening {
        public string Nummer { get; set; }
        public double Saldo { get; set; }
        public Kantoor Kantoor { get; set; }
        public Persoon Titularis { get; set; }

        public Rekening(string nummer, double saldo, Kantoor kantoor, Persoon titularis) {
            Nummer = nummer;
            Saldo = saldo;
            Kantoor = kantoor;
            Titularis = titularis;
        }
    }
}
