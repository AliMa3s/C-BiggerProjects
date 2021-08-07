using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace xUnitTestAdressbeheer {
    public class UnitTestAdres {
        [Fact]
        public void Test_ctr_valid() {
            //arrange
            int id = 125;
            string huisnr = "258";
            string busnr = "255";
            string appnr = "358";
            string huisnrlabl = "544";
            int postcode = 9000;
            Straat straat = new Straat(45, " kerkstraat");
            AdresLocatie adr = new AdresLocatie(4564.2, 54464.2);

            //(int iD, string huisNummer, string busnummer, string appNummer, string huisNummerLabel,
            //    int postcode, Straat straat, AdresLocatie adreslocatie)
            //act
            Adres a = new Adres(id, huisnr, busnr, appnr, huisnrlabl, postcode, straat, adr);

            Assert.Equal(a.ID, id);
            Assert.Equal(a.HuisNummer, huisnr);
            Assert.Equal(a.Busnummer, busnr);
            Assert.Equal(a.AppNummer, appnr);
            Assert.Equal(a.HuisNummerLabel, huisnrlabl);
            Assert.Equal(a.Postcode, postcode);
            Assert.Equal(a.Straat, straat);
            Assert.Equal(a.Adreslocatie, adr);

        }

        [Fact]
        public void Test_ctr_Invalid() {
            //arrange
            int id = 123;
            string huisnr = "258";
            string busnr = "255";
            string appnr = "564";
            string huisnrlabl = null;
            int postcode = 9000;
            Straat straat = new Straat(654, " kerkstraat");
            AdresLocatie adr = new AdresLocatie(4564.2, 54464.2);

            //(int iD, string huisNummer, string busnummer, string appNummer, string huisNummerLabel,
            //    int postcode, Straat straat, AdresLocatie adreslocatie)
            //act
            Adres a = new Adres(id, huisnr, busnr, appnr, huisnrlabl, postcode, straat, adr);

            Assert.Equal(a.ID, id);
            Assert.Equal(a.HuisNummer, huisnr);
            Assert.Equal(a.Busnummer, busnr);
            Assert.Equal(a.AppNummer, appnr);
            Assert.Equal(a.HuisNummerLabel, huisnrlabl);
            Assert.Equal(a.Postcode, postcode);
            Assert.Equal(a.Straat, straat);
            Assert.Equal(a.Adreslocatie, adr);

        }
    }
}
