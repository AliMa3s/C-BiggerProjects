using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System;


namespace WpfAdresBeheer {
    /// <summary>
    /// Interaction logic for Adres.xaml
    /// </summary>
    public partial class Adres : Window {
        public Adres() {
            InitializeComponent();
            LoadGrid();
        }
        public void ClearVelden() {
            id_txt.Clear();
            Straat_txt.Clear();
            Busnr_txt.Clear();
            Huisnr_txt.Clear();
            Locatie_txt.Clear();
            Huislbl_txt.Clear();
            postcode_txt.Clear();
            Appnr_txt.Clear();
            search_txt.Clear();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True");
        private void btnClear_Click(object sender, RoutedEventArgs e) {
            ClearVelden();
        }

        public void LoadGrid() {
            SqlCommand cmd = new SqlCommand("Select TOP 1000 * FROM dbo.adres", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }

        public bool isValid() {
            if (id_txt.Text == string.Empty) {
                MessageBox.Show("Id is leeg", " ", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (Straat_txt.Text == string.Empty) {
                MessageBox.Show("Straat is leeg", " ", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (Huisnr_txt.Text == string.Empty) {
                MessageBox.Show("Huisnummer is leeg", " ", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (Appnr_txt.Text == string.Empty) {
                MessageBox.Show("AppartementNr is leeg", " ", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (Busnr_txt.Text == string.Empty) {
                MessageBox.Show("BusNr is leeg", " ", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (Huislbl_txt.Text == string.Empty) {
                MessageBox.Show("Huisnummerlabel is leeg", " ", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            //if (Locatie_txt.Text == string.Empty) {
            //    MessageBox.Show("Adreslocatie is leeg", " ", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return false;
            //}
            if (postcode_txt.Text == string.Empty) {
                MessageBox.Show("Postcode is leeg", " ", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private void Btn_Insert_Click(object sender, RoutedEventArgs e) {
            try {

                if (isValid()) {
                    //public Adres(int id, string huisNummer, string busnummer, string appNummer, string huisNummerLabel)
                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.adres VALUES(@id,@straatID,@huisnummer,@appartementnummer,@busnummer,@huisnummerlabel,@adreslocatieid,@postcode)", con);




                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", id_txt.Text);
                    cmd.Parameters.AddWithValue("@straatID", Straat_txt.Text);
                    cmd.Parameters.AddWithValue("@huisnummer", Huisnr_txt.Text);
                    cmd.Parameters.AddWithValue("@appartementnummer", Appnr_txt.Text);
                    cmd.Parameters.AddWithValue("@busnummer", Busnr_txt.Text);
                    cmd.Parameters.AddWithValue("@huisnummerlabel", Huislbl_txt.Text);
                    cmd.Parameters.AddWithValue("@adreslocatieid", Locatie_txt.Text);
                    cmd.Parameters.AddWithValue("@postcode", postcode_txt.Text);
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                    LoadGrid();
                    MessageBox.Show("Adres Toegevoegd", "Opgeslaan", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            } catch (SqlException ex) {

                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_Update_Click(object sender, RoutedEventArgs e) {
            con.Open();
            SqlCommand cmd = new SqlCommand("Update dbo.adres set huisnummer = '" + Huisnr_txt.Text + "', appartementnummer = '" + Appnr_txt.Text + "', busnummer = '" + Busnr_txt.Text + "'" +
                " Where id = '" + search_txt.Text + "'", con);
            try {

                cmd.ExecuteNonQuery();
                MessageBox.Show("Adres gewijzigd", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
            } catch (SqlException ex) {

                MessageBox.Show("Niet gelukt", ex.Message);
            } finally {
                con.Close();
                LoadGrid();
            }
        }

        private void Btn_VerwijderAdres_Click(object sender, RoutedEventArgs e) {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from dbo.adres where id = " + search_txt.Text + " ", con);
            try {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Adres is verwijdered", "Verwijderd", MessageBoxButton.OK, MessageBoxImage.Information);
                con.Close();
                LoadGrid();
                con.Close();
            } catch (SqlException ex) {

                MessageBox.Show("Niet Verwijderd " + ex.Message);
            } finally {
                con.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {

        }

        private void Button_Click_Terug(object sender, RoutedEventArgs e) {
            MainWindow aw = new MainWindow();
            aw.Show();
            this.Close();
        }
    }
}
