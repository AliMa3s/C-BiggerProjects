using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ClassLibrary1 {
   public class DataReader {
        private string connectionString;
        public DataReader(string connectionString) {
            this.connectionString = connectionString;
        }
        static readonly string path = @"D:\Hogent\Test\CRAB_Adressenlijst_GML\GML\CrabAdr.gml";
        public HashSet<Gemeente> gemeentes = new HashSet<Gemeente>();
        public HashSet<Straatnaam> straten = new HashSet<Straatnaam>();
        public HashSet<AdresLocatie> adreslocatie = new HashSet<AdresLocatie>();
        public HashSet<Adres> adres = new HashSet<Adres>();
        private SqlConnection getConnection() {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        //public void readFile() {
        //    using (StreamReader sr = new StreamReader(path)) {
        //        string line;
        //        while ((line = sr.ReadLine()) != null) {
        //            if (line.Contains("agiv:CrabAdr")) {
        //                string[] adresgegevens = new string[16];
        //                /*
        //                 0 is ID
        //                 1 is STRAATNMID
        //                 2 is STRAAT
        //                 3 is HUISNR
        //                 4 is APPNR                  
        //                 5 is BUSNR
        //                 6 is HNRLABEL
        //                 7 is NISCODE
        //                 8 is GEMEENTE
        //                 9 is POSTCODE
        //                 14 is X
        //                 15 is Y
        //                 */
        //                for (int i = 0; i < 20; i++) {
        //                    line = sr.ReadLine();
        //                    if (line.Contains("agiv:ID")) { adresgegevens[i] = Regex.Match(line, "(?<=>)(.*)(?=<)").ToString(); }
        //                    if (line.Contains("agiv:STRAATNMID")) { adresgegevens[i] = Regex.Match(line, "(?<=>)(.*)(?=<)").ToString(); }
        //                    if (line.Contains("agiv:STRAATNM>")) { adresgegevens[i] = Regex.Match(line, "(?<=>)(.*)(?=<)").ToString(); }
        //                    if (line.Contains("agiv:HUISNR")) { adresgegevens[i] = Regex.Match(line, "(?<=>)(.*)(?=<)").ToString(); }
        //                    if (line.Contains("agiv:APPTNR")) { adresgegevens[i] = Regex.Match(line, "(?<=>)(.*)(?=<)").ToString(); }
        //                    if (line.Contains("agiv:BUSNR")) { adresgegevens[i] = Regex.Match(line, "(?<=>)(.*)(?=<)").ToString(); }
        //                    if (line.Contains("agiv:HNRLABEL")) { adresgegevens[i] = Regex.Match(line, "(?<=>)(.*)(?=<)").ToString(); }
        //                    if (line.Contains("agiv:NISCODE")) { adresgegevens[i] = Regex.Match(line, "(?<=>)(.*)(?=<)").ToString(); }
        //                    if (line.Contains("agiv:GEMEENTE")) { adresgegevens[i] = Regex.Match(line, "(?<=>)(.*)(?=<)").Value.ToString(); }
        //                    if (line.Contains("agiv:POSTCODE")) { adresgegevens[i] = Regex.Match(line, "(?<=>)(.*)(?=<)").ToString(); }
        //                    if (line.Contains("gml:X")) { adresgegevens[i] = Regex.Match(line, "(?<=>)(.*)(?=<)").ToString(); }
        //                    if (line.Contains("gml:Y")) { adresgegevens[i] = Regex.Match(line, "(?<=>)(.*)(?=<)").ToString(); }
        //                }
        //                /// <summary>
        //                /// Gelogde gegevens 
        //                /// </summary>
        //                if (char.IsNumber(adresgegevens[3].ElementAt(0))) {
        //                    straten.Add(new Straatnaam(int.Parse(adresgegevens[1]), adresgegevens[2], int.Parse(adresgegevens[7])));
        //                    gemeentes.Add(new Gemeente(int.Parse(adresgegevens[7], adresgegevens[8])));
        //                    adreslocatie.Add(new AdresLocatie(int.Parse(adresgegevens[0]), double.Parse(adresgegevens[14]), double.Parse(adresgegevens[15])));
        //                    adres.Add(new Adres(
        //                        int.Parse(adresgegevens[0]),
        //                        int.Parse(adresgegevens[0]),
        //                        adresgegevens[4],
        //                        adresgegevens[5],
        //                        adresgegevens[3],
        //                        adresgegevens[6],
        //                        int.Parse(adresgegevens[1]),
        //                        int.Parse(adresgegevens[9])
        //                    );
        //                } else {
        //                    Console.WriteLine("Gelogd adres");
        //                    Console.WriteLine("Fout");
        //                    Console.WriteLine("---------------");
        //                    Console.WriteLine("Straat {0},", adresgegevens[2]);
        //                    Console.WriteLine("Huisnummer {0},", adresgegevens[3]);
        //                    Console.WriteLine("Gemeente: {0}", adresgegevens[8]);
        //                    Console.WriteLine("Postcode {0}", adresgegevens[9]);
        //                    Console.WriteLine("NIScode {0]", adresgegevens[7]);
        //                    Console.WriteLine("X", adresgegevens[14]);
        //                    Console.WriteLine("Y", adresgegevens[15]);
        //                }
        //            }
        //        }
        //    }
        //}
        public void RunProcess() {
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS; Initial Catalog = SqlAdres; Integrated Security = True");
            string link = @"D:\Hogent\Test\CRAB_Adressenlijst_GML\GML\CrabAdr.gml";

            SqlCommand command = new SqlCommand();
            try {
                conn.Open();
                SqlDataReader readFile = command.ExecuteReader();
                while (readFile.Read()) {

                    BulkGemeente(gemeentes);
                    BulkAdresLocatie(adreslocatie);
                    BulkStraten(straten);
                    BulkAdres(adres);
                }
            } catch (Exception ex) {

                Console.WriteLine(ex);
            } finally {
                conn.Close();
            }
        }
            //}
            /// <summary>
            /// Aanmkanen van een bulkcopy die de data verstuurd
            /// </summary>
            /// 
            //public void Store(MySqlConnection connection, string queryName, string query) {
            //    try {
            //        using (MySqlCommand myCmd = new MySqlCommand(query, connection)) {
            //            myCmd.CommandType = CommandType.Text;
            //            myCmd.ExecuteNonQuery();
            //        }
            //    } catch (Exception e) {
            //        Console.WriteLine("[" + queryName + "] Store: " + e.Message);
            //        throw;
            //    }
            //}
            //public void Upload() {
            //    int syncPoint = 1000; // je kan experimenteren met deze waarde
            //    using MySqlConnection mConnection = new MySqlConnection();
            //    if (string.IsNullOrWhiteSpace(mConnection.ConnectionString)) {
            //        string conn = "Server=127.0.0.1;Database=AdresLezen;Uid=sa;Pwd=zwarteridder";
            //        mConnection.ConnectionString = conn;
            //    }
            //    3 / 26 / 2020 ADONET bulk upload.md - Grip
            //localhost: 6419 4 / 4
            //mConnection.Open();
            //    var transaction = mConnection.BeginTransaction();
            //    {
            //        // ----------------------------------------------------------
            //        Console.WriteLine("Storing " + _adressen.Count + " adressen");
            //        idx = 0;
            //        q = new StringBuilder(Adres.InsertQuery);
            //        counter = 0;
            //        foreach (var i in _adressen.Values) {
            //            if (counter > 0)
            //                q.Append(",");
            //            q.Append("(" + i.AdresId + ", " + i.Straat.StraatNaamId + ", '" + i.HuisNummer + "', '" + i.A
            //            ++idx;
            //            ++counter;
            //            if (counter >= syncPoint) {
            //                Store(mConnection, "Adres", q.ToString());
            //                //Console.Write(".");
            //                q = new StringBuilder(Adres.InsertQuery);
            //                counter = 0;
            //            }
            //        }
            //        if (counter > 0) {
            //            Store(mConnection, "Adres", q.ToString());
            //            //Console.WriteLine(".");
            //        }
            //    }
            //    transaction.Commit();
            //    mConnection.Close();
            //    mConnection.Dispose();
            //}
            #region Methods 
            public void BulkGemeente(HashSet<Gemeente> gemeentes) {
            
                using (SqlBulkCopy sqbc = new SqlBulkCopy(connectionString)) {
                    DataTable gemeente = new DataTable("gemeente");
                    gemeente.Columns.Add(new DataColumn("NISCODE", Type.GetType("System.Int32")));
                    gemeente.Columns.Add(new DataColumn("gemeentenaam", Type.GetType("System.String")));

                    foreach (Gemeente g in gemeentes) {
                        gemeente.Rows.Add(g.NIScode, g.Naam);
                    }

                    sqbc.DestinationTableName = "gemeente";
                    sqbc.WriteToServer(gemeente);
                }
            
        }

        public void BulkStraten(HashSet<Straatnaam> straten) {
            
                using (SqlBulkCopy sqbc = new SqlBulkCopy(connectionString)) {
                    DataTable straat = new DataTable("straat");
                    straat.Columns.Add(new DataColumn("id", Type.GetType("System.Int32")));
                    straat.Columns.Add(new DataColumn("straatnaam", Type.GetType("System.String")));
                    straat.Columns.Add(new DataColumn("NISCODE", Type.GetType("System.Int32")));

                    foreach (Straatnaam s in straten) {
                        straat.Rows.Add(s.Id, s.Naam, s.NISCODE);
                    }

                    sqbc.DestinationTableName = "straat";
                    sqbc.WriteToServer(straat);
                }
            
        }

        public void BulkAdresLocatie(HashSet<AdresLocatie> adreslocaties) {
           
                using (SqlBulkCopy sqbc = new SqlBulkCopy(connectionString)) {
                    DataTable adreslocatie = new DataTable("adreslocatie");
                    adreslocatie.Columns.Add(new DataColumn("id", Type.GetType("System.Int32")));
                    adreslocatie.Columns.Add(new DataColumn("x", Type.GetType("System.Double")));
                    adreslocatie.Columns.Add(new DataColumn("y", Type.GetType("System.Double")));

                    foreach (AdresLocatie adr in adreslocaties) {
                        adreslocatie.Rows.Add(adr.Id, adr.X, adr.Y);
                    }

                    sqbc.DestinationTableName = "adreslocatie";
                    sqbc.WriteToServer(adreslocatie);
                }
            
        }

        public void BulkAdres(HashSet<Adres> adressen) {
            
                using (SqlBulkCopy sqbc = new SqlBulkCopy(connectionString)) {
                    DataTable adres = new DataTable("adres");
                    adres.Columns.Add(new DataColumn("id", Type.GetType("System.Int32")));
                    adres.Columns.Add(new DataColumn("straatID", Type.GetType("System.Int32")));
                    adres.Columns.Add(new DataColumn("huisnummer", Type.GetType("System.String")));
                    adres.Columns.Add(new DataColumn("appartementnummer", Type.GetType("System.String")));
                    adres.Columns.Add(new DataColumn("busnummer", Type.GetType("System.String")));
                    adres.Columns.Add(new DataColumn("huisnummerlabel", Type.GetType("System.String")));
                    adres.Columns.Add(new DataColumn("adreslocatieId", Type.GetType("System.Int32")));
                    adres.Columns.Add(new DataColumn("postcode", Type.GetType("System.Int32")));


                    foreach (Adres ad in adressen) {
                        adres.Rows.Add(ad.ID, ad.ID, ad.HuisNummer, ad.AppNummer, ad.Busnummer, ad.HuisNummerLabel, ad.AdreslocatieId, ad.Postcode);
                    }

                    sqbc.DestinationTableName = "adres";
                    sqbc.WriteToServer(adres);
                }
            
        }
        #endregion
    }
}
