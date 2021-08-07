using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1 {
    public interface IAdresBeheerder {
        public bool BestaatAdres(Adres adres);
        public bool BestaatGemeente(Gemeente gemeente);
        public bool BestaatStraatnaam(string straatnaam, Gemeente gemeente);
        public Adres SelecteerAdres(int id);
        public List<Adres> SelecteerAdressenInGemeente(int Niscode);
        public List<Adres> SelecteerAdressInStraat(int straadID);
        public Gemeente SelecteerGemeente(int Niscode);
        public IList<Gemeente> SelecteerGemeenten();
        public Straat SelecteerStraat(int id);
        public List<Straat> SelecteerStratenInGemeente(int Niscode);
        public List<Straat> SelecteerStratenInGemeente(string gemeentenaam);
        public void UpdateAdres(Adres adres);
        public void UpdateGemeente(Gemeente gemeente);
        public void UpdateStraat(Straat straat);
        public void VerwijderAdres(int id);
        public void VerwijderGemeente(int Niscode);
        public void VerwijderStraat(int id);
        public void VoegAdresToe(Adres adres);
        public void VoegGemeenteToe(Gemeente gemeente);
        public void VoegStraatToe(Straat straat);

    }
}
