using System;
using System.Collections.Generic;
using System.Text;

namespace RekeningKantoor {
    class Persoon {
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public Adres Adres { get; set; }

        public Persoon(string voornaam, string familienaam, Adres adres) {
            Voornaam = voornaam;
            Familienaam = familienaam;
            Adres = adres;
        }
    }
}
