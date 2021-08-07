using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1 {
   public class Gemeente {
        
        public Gemeente(int niscode, string gemeentenaam) {
            this.NIScode = niscode;
            this.Naam = gemeentenaam;
        }
        public override string ToString() {
            return $"naam = {Naam}, code = {NIScode}\n";
        }

        

        public int NIScode { get;  set; }
        public string Naam { get;  set; }

    }
}
