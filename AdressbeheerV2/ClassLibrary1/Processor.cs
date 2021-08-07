using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ClassLibrary1 {
    public class Processor {
        private string connectionString;

        //public SqlConnection ConnectionString { get; set; }

        public Processor(string connstring) {
            connectionString = connstring;
        }

        //public void RunProcess() {
        //    DataReader data = new DataReader();
        //    data.adres = data.readFile();
        //    data.gemeentes = data.readFile();
        //    data.straten = data.readFile();
        //    data.adreslocatie = data.readFile();

        //}

        public void BulkGemeente(List<Gemeente> gemeente) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                using (SqlBulkCopy sqbc = new SqlBulkCopy(connection)) {
                    DataTable tabel = new DataTable();
                    //tabel.Columns.Add("NISCODE", typeof(int));
                    //tabel.Columns.Add("gemeentenaam", typeof(string));
                    tabel.Columns.Add(new DataColumn("NISCODE", Type.GetType("System.Int32")));
                    tabel.Columns.Add(new DataColumn("gemeentenaam", Type.GetType("System.String")));

                    foreach (Gemeente g in gemeente) {
                        tabel.Rows.Add(g.NIScode, g.Naam);
                    }

                    sqbc.DestinationTableName = "gemeente";
                    //sqbc.ColumnMappings.Add("NISCODE", "NISCODE");
                    //sqbc.ColumnMappings.Add("gemeentenaam", "gemeentenaam");
                    //gemeente.Columns.Add(new DataColumn("NISCODE", Type.GetType("System.Int32")));
                    //gemeente.Columns.Add(new DataColumn("gemeentenaam", Type.GetType("System.String")));
                    sqbc.WriteToServer(tabel);
                }
                connection.Close();
                Console.WriteLine("AdresLocatie!");
            }
        }

        public void BulkStraten(List<Straat> straatee) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                using (SqlBulkCopy sqbc = new SqlBulkCopy(connection)) {
                    DataTable tabel = new DataTable();
                    tabel.Columns.Add("id", typeof(int));
                    tabel.Columns.Add("straatnaam", typeof(string));
                    tabel.Columns.Add("NISCODE", typeof(int));

                    //foreach (Adres s in adres) { if this make the list adres
                    //    tabel.Rows.Add(s.Straat.Id, s.Straat.Naam, s.Straat.NISCODE);
                    //}
                    foreach (Straat s in straatee) {
                        tabel.Rows.Add(s.Id, s.Naam, s.NISCODE);
                    }

                    sqbc.DestinationTableName = "straat";
                    sqbc.ColumnMappings.Add("id", "id");
                    sqbc.ColumnMappings.Add("straatnaam", "straatnaam");
                    sqbc.ColumnMappings.Add("NISCODE", "NISCODE");
                    sqbc.WriteToServer(tabel);
                }
                connection.Close();
                Console.WriteLine("straat!");
            }
        }

        public void BulkAdresLocatie(List<AdresLocatie> adres) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                using (SqlBulkCopy sqbc = new SqlBulkCopy(connection)) {
                    DataTable tabel = new DataTable();
                    tabel.Columns.Add("id", typeof(int));
                    tabel.Columns.Add("x", typeof(double));
                    tabel.Columns.Add("y", typeof(double));

                    //foreach (Adres adr in adres) { If this make list of adres in the parameter
                    //    tabel.Rows.Add(adr.Adreslocatie.Id, adr.Adreslocatie.X, adr.Adreslocatie.Y);
                    //}
                    foreach (AdresLocatie adr in adres) {
                        tabel.Rows.Add(adr.Id, adr.X, adr.Y);
                    }
                    sqbc.DestinationTableName = "adreslocatie";
                    sqbc.ColumnMappings.Add("id", "id");
                    sqbc.ColumnMappings.Add("x", "x");
                    sqbc.ColumnMappings.Add("y", "y");
                    sqbc.WriteToServer(tabel);
                }
                connection.Close();
                Console.WriteLine("AdresLocatie!");
            }
        }

        public void BulkAdres(List<Adres> adressen) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                using (SqlBulkCopy sqbc = new SqlBulkCopy(connection)) {
                    DataTable tabel = new DataTable();
                    tabel.Columns.Add("id", typeof(int));
                    tabel.Columns.Add("straatID", typeof(int));
                    tabel.Columns.Add("huisnummer", typeof(string));
                    tabel.Columns.Add("appartementnummer", typeof(string));
                    tabel.Columns.Add("busnummer", typeof(string));
                    tabel.Columns.Add("huisnummerlabel", typeof(string));
                    tabel.Columns.Add("adreslocatieID", typeof(int));
                    tabel.Columns.Add("postcode", typeof(int));

                    //adres.Columns.Add(new DataColumn("id", Type.GetType("System.Int32")));
                    //adres.Columns.Add(new DataColumn("straatID", Type.GetType("System.Int32")));
                    //adres.Columns.Add(new DataColumn("huisnummer", Type.GetType("System.String")));
                    //adres.Columns.Add(new DataColumn("appartementnummer", Type.GetType("System.String")));
                    //adres.Columns.Add(new DataColumn("busnummer", Type.GetType("System.String")));
                    //adres.Columns.Add(new DataColumn("huisnummerlabel", Type.GetType("System.String")));
                    //adres.Columns.Add(new DataColumn("adreslocatieId", Type.GetType("System.Int32")));
                    //adres.Columns.Add(new DataColumn("postcode", Type.GetType("System.Int32")));
                    foreach (Adres ad in adressen) {
                        tabel.Rows.Add(ad.ID, ad.Straat.Id, ad.HuisNummer, ad.AppNummer, ad.Busnummer, ad.HuisNummerLabel, ad.Adreslocatie.Id, ad.Postcode);
                    }

                    sqbc.DestinationTableName = "adres";
                    sqbc.ColumnMappings.Add("id", "id");
                    sqbc.ColumnMappings.Add("straatID", "straatID");
                    sqbc.ColumnMappings.Add("huisnummer", "huisnummer");
                    sqbc.ColumnMappings.Add("appartementnummer", "appartementnummer");
                    sqbc.ColumnMappings.Add("busnummer", "busnummer");
                    sqbc.ColumnMappings.Add("huisnummerlabel", "huisnummerlabel");
                    sqbc.ColumnMappings.Add("adreslocatieId", "adreslocatieID");
                    sqbc.ColumnMappings.Add("postcode", "postcode");
                    sqbc.WriteToServer(tabel);
                }
                connection.Close();
                Console.WriteLine("Adrestabel!");

            }
            //public void BulkAdres(HashSet<Adres> adressen) {

            //    using (SqlBulkCopy sqbc = new SqlBulkCopy(ConnectionString)) {
            //        DataTable adres = new DataTable("adres");
            //        adres.Columns.Add(new DataColumn("id", Type.GetType("System.Int32")));
            //        adres.Columns.Add(new DataColumn("straatID", Type.GetType("System.Int32")));
            //        adres.Columns.Add(new DataColumn("huisnummer", Type.GetType("System.String")));
            //        adres.Columns.Add(new DataColumn("appartementnummer", Type.GetType("System.String")));
            //        adres.Columns.Add(new DataColumn("busnummer", Type.GetType("System.String")));
            //        adres.Columns.Add(new DataColumn("huisnummerlabel", Type.GetType("System.String")));
            //        adres.Columns.Add(new DataColumn("adreslocatieId", Type.GetType("System.Int32")));
            //        adres.Columns.Add(new DataColumn("postcode", Type.GetType("System.Int32")));


            //        foreach (Adres ad in adressen) {
            //            adres.Rows.Add(ad.ID, ad.StraatId, ad.HuisNummer, ad.AppNummer, ad.Busnummer, ad.HuisNummerLabel, ad.AdreslocatieId, ad.Postcode);
            //        }

            //        sqbc.DestinationTableName = "adres";
            //        sqbc.WriteToServer(adres);
            //    }

        }
    }
}
