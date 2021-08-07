using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
/*
namespace ClassLibrary1 {
   public class AdresRequest {
        private DbProviderFactory sqlFactory;
        private string connectionString;
        public AdresRequest(DbProviderFactory sqlFactory, string connectionString) {
            this.sqlFactory = sqlFactory;
            this.connectionString = connectionString;
        }
        private DbConnection getConnection() {
            DbConnection connection = sqlFactory.CreateConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }
        public Adres GetAdres(int ID) {
            DbConnection connection = getConnection();
            string query = "SELECT adres.*, adreslocatie.x, adreslocatie.y, straatnaam.straatnaam, straatnaam.NIScode, gemeente.gemeentenaam " +
                           "FROM adres " +
                           "JOIN adreslocatie " +
                           "ON adres.adreslocatieID = adreslocatie.ID " +
                           "JOIN straatnaam " +
                           "ON adres.straatnaamID = straatnaam.ID " +
                           "JOIN gemeente " +
                           "ON straatnaam.NIScode = gemeente.NIScode " +
                           "WHERE adres.ID = @ID;";

            using (DbCommand command = connection.CreateCommand()) {
                command.CommandText = query;
                DbParameter paramID = sqlFactory.CreateParameter();
                paramID.ParameterName = "@ID";
                paramID.DbType = DbType.Int32;
                paramID.Value = ID;
                command.Parameters.Add(paramID);
                connection.Open();
                try {

                    DbDataReader reader = command.ExecuteReader();
                    reader.Read();
                    Gemeente gemeente = new Gemeente((int)reader["NIScode"], (string)reader["gemeentenaam"]);
                    Straatnaam straatnaam = new Straatnaam((int)reader["straatnaamID"], (string)reader["straatnaam"], gemeente);
                    Adres adres = new Adres((int)reader["ID"], straatnaam, (string)reader["appartementnummer"],
                        (string)reader["busnummer"], (string)reader["huisnummer"],
                        (string)reader["huisnummerlabel"], (int)reader["adreslocatieID"], (double)reader["x"], (double)reader["y"]
                        );
                    reader.Close();
                    return adres;
                } catch (Exception ex) {
                    Console.WriteLine(ex);
                    return null;
                } finally {
                    connection.Close();
                }
            }
        }
        public List<Straatnaam> getStraatnamen(string gemeentenaam) {
            List<Straatnaam> straatnamen = new List<Straatnaam>();
            DbConnection connection = getConnection();
            string query = "select straatnaam.* " +
                             "from straatnaam " +
                             "inner join gemeente " +
                             "on straatnaam.NIScode = gemeente.NIScode " +
                             "where gemeente.gemeentenaam = @gemeentenaam " +
                             "order by straatnaam.straatnaam ASC;";
            using (DbCommand command = connection.CreateCommand()) {
                command.CommandText = query;
                DbParameter paramID = sqlFactory.CreateParameter();
                paramID.ParameterName = "@gemeentenaam";
                paramID.DbType = DbType.AnsiString;
                paramID.Value = gemeentenaam;
                command.Parameters.Add(paramID);
                connection.Open();
                try {

                    DbDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        Gemeente gemeente = new Gemeente((int)reader["NIScode"], gemeentenaam);
                        Straatnaam straatnaam = new Straatnaam((int)reader["ID"], (string)reader["straatnaam"], gemeente);
                        straatnamen.Add(straatnaam);
                    }
                    reader.Close();
                    return straatnamen;
                } catch (Exception ex) {
                    Console.WriteLine(ex);
                    return null;
                } finally {
                    connection.Close();
                }
            }
        }
        public List<Adres> getAdressenStraat(int straatnaamId) {
            List<Adres> adressen = new List<Adres>();
            DbConnection connection = getConnection();
            string query = "SELECT adres.*, straatnaam.straatnaam, straatnaam.NIScode, gemeente.gemeentenaam, adreslocatie.x,adreslocatie.y " +
                            "FROM adres " +
                            "JOIN straatnaam " +
                            "ON adres.straatnaamID = straatnaam.ID " +
                            "JOIN gemeente " +
                            "ON straatnaam.NIScode = gemeente.NIScode " +
                            "JOIN adreslocatie " +
                            "ON adres.adreslocatieID = adreslocatie.Id " +
                            "WHERE straatnaam.ID = @straatnaamId; ";
            using (DbCommand command = connection.CreateCommand()) {
                command.CommandText = query;
                DbParameter paramID = sqlFactory.CreateParameter();
                paramID.ParameterName = "@straatnaamId";
                paramID.DbType = DbType.Int32;
                paramID.Value = straatnaamId;
                command.Parameters.Add(paramID);
                connection.Open();
                try {

                    DbDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        Gemeente gemeente = new Gemeente((int)reader["NIScode"], (string)reader["gemeentenaam"]);
                        Straatnaam straatnaam = new Straatnaam((int)reader["straatnaamID"], (string)reader["straatnaam"], gemeente);
                        Adres adres = new Adres((int)reader["ID"], straatnaam, (string)reader["appartementnummer"],
                            (string)reader["busnummer"], (string)reader["huisnummer"],
                            (string)reader["huisnummerlabel"], (int)reader["adreslocatieID"], (double)reader["x"], (double)reader["y"]
                            );
                        adressen.Add(adres);
                    }
                    reader.Close();
                    return adressen;
                } catch (Exception ex) {
                    Console.WriteLine(ex);
                    return null;
                } finally {
                    connection.Close();
                }
            }
        }

    }
}
*/