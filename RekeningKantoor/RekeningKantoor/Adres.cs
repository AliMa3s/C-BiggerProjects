using System;
using System.Collections.Generic;
using System.Text;

namespace RekeningKantoor {
    class Adres {
        public string Straat { get; set; }
        public string Huisnummer { get; set; }
        public string Postcode { get; set; }
        public string Gemeente { get; set; }
        public Adres(string straat, string huisnummer, string postcode, string gemeente) {
            Straat = straat;
            Huisnummer = huisnummer;
            Postcode = postcode;
            Gemeente = gemeente;
        }
    }
}
