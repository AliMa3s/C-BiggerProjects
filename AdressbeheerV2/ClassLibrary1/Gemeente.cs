using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1 {
    public class Gemeente {
        public string Naam { get; set; }

        public int NIScode { get; set; }

        public Gemeente(string naam, int nIScode) {
            Naam = naam;
            NIScode = nIScode;
        }
        public Gemeente() {

        }
        public override bool Equals(object obj) {
            return obj is Gemeente gemeente &&
                   Naam == gemeente.Naam &&
                   NIScode == gemeente.NIScode;
        }

        public override int GetHashCode() {
            return HashCode.Combine(Naam, NIScode);
        }

        public override string ToString() {
            return $"Niscode: {NIScode}, Gemeente: {Naam}";
        }
    }
}
