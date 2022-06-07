using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            DbProviderFactories.RegisterFactory("sqlServer", SqlClientFactory.Instance);
            string connectionString = @"Data Source=Tobeadded;Initial Catalog=SqlAdres;Integrated Security=True";
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("sqlServer");
            HashSet<Gemeente> gemeente = new HashSet<Gemeente>();
            gemeente.Add(new Gemeente(10000, "tienduizend"));
            gemeente.Add(new Gemeente(20000, "twentigduizend"));

            string link = @"D:\Hogent\Test\CRAB_Adressenlijst_GML\GML\CrabAdr.gml";
            DataReader dr = new DataReader(connectionString);
            dr.BulkGemeente(gemeente);
            //DataReader dr = new DataReader(connectionString);
            //Console.WriteLine("starting....");
            // //dr.readFile();
            //DataReader sql = new DataReader(connectionString);
            //Console.WriteLine("Lengte adres" + dr.adres.Count());
            //sql.BulkAdres(dr.adres);
            //Console.WriteLine("Lengte gemeente" + dr.gemeentes.Count());
            //sql.BulkGemeente(dr.gemeentes);
            //Console.WriteLine("Lengte straten" + dr.straten.Count());
            //sql.BulkStraten(dr.straten);
            //Console.WriteLine("Lengte adreslocatie" + dr.adreslocatie.Count());
            //sql.BulkAdresLocatie(dr.adreslocatie);
           

            //Console.WriteLine("Finished....");
            //dr.BulkGemeente(link);
            //adresbeheer.readFile();
            //Console.WriteLine("Bezig.....");
            //adresbeheer.BulkGemeente();
            //adresbeheer.AddGMLAdressesDB();
            Console.WriteLine("Einde");
            //AdresRequest req = new AdresRequest(sqlFactory, connectionString);
            //Adres adresrequestTest = req.GetAdres(2000000004);
            //Console.WriteLine(adresrequestTest);
            //List<Straatnaam> straatnamen = req.getStraatnamen("Gent");
            //foreach (Straatnaam straatnaam in straatnamen) {
            //    System.Console.WriteLine(straatnaam);
            //}
        }
    }
}
