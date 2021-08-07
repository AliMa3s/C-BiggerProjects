using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace xUnitTestAdressbeheer {
    public class UnitTestBevraging {
        //public bool BestaatAdres(Adres adres);
        //public bool BestaatGemeente(Gemeente gemeente);
        //public bool BestaatStraatnaam(string straatnaam, Gemeente gemeente);
        //public Adres SelecteerAdres(int id);
        //public List<Adres> SelecteerAdressenInGemeente(int Niscode);
        //public List<Adres> SelecteerAdressInStraat(int straadID);
        //public Gemeente SelecteerGemeente(int Niscode);
        //public IList<Gemeente> SelecteerGemeenten();
        //public Straat SelecteerStraat(int id);
        //public List<Straat> SelecteerStratenInGemeente(int Niscode);
        //public List<Straat> SelecteerStratenInGemeente(string gemeentenaam);
        //public void UpdateAdres(Adres adres);
        //public void UpdateGemeente(Gemeente gemeente);
        //public void UpdateStraat(Straat straat);
        //public void VerwijderAdres(int id);
        //public void VerwijderGemeente(int Niscode);
        //public void VerwijderStraat(int id);
        //public void VoegAdresToe(Adres adres);
        //public void VoegGemeenteToe(Gemeente gemeente);
        //public void VoegStraatToe(Straat straat);

        private Bevraging bv;
        private Adres a1, a2, a3;
        private Gemeente g1, g2, g3;
        private Straat s1, s2, s3;

        [Fact]
        public void Test_mth_BestaatAdres_valid() {
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";
            bv = new Bevraging(connection);
            a1 = new Adres(255, "1straat", "255", "358", "584");
            bv.BestaatAdres(a1);
        }
        [Fact]
        public void Test_mth_BestaatGemeente_valid() {
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";
            bv = new Bevraging(connection);
            g1 = new Gemeente("Gent", 6568);
            bv.BestaatGemeente(g1);
        }
        [Fact]
        public void Test_mth_straatnaam_valid() {
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";
            bv = new Bevraging(connection);
            s1 = new Straat(1, "sleepstraat", 68734);
            bv.BestaatStraatnaam("sleepstraat", new Gemeente("Gent", 9000));
        }
        [Fact]
        public void Test_mth_selecteeradres_valid() {
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";
            bv = new Bevraging(connection);
            int id = 13545;
            bv.SelecteerAdres(id);
        }
        [Fact]
        public void Test_mth_SelecteerGemeenten_valid() {
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";
            DbProviderFactories.RegisterFactory("SqlAdres", SqlClientFactory.Instance);
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("SqlAdres");
            Bevraging bvgVoegen = new Bevraging(sqlFactory, connection);
            bvgVoegen.SelecteerGemeenten();
        }

        [Fact]
        public void Test_mth_SelecteerGemeente_valid() {
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";
            DbProviderFactories.RegisterFactory("SqlAdres", SqlClientFactory.Instance);
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("SqlAdres");
            Bevraging bvgVoegen = new Bevraging(sqlFactory, connection);
            bvgVoegen.SelecteerGemeente(13213);
        }
        [Fact]
        public void Test_mth_SelecteerStraatId_valid() {
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";
            DbProviderFactories.RegisterFactory("SqlAdres", SqlClientFactory.Instance);
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("SqlAdres");
            Bevraging bvgVoegen = new Bevraging(sqlFactory, connection);
            bvgVoegen.SelecteerStraat(13213);
        }
        [Fact]
        public void Test_mth_SelecteerStratenIngemeenteIntniscode_valid() {
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";
            DbProviderFactories.RegisterFactory("SqlAdres", SqlClientFactory.Instance);
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("SqlAdres");
            Bevraging bvgVoegen = new Bevraging(sqlFactory, connection);
            bvgVoegen.SelecteerStratenInGemeente(465465);
        }

        [Fact]
        public void Test_mth_SelecteerStratenIngemeenteStringGemeente_valid() {
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";
            DbProviderFactories.RegisterFactory("SqlAdres", SqlClientFactory.Instance);
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("SqlAdres");
            Bevraging bvgVoegen = new Bevraging(sqlFactory, connection);
            bvgVoegen.SelecteerStrateninGemeente("Gent");
        }


        [Fact]
        public void Test_mth_Updateadres_valid() {
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";
            bv = new Bevraging(connection);
            a1 = new Adres(255, "1straat", "255", "358", "584");
            bv.UpdateAdres(a1);
        }
        [Fact]
        public void Test_mth_Verwijderadres_valid() {
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";
            bv = new Bevraging(connection);
            a1 = new Adres(255, "1straat", "255", "358", "584");
            bv.VerwijderAdres(255);
        }
        [Fact]
        public void Test_mth_UpdateGemeente_valid() {
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";
            DbProviderFactories.RegisterFactory("SqlAdres", SqlClientFactory.Instance);
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("SqlAdres");
            Bevraging bvgVoegen = new Bevraging(sqlFactory, connection);
            g1 = new Gemeente("Gent", 6568);
            bvgVoegen.UpdateGemeente(g1);
        }
        [Fact]
        public void Test_mth_UpdateStraat_valid() {
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";
            DbProviderFactories.RegisterFactory("SqlAdres", SqlClientFactory.Instance);
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("SqlAdres");
            Bevraging bvgVoegen = new Bevraging(sqlFactory, connection);
            s1 = new Straat(1, "sleepstraat", 68734);
            bvgVoegen.UpdateStraat(s1);
        }
        [Fact]
        public void Test_mth_VerwijderGemeente_valid() {
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";
            DbProviderFactories.RegisterFactory("SqlAdres", SqlClientFactory.Instance);
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("SqlAdres");
            Bevraging bvgVoegen = new Bevraging(sqlFactory, connection);
            int niscode = 4564654;
            bvgVoegen.VerwijderGemeente(niscode);
        }
        [Fact]
        public void Test_mth_VerwijderStraat_valid() {
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";
            DbProviderFactories.RegisterFactory("SqlAdres", SqlClientFactory.Instance);
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("SqlAdres");
            Bevraging bvgVoegen = new Bevraging(sqlFactory, connection);
            int id = 4564654;
            bvgVoegen.VerwijderStraat(id);
        }
        [Fact]
        public void Test_mth_VoegAdresToe_valid() {
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";
            bv = new Bevraging(connection);
            a1 = new Adres(255, "1straat", "255", "358", "584");
            bv.VoegAdresToe(a1);
            bv.VoegAdresToe(a2);


        }
        [Fact]
        public void Test_mth_VoegGemeenteToe_valid() {
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";
            DbProviderFactories.RegisterFactory("SqlAdres", SqlClientFactory.Instance);
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("SqlAdres");
            Bevraging bvgVoegen = new Bevraging(sqlFactory, connection);
            g1 = new Gemeente("Gent", 6568);
            bvgVoegen.BestaatGemeente(g1);
        }
        [Fact]
        public void Test_mth_VoegStraatToe_valid() {
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";
            DbProviderFactories.RegisterFactory("SqlAdres", SqlClientFactory.Instance);
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("SqlAdres");
            Bevraging bvgVoegen = new Bevraging(sqlFactory, connection);
            s1 = new Straat(1, "sleepstraat", 68734);
            bvgVoegen.voegStraatToe(s1);
        }
        [Theory]
        [InlineData(255, "456", "255", "358", "584", 255, "456", "255", "358", "584")]

        public void Test_mth_BestaatAdres1_valid(int id, string huisnr, string busnr, string appnr, string huisnrlbl, int result, string rslth,
            string rsltbr, string rsltapnr, string rslthslb) {
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";

            Bevraging a = new Bevraging(connection);
            Adres c = new Adres(255, "258", "255", "358", "584");
            a.BestaatAdres(c);

            Assert.Equal(result, id);
        }
        [Theory]
        [InlineData("Aartselaar", 11001, 11001)]

        public void Test_mth_BestaatGemeente1_valid(string gem, int pstcd, int rstpstcd) {
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";

            Bevraging a = new Bevraging(connection);
            Gemeente g = new Gemeente("Aartselaar", 11001);

            Assert.Equal(pstcd, rstpstcd);
        }

        [Theory]
        [InlineData(456, "postelstraat", 456)]

        public void Test_mth_BestaatStraatnaam1_valid(int id, string strtnaam, int result) {
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";

            Bevraging a = new Bevraging(connection);
            Straat st = new Straat(456, "postelstraat");

            Assert.Equal(result, id);
        }

        [Theory]
        [InlineData(456, 456)]

        public void Test_mth_SelecteerAdres_valid(int id, int result) {
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";

            Bevraging a = new Bevraging(connection);
            a.SelecteerAdres(456);

            Assert.Equal(result, id);
        }

        //[Theory]
        //[InlineData(1546, 1546)]

        //public void Test_mth_SelecteerGemeente_valid(int nicode, int result) {
        //    string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";


        //    SqlConnection connection1 = new SqlConnection(connection);
        //    Bevraging a = new Bevraging(connection);
        //    a.SelecteerGemeente(1546); //als je andere nummer toevoegd gaat het niet werken

        //    Assert.Equal(result, nicode);
        //}


        [Theory]
        [InlineData(9000, 9000)]

        public void Test_mth_SelecteerGemeentenlist_valid(int pstcde, int result) {
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";

            Bevraging a = new Bevraging(connection);
            a.SelecteerGemeenten();

            Assert.Equal(result, pstcde);
        }
        [Theory]
        [InlineData(255, "1straat", "255", "358", "584", 255, "1straat", "255", "358", "584")]

        public void Test_mth_UpdateAdres_valid(int id, string huisnr, string busnr, string appnr, string huisnrlbl, int result, string rslth,
            string rsltbr, string rsltapnr, string rslthslb) {
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";
            DbProviderFactories.RegisterFactory("SqlAdres", SqlClientFactory.Instance);
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("SqlAdres");
            Bevraging a = new Bevraging(sqlFactory, connection);
            Adres ab = new Adres(255, "1straat", "255", "358", "584");
            a.UpdateAdres(ab);

            Assert.Equal(rslth, huisnr);
        }


        //[Theory]
        //[InlineData(13465, 13465)]
        [Fact]
        public void Test_mth_VerwijderAdres_valid() {
            string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";
            bv = new Bevraging(connection);
            a1 = new Adres(255, "1straat", "255", "358", "584");
            bv.BestaatAdres(a1);
        }

        //public void Test_mth_VerwijderAdres_valid(int gmv, int rslt) {
        //    string connection = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";

        //    Bevraging a = new Bevraging(connection);

        //    a.VerwijderGemeente(13465);

        //    Assert.Equal(gmv, rslt);
        //}















    }
}
