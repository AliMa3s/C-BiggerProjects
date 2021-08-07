using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1 {
    public class Adres {
        public Adres(int iD, string huisNummer, string busnummer, string appNummer, string huisNummerLabel, int postcode, Straat straat, AdresLocatie adreslocatie) {
            ID = iD;
            Straat = straat;
            HuisNummer = huisNummer;
            Busnummer = busnummer;
            AppNummer = appNummer;
            HuisNummerLabel = huisNummerLabel;
            Adreslocatie = adreslocatie;
            Postcode = postcode;
        }
        public Adres(int iD, string huisNummer,/* string busnummer, string appNummer,*/ string huisNummerLabel, int postcode, Straat straat, AdresLocatie adreslocatie) {
            ID = iD;
            Straat = straat;
            HuisNummer = huisNummer;
            //Busnummer = busnummer;
            //AppNummer = appNummer;
            HuisNummerLabel = huisNummerLabel;
            Adreslocatie = adreslocatie;
            Postcode = postcode;
        }


        public Adres(string huisNummer, string busnummer, string appNummer, string huisNummerLabel, Straat straat, AdresLocatie adreslocatie, int postcode) {
            Straat = straat;
            HuisNummer = huisNummer;
            Busnummer = busnummer;
            AppNummer = appNummer;
            HuisNummerLabel = huisNummerLabel;
            Adreslocatie = adreslocatie;
            Postcode = postcode;
        }

        public Adres(int iD, Straat straat, string huisNummer, AdresLocatie adreslocatie) {
            ID = iD;
            Straat = straat;
            HuisNummer = huisNummer;
            Adreslocatie = adreslocatie;
        }

        public int ID { get; set; }
        public Gemeente Gemeente { get; set; }//moet uit
        public Straat Straat { get; set; }

        private string _huisnummer;
        public string HuisNummer {
            get => _huisnummer;
            set {
                if (!string.IsNullOrEmpty(value)) {
                    if (char.IsDigit(value[0])) {
                        _huisnummer = value.Trim();
                    } else throw new HuisnummerException("Het huisnummer moet beginenn met een cijfer!");
                } else throw new HuisnummerException("Het huisnummer moet niet leeg zijn!");
            }
        }

        public string Busnummer { get; set; }

        public string AppNummer { get; set; }

        public string HuisNummerLabel { get; set; }

        public AdresLocatie Adreslocatie { get; set; }

        public int Postcode { get; set; }



        public override bool Equals(object obj) {
            return obj is Adres adres &&
                   ID == adres.ID &&
                   EqualityComparer<Straat>.Default.Equals(Straat, adres.Straat) &&
                   HuisNummer == adres.HuisNummer &&
                   Busnummer == adres.Busnummer &&
                   AppNummer == adres.AppNummer &&
                   HuisNummerLabel == adres.HuisNummerLabel &&
                   EqualityComparer<AdresLocatie>.Default.Equals(Adreslocatie, adres.Adreslocatie) &&
                   Postcode == adres.Postcode;
        }
        public Adres() {

        }
        public Adres(int id, int straatID, string huisnummer, string appartementnummer, string busnummer, string huisnummerlabel, int postcode, double d1, double d2) {
            ID = id;
            StraatID = straatID;
            HuisNummer = huisnummer;
            AppNummer = appartementnummer;
            Busnummer = busnummer;

            HuisNummerLabel = huisnummerlabel;
            Postcode = postcode;
            Locatie.X = d1;
            Locatie.Y = d2;
        }
        //Voor voeg methodes
        public AdresLocatie Locatie { get; set; }
        public int StraatID { get; set; }
        public double adreslocatieD { get; set; }
        public Adres(int id, string huisNummer, string busnummer, string appNummer, string huisNummerLabel) {
            ID = id;
            HuisNummer = huisNummer;
            AppNummer = appNummer;
            Busnummer = busnummer;
            HuisNummerLabel = huisNummerLabel;

        }

        public Adres(int iD, int straatID, string huisNummer, string busnummer, string appNummer, string huisNummerLabel, AdresLocatie adreslocatie, int postcode) {
            ID = iD;
            StraatID = straatID;
            HuisNummer = huisNummer;
            Busnummer = busnummer;
            AppNummer = appNummer;
            HuisNummerLabel = huisNummerLabel;
            Adreslocatie = adreslocatie;
            Postcode = postcode;
        }

        public Adres(int iD, string huisNummer, string busnummer, string appartementnummer, string huisNummerLabel, int v) {
            ID = iD;
            HuisNummer = huisNummer;
            HuisNummerLabel = huisNummerLabel;
        }

        public override int GetHashCode() {
            return HashCode.Combine(ID, Straat, HuisNummer, Busnummer, AppNummer, HuisNummerLabel, Adreslocatie, Postcode);
        }


        public override string ToString() {
            return $"id: {ID}, appnr: {AppNummer}, busnr: {Busnummer}, huisnr: {HuisNummer}, huisnrLabel: {HuisNummerLabel}, locatieid : {Adreslocatie.Id}, straatnaam: {Straat.Naam}";
        }

    }
}
