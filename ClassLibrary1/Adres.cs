using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1 {
    public class Adres {
        public int ID { get; set; }
        public int StraatId { get; set; }
        public Straatnaam straatnaam { get; set; }
        public string AppNummer { get; set; }
        public string Busnummer { get; set; }
        public string HuisNummer { get; set; }
        public string HuisNummerLabel { get; set; }
        public AdresLocatie AdreslocatieId { get; set; }
        public int Postcode { get; set; }


        public Adres(int iD, Straatnaam straatnaam, string appartementnummer, string busnummer, string huisnummer, string huisnummerLabel,
        AdresLocatie locatie, int straatId, int postcode) {
            this.ID = iD;
            this.straatnaam = straatnaam;
            this.AppNummer = appartementnummer;
            this.Busnummer = busnummer;
            this.HuisNummer = huisnummer;
            this.HuisNummerLabel = huisnummerLabel;
            this.AdreslocatieId = locatie;
            this.StraatId = straatId;
            this.Postcode = postcode;

        }



        public override string ToString() {
            return $"{straatnaam}locatie = [{AdreslocatieId}], ID = {ID}, appartementnummer = {AppNummer}," +
                $"busnummer = {Busnummer}, huisnummer = {HuisNummer}, huisnummerlabel = {HuisNummerLabel}";
        }
    }
}
