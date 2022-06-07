using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            string connection = @"Data Source=tobeadded;Initial Catalog=SqlAdres;Integrated Security=True";
            DbProviderFactories.RegisterFactory("SqlAdres", SqlClientFactory.Instance);
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("SqlAdres");
            Bevraging bvgVoegen = new Bevraging(sqlFactory, connection);
            DataReader data = new DataReader();
            Bevraging bvg = new Bevraging(connection);
            //data.adressen = data.readFile();

            //Console.WriteLine("lengte gemeente " + data.gemeentes.Count);

            Processor p = new Processor(connection);
            //p.BulkGemeente(geemente);
            #region bulk

            //Console.WriteLine("Starting.... maken van adres");
            //p.BulkAdres(new List<Adres>(data.adressen.Values));
            ////p.BulkGemeente(data.gemeentes);
            //Console.WriteLine("Starting.... maken van straat");
            ////p.BulkStraten(new List<Adres>(data.straten.Values));
            //p.BulkStraten(new List<Straat>(data.straten.Values));

            //Console.WriteLine("Starting.... maken van gemeente");
            //p.BulkGemeente(new List<Gemeente>(data.gemeentes.Values));
            //Console.WriteLine("Starting.... maken van locatie");
            ////p.BulkAdresLocatie(new List<Adres>(data.adreslocatie.Values));
            //p.BulkAdresLocatie(new List<AdresLocatie>(data.adreslocatie.Values));
            //Console.WriteLine("End");

            #endregion bulk
            #region Selecteer adres,gem,straat
            //"SELECT * FROM dbo.adres WHERE Id=@Id and huisnummer=@huisnummer and busnummer=@busnummer and appartementnummer=@appartementnummer and" +
            //    " huisnummerlabel=@huisnummerlabel";
            Adres test = new Adres(13350215, "4AliA4", "43s2", "45d65", "68f54");
            //bvg.BestaatAdres(test);
            //Adres adres = bvg.SelecteerAdres(1000321072);
            //Console.WriteLine(adres);
            Gemeente gem = bvgVoegen.SelecteerGemeente(11022);
            Console.WriteLine(gem);
            Straat str = bvgVoegen.SelecteerStraat(1202);
            Console.WriteLine(str);
            Gemeente g = new Gemeente("Aartselaar", 11001);
            bvg.BestaatStraatnaam("Jef", g);
            bvg.BestaatGemeente(g);

            bvg.SelecteerGemeenten();

            //bvgVoegen.SelecteerAdressenInGemeente(1620);
            #endregion
            //bvg.SelecteerAdressenInGemeente(11022);
            //bvgVoegen.SelecteerStratenInGemeente(11001); //DONE
            //Adres a = new Adres(1000320925, "4", null, null, 456, "2-4");
            //bvg.BestaatAdres(a);
            //var straten = bvgVoegen.SelecteerStrateninGemeente("Gavere");
            //foreach (var straat in straten) {
            //    Console.WriteLine(straat);
            //}
            //var straten = bvgVoegen.SelecteerStratenInGemeente(11025);
            //foreach (var straat in straten) {
            //    Console.WriteLine(straat);
            //}
            //List<Adres> ad = bvg.SelecteerAdressInStraat(61983764);
            //foreach (var v in ad) {
            //    Console.WriteLine(v);
            //}

            #region UpdateTest
            /* UPDATE TEST
             29 Nijverheidsstraat 44020 //CHANGE Straatnaam and than check it with in managment
             select* from straat where id = '29';*/
            //Straat orgstraat = new Straat(29, "Nijverheidsstraat", 44020);
            //bvgVoegen.UpdateStraat(orgstraat);
            /* 11001 Aartselaar IN MANAGMENTSTUDIO select *from gemeente where NISCODE = '11001'; */
            //Gemeente orgsgeem = new Gemeente("Aartselaar", 11001);
            //bvgVoegen.UpdateGemeente(orgsgeem);
            /* 1000320925, 61960166,4, NULL, NULL, 2 - 4, 61960166, 1800))))
             Constructor is (id, huisnummer, busnummer, appnummer, huisnumlabel, postcode, straadid, adreslocatie
              in managment studio check select *from adres where id = '1000320925';
             here huisnum, appnum, busnum, huslabel is changed */
            //Adres orgsadres = new Adres(1000320925, "4Ali4", "45", "012", "2-4");
            //bvgVoegen.UpdateAdres(orgsadres);
            #endregion

            #region Verwijder adres,gem,straat
            /*select* from adres where id = '13354';*/
            //bvg.VerwijderAdres(13354);
            //bvg.VerwijderGemeente(43021);
            //bvg.VerwijderStraat(800000);
            #endregion


            #region VoegAdres,gem,straat





            /*Added in databank check in sql managmetn select* from adres where straatID = '61960166';*/
            //AdresLocatie asb = new AdresLocatie(1214, 101301.62, 190958.69);
            //bvgVoegen.VoegAdresToe(new Adres(13350215, 61968032, "4AliA4", "43s2", "45d65", "68f54", asb, 52));

            /*Added in gemeente select * from gemeente where niscode = 43021 */
            //Gemeente testgemeente = new Gemeente("GemeenteAli", 43021);
            //bvgVoegen.voegGemeenteToe(testgemeente);
            /* Check in databank select * from straat where straatnaame = 'AliLaan'; */
            //Straat teststraat = new Straat(800000, "AliLaan", 43021);
            //bvgVoegen.voegStraatToe(teststraat);
            #endregion

        }
    }
}
