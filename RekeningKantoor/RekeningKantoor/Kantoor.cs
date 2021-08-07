using System;
using System.Collections.Generic;
using System.Text;

namespace RekeningKantoor {
    class Kantoor {
        public Persoon Kantoorhouder { get; set; }
        public Adres Adres { get; set; }

        public Kantoor(Persoon kantoorhouder, Adres adres) {
            Kantoorhouder = kantoorhouder;
            Adres = adres;
        }
    }
}
