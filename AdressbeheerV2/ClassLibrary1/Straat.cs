using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1 {
    public class Straat {

        public int Id { get; set; }

        public string Naam { get; set; }

        public int NISCODE { get; set; } //bestaat al in gemeente



        public Straat(int id, string naam) {
            Id = id;
            Naam = naam;
        }

        public override bool Equals(object obj) {
            return obj is Straat straat &&
                   Id == straat.Id &&
                   Naam == straat.Naam &&
                   NISCODE == straat.NISCODE;
        }
        public Gemeente Gemeente { get; set; }

        public Straat(int id, string naam, Gemeente gemeente) {
            Id = id;
            Naam = naam;
            Gemeente = gemeente;
        }
        public Straat() {

        }

        public override int GetHashCode() {
            return HashCode.Combine(Id, Naam, NISCODE);
        }

        public override string ToString() {
            return $"Id: {Id} straatnaam: {Naam} GemeenteNaam: {Gemeente.Naam}";
        }

        public Straat(int id, string naam, int nISCODE) {
            Id = id;
            Naam = naam;
            NISCODE = nISCODE;

        }
    }
}
