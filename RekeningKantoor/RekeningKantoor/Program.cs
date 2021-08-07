using System;

namespace RekeningKantoor {
    class Program {
        static void Main(string[] args) {

            Adres adresJan = new Adres("Koekstraat", "70", "9090", "Melle");
            Persoon jan = new Persoon("Jan", "Janssens", adresJan);

            Adres adresMieke = new Adres("kerkstraat", "99", "8000", "Antwerpen");
            Persoon mieke = new Persoon("Mieke", "Mickelson", adresMieke);
            mieke.Adres.Huisnummer = "55";
            Kantoor kantorMieke = new Kantoor(mieke, adresMieke);
            Console.WriteLine(mieke.Adres.Huisnummer);
            
            Rekening rekeningJan = new Rekening("Be22 4444 5555 6666", 130, kantorMieke, jan);


        }
    }
}
