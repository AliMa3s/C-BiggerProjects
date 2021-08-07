using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using System.Data.Common;

namespace ClassLibrary1 {
    public class Bevraging {
        public Bevraging(string connectionstring) {
            this.connectionString = connectionstring;
        }

        private string connectionString;
        private SqlConnection GetConnection() {
            SqlConnection connection1 = new SqlConnection(connectionString);
            return connection1;
        }
        #region Num: 1 public bool BestaatAdres(Adres adres)
        public bool BestaatAdres(Adres adres) {

            SqlConnection conn = new SqlConnection(connectionString);

            string query = "SELECT * FROM dbo.adres WHERE Id=@Id and huisnummer=@huisnummer and busnummer=@busnummer and appartementnummer=@appartementnummer and" +
                " huisnummerlabel=@huisnummerlabel";
            //database null moet voorzien
            using (SqlCommand cmd = conn.CreateCommand()) {
                cmd.CommandText = query;
                SqlParameter Idpara = new SqlParameter();
                Idpara.ParameterName = "@Id";
                Idpara.DbType = DbType.Int32;
                Idpara.Value = adres.ID;
                cmd.Parameters.Add(Idpara);

                SqlParameter huisnummerpara = new SqlParameter();
                huisnummerpara.ParameterName = "@huisnummer";
                huisnummerpara.DbType = DbType.String;
                huisnummerpara.Value = adres.HuisNummer;
                cmd.Parameters.Add(huisnummerpara);

                SqlParameter busnummerpara = new SqlParameter();
                busnummerpara.ParameterName = "@busnummer";
                busnummerpara.DbType = DbType.String;
                busnummerpara.Value = adres.Busnummer;
                cmd.Parameters.Add(busnummerpara);

                SqlParameter appartnummerpara = new SqlParameter();
                appartnummerpara.ParameterName = "@appartementnummer";
                appartnummerpara.DbType = DbType.String;
                appartnummerpara.Value = adres.AppNummer;
                cmd.Parameters.Add(appartnummerpara);


                SqlParameter huisnummerlabelpara = new SqlParameter();
                huisnummerlabelpara.ParameterName = "@huisnummerlabel";
                huisnummerlabelpara.DbType = DbType.String;
                huisnummerlabelpara.Value = adres.HuisNummerLabel;
                cmd.Parameters.Add(huisnummerlabelpara);

                conn.Open();
                try {
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    Adres ade = new Adres {
                        ID = (int)reader["Id"], HuisNummer = (string)reader["huisnummer"], Busnummer = (string)reader["busnummer"],
                        AppNummer = (string)reader["appartementnummer"], HuisNummerLabel = (string)reader["huisnummerlabel"]
                    };

                    reader.Close();
                    Console.WriteLine("Adres bestaat");
                    return ade != null;

                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Adres bestaat niet");
                    return false;

                } finally {
                    conn.Close();
                }
            }
        }
        #endregion
        #region Num: 2 public bool BestaatGemeente(Gemeente gemeente);
        public bool BestaatGemeente(Gemeente gemeente) {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT gemeentenaam FROM dbo.gemeente WHERE gemeentenaam=@gemeentenaam";
            using (SqlCommand cmd = conn.CreateCommand()) {
                cmd.CommandText = query;
                SqlParameter gemeentepara = new SqlParameter();
                gemeentepara.ParameterName = "@gemeentenaam";
                gemeentepara.DbType = DbType.String;
                gemeentepara.Value = gemeente.Naam;
                cmd.Parameters.Add(gemeentepara);


                conn.Open();
                try {
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    Gemeente gem = new Gemeente { Naam = (string)reader["gemeentenaam"] };
                    reader.Close();
                    Console.WriteLine("Gemeente bestaat");
                    return gem != null;

                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Gemeente bestaat niet");
                    return false;

                } finally {
                    conn.Close();
                }
            }
        }
        #endregion

        #region Num: 3 BestaatStraatnaam(string straatnaam, gemeente gemeente);
        public bool BestaatStraatnaam(string straatnaam, Gemeente gemeente) {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT straatnaam FROM straat st LEFT JOIN gemeente gem ON st.NISCODE = gem.NISCODE WHERE gem.gemeentenaam=@naam AND st.straatnaam=@straatnaam";
            using (SqlCommand cmd = conn.CreateCommand()) {
                cmd.CommandText = query;
                SqlParameter gemeentepara = new SqlParameter();
                gemeentepara.ParameterName = "@naam";
                gemeentepara.DbType = DbType.String;
                gemeentepara.Value = gemeente.Naam;
                cmd.Parameters.Add(gemeentepara);

                SqlParameter straatpara = new SqlParameter();
                straatpara.ParameterName = "@straatnaam";
                straatpara.DbType = DbType.String;
                straatpara.Value = straatnaam;
                cmd.Parameters.Add(straatpara);

                conn.Open();
                try {
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    Straat straat = new Straat { Naam = (string)reader["straatnaam"] };
                    reader.Close();
                    Console.WriteLine("Straat bestaat");
                    return straat != null;

                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Straat bestaat niet");
                    return false;

                } finally {
                    conn.Close();
                }
            }
        }
        #endregion

        #region Num: 4 SelecteerAdres DONE
        public Adres SelecteerAdres(int id) {
            SqlConnection connection = GetConnection();
            var query = "SELECT a.Id, a.straatid, huisnummer, appartementnummer, busnummer, huisnummer, huisnummerlabel, s.straatnaam, s.NISCODE, " +
                "g.gemeentenaam FROM adres a JOIN straat s ON a.straatid = s.Id JOIN gemeente g ON s.niscode = g.niscode where a.Id = @ID";
            using (SqlCommand command = connection.CreateCommand()) {
                command.CommandText = query;
                command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                command.Parameters["@Id"].Value = id;
                connection.Open();
                try {
                    IDataReader reader = command.ExecuteReader(); //Of SQLDATAREADER
                    reader.Read();
                    Gemeente gmt = new Gemeente((string)reader["gemeentenaam"], (int)reader["niscode"]);
                    Straat strt = new Straat((int)reader["Id"], (string)reader["straatnaam"], (int)reader["niscode"]);
                    string appartementnummer = (object)reader["appartementnummer"] == DBNull.Value ? "null" : (string)reader["appartementnummer"];
                    string busnummer = (object)reader["busnummer"] == DBNull.Value ? "null" : (string)reader["busnummer"];
                    string huisnummerlabel = (object)reader["huisnummerlabel"] == DBNull.Value ? "null" : (string)reader["huisnummerlabel"];
                    AdresLocatie adrl = new AdresLocatie(0, 0, 0);
                    Adres adres = new Adres((int)reader["Id"], (string)reader["huisnummer"], huisnummerlabel, gmt.NIScode, strt, adrl);
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
        #endregion SelecteerAdres

        #region Num:6 LIST SelecteerAdressenInGemeente(int niscode) DONE
        public List<Adres> SelecteerAdressenInGemeente(int Niscode) {

            List<Adres> adressenlijst = new List<Adres>();
            SqlConnection conn = new SqlConnection(connectionString);
            //string query = "SELECT * from dbo.adres a LEFT JOIN dbo.straat s ON a.straatID = s.Id where s.NISCODE = @NISCODE ";
            string query = "SELECT a.*,s.id straadid, s.straatnaam,ad.id locatieid, ad.x, ad.y from dbo.adres a " +
            " LEFT JOIN dbo.straat s ON a.straatID = s.Id" +
            " LEFT JOIN dbo.adreslocatie ad ON a.adreslocatieID = ad.id " +
            " where s.NISCODE = @NISCODE ";
            //string query = "SELECT a.id, a.straatID, a.huisnummer, a.appartementnummer, a.busnummer, a.huisnummerlabel, a.adreslocatieID, a.postcode, stra.NISCODE FROM adres a LEFT JOIN straat stra ON a.straatID = stra.id WHERE stra.NISCODE= @NISCODE";
            using (SqlCommand cmd = conn.CreateCommand()) {
                cmd.CommandText = query;

                SqlParameter parameteradr = new SqlParameter();
                parameteradr.ParameterName = "@NISCODE";
                parameteradr.DbType = DbType.String;
                parameteradr.Value = Niscode;
                cmd.Parameters.Add(parameteradr);

                conn.Open();
                try {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        AdresLocatie adrslocatie = new AdresLocatie((int)reader["locatieid"], (double)reader["x"], (double)reader["y"]);
                        Straat st = new Straat((int)reader["id"], (string)reader["straatnaam"]);

                        Adres adt = new Adres((int)reader["id"], st, (string)reader["huisnummer"], adrslocatie);
                        adressenlijst.Add(adt);
                        //   (new Adres
                        //(
                        //reader["id"].ToString(),
                        //reader["straatid"].ToString(),
                        //reader["huisnummer"].ToString(),
                        //reader["busnummer"].ToString(),
                        //reader["appartementnummer"].ToString(),
                        //reader["huisnummerlabel"].ToString(),
                        //reader["postcode"].ToString(),
                        //reader["adreslocatieid"].ToString()
                        //));
                        foreach (var item in adressenlijst) {
                            Console.WriteLine(item);
                        }
                    }

                    reader.Close();
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Niet gelukt!");
                } finally {
                    conn.Close();
                }
                return adressenlijst;
            }
        }



        #endregion

        #region Num:6 LIST SelecteerAdressenInStraat(straatid) DONE
        public List<Adres> SelecteerAdressInStraat(int straadID) {
            SqlConnection connection = GetConnection();
            var query = "SELECT * From adres WHERE straatID = @straatid";
            List<Adres> adressen = new List<Adres>();
            using (SqlCommand command = connection.CreateCommand()) {
                command.CommandText = query;
                command.Parameters.Add(new SqlParameter("straatid", SqlDbType.Int));
                command.Parameters["@straatid"].Value = straadID;
                connection.Open();
                try {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        Adres adres = SelecteerAdres((int)reader["id"]);
                        adressen.Add(adres);
                    }
                    reader.Close();
                } catch (Exception ex) {
                    Console.WriteLine(ex);
                } finally {
                    connection.Close();
                }
                return adressen;
            }
        }
        #endregion
        #region Num: 7 Gemeente selecteergemeente(niscode) DONE
        public Gemeente SelecteerGemeente(int NIScode) {
            {
                DbConnection connection = getConnection();
                string query = "SELECT * FROM dbo.gemeente WHERE NISCODE=@NIScode";
                using (DbCommand command = connection.CreateCommand()) {
                    command.CommandText = query;
                    DbParameter paramNIScode = sqlFactory.CreateParameter();
                    paramNIScode.ParameterName = "@NIScode";
                    paramNIScode.DbType = DbType.Int32;
                    paramNIScode.Value = NIScode;
                    command.Parameters.Add(paramNIScode);
                    connection.Open();
                    try {
                        DbDataReader reader = command.ExecuteReader();
                        reader.Read();

                        Gemeente gemeente = new Gemeente((string)reader["gemeentenaam"], (int)reader["NISCODE"]);
                        reader.Close();
                        return gemeente;
                    } catch (Exception ex) {
                        Console.WriteLine(ex);
                        return null;
                    } finally {
                        connection.Close();
                    }
                }
            }
        }
        #endregion
        #region Num:8 List<Gemeente> SelecteerGemeenten()  DONE
        public List<Gemeente> SelecteerGemeenten() {
            List<Gemeente> gemeentes = new List<Gemeente>();
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT * FROM gemeente;";

            using (SqlCommand comm = conn.CreateCommand()) {
                comm.CommandText = query;
                conn.Open();
                try {
                    SqlDataReader r = comm.ExecuteReader();
                    while (r.Read()) {

                        gemeentes.Add(new Gemeente((string)r["gemeentenaam"], (int)r["NISCODE"]));
                        foreach (var g in gemeentes) {
                            Console.WriteLine(g);
                        }
                    }

                    return gemeentes;
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                } finally {
                    conn.Close();
                }
                return null;
            }
        }
        #endregion

        #region Num :9 Straat selecteerstraat(int id) DONE
        public Straat SelecteerStraat(int id) {
            DbConnection connection = getConnection();
            string query = "SELECT * FROM dbo.straat WHERE id=@id";
            using (DbCommand command = connection.CreateCommand()) {
                command.CommandText = query;
                DbParameter paramId = sqlFactory.CreateParameter();
                paramId.ParameterName = "@Id";
                paramId.DbType = DbType.Int32;
                paramId.Value = id;
                command.Parameters.Add(paramId);
                connection.Open();
                try {
                    DbDataReader reader = command.ExecuteReader();
                    reader.Read();
                    int straatID = (int)reader["Id"];
                    string straatnaam = (string)reader["straatnaam"];
                    int NIScode = (int)reader["NIScode"];
                    reader.Close();

                    Gemeente gemeente = SelecteerGemeente(NIScode);
                    Straat straat = new Straat(straatID, straatnaam, gemeente);

                    return straat;
                } catch (Exception ex) {
                    Console.WriteLine(ex);
                    return null;
                } finally {
                    connection.Close();
                }
            }
        }

        #endregion

        private DbProviderFactory sqlFactory;
        public Bevraging(DbProviderFactory sqlFactory, string connectionString) {
            this.sqlFactory = sqlFactory;
            this.connectionString = connectionString;
        }
        private DbConnection getConnection() {
            DbConnection connection = sqlFactory.CreateConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }



        #region NUm10: List<straat> selecteerstrateningemeente(int niscode) DONE
        public List<string> SelecteerStratenInGemeente(int Niscode) {
            DbConnection connection = getConnection();


            //Stap  : de NIScode van de gegeven gemeentenaam zoeken 

            string query = "SELECT * FROM dbo.gemeente WHERE NISCODE=@NISCODE";
            int NIScode = 0;
            List<string> straten = new List<string>();

            using (DbCommand command = connection.CreateCommand()) {
                command.CommandText = query;
                DbParameter paramGemeentenaam = sqlFactory.CreateParameter();
                paramGemeentenaam.ParameterName = "@NISCODE";
                paramGemeentenaam.DbType = DbType.String;
                paramGemeentenaam.Value = Niscode;
                command.Parameters.Add(paramGemeentenaam);
                connection.Open();
                try {
                    DbDataReader reader = command.ExecuteReader();
                    reader.Read();
                    NIScode = (int)reader["NISCODE"];
                    reader.Close();

                } catch (Exception ex) {
                    Console.WriteLine(ex);
                    return null;
                } finally {
                    connection.Close();
                }
            }
            string querystraten = "SELECT * FROM dbo.straat WHERE NIScode=@NIScode";

            using (DbCommand command = connection.CreateCommand()) {
                command.CommandText = querystraten;
                DbParameter paramNIScode = sqlFactory.CreateParameter();
                paramNIScode.ParameterName = "@NIScode";
                paramNIScode.DbType = DbType.Int32;
                paramNIScode.Value = NIScode;
                command.Parameters.Add(paramNIScode);
                connection.Open();
                try {
                    DbDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        straten.Add(reader.GetString(1));
                        foreach (var s in straten) {
                            Console.WriteLine(s);
                        }
                    }
                    reader.Close();

                } catch (Exception ex) {
                    Console.WriteLine(ex);
                    return null;
                } finally {
                    connection.Close();
                }

            }
            straten.Sort();
            return straten;
        }
        //public List<Adres> SelecteerAdressenInGemeente(int Niscode) {
        //    DbConnection connection = getConnection();

        //    string query = "SELECT * FROM dbo.adres WHERE postcode=@postcode";
        //    List<Adres> adressen = new List<Adres>();

        //    using (DbCommand command = connection.CreateCommand()) {
        //        command.CommandText = query;
        //        DbParameter paramId = sqlFactory.CreateParameter();
        //        paramId.ParameterName = "@postcode";
        //        paramId.DbType = DbType.Int32;
        //        paramId.Value = Niscode;
        //        command.Parameters.Add(paramId);
        //        connection.Open();
        //        try {
        //            DbDataReader reader = command.ExecuteReader();
        //            while (reader.Read()) {
        //                int adresID = (int)reader["postcode"];
        //                Adres adres = SelecteerAdres(adresID);
        //                adressen.Add(adres);
        //            }
        //            reader.Close();
        //        } catch (Exception ex) {
        //            Console.WriteLine(ex);
        //            return null;
        //        } finally {
        //            connection.Close();
        //        }
        //    }
        //    return adressen;
        //}


        #endregion



        #region Num: 11 list<straat> selecteerstrateningemeente(string gemeentnaam) DONE
        public List<string> SelecteerStrateninGemeente(string gemeentenaam) {
            DbConnection connection = getConnection();


            //Stap  : de NIScode van de gegeven gemeentenaam zoeken 

            string query = "SELECT * FROM dbo.gemeente WHERE gemeentenaam=@gemeentenaam";
            int NIScode = 0;
            List<string> straten = new List<string>();

            using (DbCommand command = connection.CreateCommand()) {
                command.CommandText = query;
                DbParameter paramGemeentenaam = sqlFactory.CreateParameter();
                paramGemeentenaam.ParameterName = "@gemeentenaam";
                paramGemeentenaam.DbType = DbType.String;
                paramGemeentenaam.Value = gemeentenaam;
                command.Parameters.Add(paramGemeentenaam);
                connection.Open();
                try {
                    DbDataReader reader = command.ExecuteReader();
                    reader.Read();
                    NIScode = (int)reader["NISCODE"];
                    reader.Close();

                } catch (Exception ex) {
                    Console.WriteLine(ex);
                    return null;
                } finally {
                    connection.Close();
                }
            }
            string querystraten = "SELECT * FROM dbo.straat WHERE NIScode=@NIScode";

            using (DbCommand command = connection.CreateCommand()) {
                command.CommandText = querystraten;
                DbParameter paramNIScode = sqlFactory.CreateParameter();
                paramNIScode.ParameterName = "@NIScode";
                paramNIScode.DbType = DbType.Int32;
                paramNIScode.Value = NIScode;
                command.Parameters.Add(paramNIScode);
                connection.Open();
                try {
                    DbDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        straten.Add(reader.GetString(1));
                    }
                    reader.Close();

                } catch (Exception ex) {
                    Console.WriteLine(ex);
                    return null;
                } finally {
                    connection.Close();
                }

            }
            straten.Sort();
            return straten;
        }

        #endregion

        #region Update

        #region Num:12 UpdateAdres(Adres adres) DONE
        public void UpdateAdres(Adres adres) {
            SqlConnection connection = GetConnection();
            Adres adresDB = SelecteerAdres(adres.ID);
            string query = "Select * FROM dbo.adres WHERE Id=@Id";

            using (SqlDataAdapter adapter = new SqlDataAdapter()) {
                try {
                    SqlParameter paramId = new SqlParameter();
                    paramId.ParameterName = "@Id";
                    paramId.DbType = DbType.Int32;
                    paramId.Value = adres.ID;
                    SqlCommandBuilder builder = new SqlCommandBuilder();
                    builder.DataAdapter = adapter;
                    adapter.SelectCommand = new SqlCommand();
                    adapter.SelectCommand.CommandText = query;
                    adapter.SelectCommand.Connection = connection;
                    adapter.SelectCommand.Parameters.Add(paramId);
                    adapter.UpdateCommand = builder.GetUpdateCommand();
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    table.Rows[0]["huisnummer"] = adres.HuisNummer;
                    table.Rows[0]["appartementnummer"] = adres.AppNummer;
                    table.Rows[0]["busnummer"] = adres.Busnummer;
                    table.Rows[0]["huisnummerlabel"] = adres.HuisNummerLabel;

                    Console.WriteLine("Adres changed");
                    adapter.Update(table);
                } catch (Exception ex) {
                    Console.WriteLine(ex);
                } finally {
                    connection.Close();
                }
            }

        }
        #endregion

        #region Num:13 UpdateGemeente(Gemeente gemeente) DONE
        public void UpdateGemeente(Gemeente gemeente) {
            SqlConnection connection = GetConnection();
            Gemeente gemeenteDB = SelecteerGemeente(gemeente.NIScode);
            string query = "Select * FROM dbo.gemeente WHERE NISCODE=@NIScode";

            using (SqlDataAdapter adapter = new SqlDataAdapter()) {
                try {
                    SqlParameter paramId = new SqlParameter();
                    paramId.ParameterName = "@NISCODE";
                    paramId.DbType = DbType.Int32;
                    paramId.Value = gemeente.NIScode;
                    SqlCommandBuilder builder = new SqlCommandBuilder();
                    builder.DataAdapter = adapter;
                    adapter.SelectCommand = new SqlCommand();
                    adapter.SelectCommand.CommandText = query;
                    adapter.SelectCommand.Connection = connection;
                    adapter.SelectCommand.Parameters.Add(paramId);
                    adapter.UpdateCommand = builder.GetUpdateCommand();
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    table.Rows[0]["gemeentenaam"] = gemeente.Naam;
                    Console.WriteLine("gemeentenaam changed");
                    adapter.Update(table);
                } catch (Exception ex) {
                    Console.WriteLine(ex);
                } finally {
                    connection.Close();
                }
            }

        }
        #endregion
        #region Num: 14 UpdateStraat(straat straat) DONE
        public void UpdateStraat(Straat straat) {
            SqlConnection connection = GetConnection();
            Straat straatDB = SelecteerStraat(straat.Id);
            string query = "Select * FROM dbo.straat WHERE Id=@Id";

            using (SqlDataAdapter adapter = new SqlDataAdapter()) {
                try {
                    SqlParameter paramId = new SqlParameter();
                    paramId.ParameterName = "@Id";
                    paramId.DbType = DbType.Int32;
                    paramId.Value = straat.Id;
                    SqlCommandBuilder builder = new SqlCommandBuilder();
                    builder.DataAdapter = adapter;
                    adapter.SelectCommand = new SqlCommand();
                    adapter.SelectCommand.CommandText = query;
                    adapter.SelectCommand.Connection = connection;
                    adapter.SelectCommand.Parameters.Add(paramId);
                    adapter.UpdateCommand = builder.GetUpdateCommand();
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    table.Rows[0]["straatnaam"] = straat.Naam;
                    Console.WriteLine("straatnaam changed");
                    adapter.Update(table);
                } catch (Exception ex) {
                    Console.WriteLine(ex);
                } finally {
                    connection.Close();
                }
            }

        }
        #endregion


        #endregion

        #region Verwijder
        #region Num15 16 17 void VerwijderAdres(int id)
        #region Num:15 verwijderAdres(int id) DONE
        public void VerwijderAdres(int id) {

            string query = "DELETE FROM dbo.adres where id=@id";

            SqlConnection connection = GetConnection();
            using (SqlCommand command = connection.CreateCommand()) {
                connection.Open();
                try {
                    command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    command.CommandText = query;
                    command.Parameters["@id"].Value = id;
                    command.ExecuteNonQuery();
                    Console.WriteLine($"adres met {id} verwijderd");

                } catch (Exception ex) {
                    Console.WriteLine(ex);
                } finally {
                    connection.Close();
                }
            }
        }

        #endregion
        #region Num:16  verwijderGemeente(int id) DONE
        public void VerwijderGemeente(int Niscode) {

            string query = "DELETE FROM dbo.gemeente where NIScode=@NIScode";

            SqlConnection connection = GetConnection();
            using (SqlCommand command = connection.CreateCommand()) {
                connection.Open();
                try {
                    command.Parameters.Add(new SqlParameter("@NIScode", SqlDbType.Int));
                    command.CommandText = query;
                    command.Parameters["@NIScode"].Value = Niscode;
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Gemeente met {Niscode} verwijderd");

                } catch (Exception ex) {
                    Console.WriteLine(ex);
                } finally {
                    connection.Close();
                }
            }
        }

        #endregion
        #region Num:17  verwijderstraat(int id) DONE
        public void VerwijderStraat(int id) {

            string query = "DELETE FROM dbo.straat where id=@id";

            SqlConnection connection = GetConnection();
            using (SqlCommand command = connection.CreateCommand()) {
                connection.Open();
                try {
                    command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    command.CommandText = query;
                    command.Parameters["@id"].Value = id;
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Straat met {id} verwijderd");

                } catch (Exception ex) {
                    Console.WriteLine(ex);
                } finally {
                    connection.Close();
                }
            }
        }

        #endregion


        #endregion


        #endregion


        #region 18 19 20 Voegen Informaties

        //DONE
        public void VoegAdresToe(Adres adres) {
            SqlConnection connection = GetConnection();

            string queryS = "INSERT INTO adreslocatie (id,x, y) output INSERTED.ID VALUES(@id,@x, @y)";
            string querySC = "INSERT INTO adres (id, straatID, huisnummer, appartementnummer, busnummer, huisnummerlabel, adreslocatieid,postcode) " +
                "VALUES(@id, @straatID, @huisnummer, @appartementnummer, @busnummer, @huisnummerlabel, @adreslocatieid,@postcode)";

            using (SqlCommand command1 = connection.CreateCommand()) {
                using (SqlCommand command2 = connection.CreateCommand()) {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    command1.Transaction = transaction;
                    command2.Transaction = transaction;
                    try {
                        // adreslocatie toevoegen
                        command1.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                        command1.Parameters.Add(new SqlParameter("@x", SqlDbType.Float));
                        command1.Parameters.Add(new SqlParameter("@y", SqlDbType.Float));
                        command1.CommandText = queryS;
                        command1.Parameters["@id"].Value = adres.Adreslocatie.Id;
                        command1.Parameters["@x"].Value = adres.Adreslocatie.X;
                        command1.Parameters["@y"].Value = adres.Adreslocatie.Y;
                        // nieuw Id opvragen
                        int newId = (int)command1.ExecuteScalar();

                        //adres toevoegen
                        command2.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                        command2.Parameters.Add(new SqlParameter("@straatID", SqlDbType.Int));
                        command2.Parameters.Add(new SqlParameter("@huisnummer", SqlDbType.NVarChar));
                        command2.Parameters.Add(new SqlParameter("@appartementnummer", SqlDbType.NVarChar));
                        command2.Parameters.Add(new SqlParameter("@busnummer", SqlDbType.NVarChar));
                        command2.Parameters.Add(new SqlParameter("@huisnummerlabel", SqlDbType.NVarChar));
                        command2.Parameters.Add(new SqlParameter("@adreslocatieid", SqlDbType.Int));
                        command2.Parameters.Add(new SqlParameter("@postcode", SqlDbType.Int));

                        command2.CommandText = querySC;
                        command2.Parameters["@id"].Value = adres.ID;
                        command2.Parameters["@straatID"].Value = adres.StraatID;
                        command2.Parameters["@huisnummer"].Value = adres.HuisNummer;
                        command2.Parameters["@appartementnummer"].Value = adres.AppNummer == null ? DBNull.Value : (object)adres.AppNummer;
                        command2.Parameters["@busnummer"].Value = adres.Busnummer == null ? DBNull.Value : (object)adres.Busnummer;
                        command2.Parameters["@huisnummerlabel"].Value = adres.HuisNummerLabel == null ? DBNull.Value : (object)adres.HuisNummerLabel;
                        command2.Parameters["@adreslocatieid"].Value = newId;
                        command2.Parameters["@postcode"].Value = newId;
                        Console.WriteLine("Adres toegevoegd");
                        command2.ExecuteNonQuery();
                        transaction.Commit();
                    } catch (Exception ex) {
                        transaction.Rollback();
                        Console.WriteLine(ex);
                    } finally {
                        connection.Close();
                    }
                }
            }
        }

        //DONE
        public void voegGemeenteToe(Gemeente gemeente) {
            DbConnection connection = getConnection();
            string queryGemeente = "INSERT INTO dbo.gemeente(NIScode, gemeentenaam) VALUES(@NIScode,@gemeentenaam)";

            using (DbCommand command = connection.CreateCommand()) {
                connection.Open();

                try {

                    DbParameter parNIScode = sqlFactory.CreateParameter();
                    parNIScode.ParameterName = "@NIScode";
                    parNIScode.DbType = DbType.Int32;
                    command.Parameters.Add(parNIScode);
                    DbParameter parGemeentenaam = sqlFactory.CreateParameter();
                    parGemeentenaam.ParameterName = "@gemeentenaam";
                    parGemeentenaam.DbType = DbType.String;
                    command.Parameters.Add(parGemeentenaam);

                    command.CommandText = queryGemeente;
                    command.Parameters["@NIScode"].Value = gemeente.NIScode;
                    command.Parameters["@gemeentenaam"].Value = gemeente.Naam;
                    Console.WriteLine("Gemeente toegevoegd");
                    command.ExecuteNonQuery();

                } catch (Exception ex) {
                    Console.WriteLine(ex);
                } finally {
                    connection.Close();
                }
            }

        }
        //DONE
        public void voegStraatToe(Straat straat) {
            DbConnection connection = getConnection();
            string queryStraat = "INSERT INTO dbo.straat(Id, straatnaam, NISCODE) VALUES(@Id, @straatnaam, @NIScode)";

            using (DbCommand command = connection.CreateCommand()) {
                connection.Open();

                try {

                    DbParameter paId = sqlFactory.CreateParameter();
                    paId.ParameterName = "@Id";
                    paId.DbType = DbType.Int32;
                    command.Parameters.Add(paId);
                    DbParameter parStraatnaam = sqlFactory.CreateParameter();
                    parStraatnaam.ParameterName = "@straatnaam";
                    parStraatnaam.DbType = DbType.String;
                    command.Parameters.Add(parStraatnaam);
                    DbParameter parNIScode = sqlFactory.CreateParameter();
                    parNIScode.ParameterName = "@NIScode";
                    parNIScode.DbType = DbType.Int32;
                    command.Parameters.Add(parNIScode);


                    command.CommandText = queryStraat;
                    command.Parameters["@Id"].Value = straat.Id;
                    command.Parameters["@NIScode"].Value = straat.NISCODE;
                    command.Parameters["@straatnaam"].Value = straat.Naam;

                    Console.WriteLine("straat toegevoegd");
                    command.ExecuteNonQuery();

                } catch (Exception ex) {
                    Console.WriteLine(ex);
                } finally {
                    connection.Close();
                }
            }

        }


        #endregion
    }
}
