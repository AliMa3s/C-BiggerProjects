using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAdresBheerv1 {
    /// <summary>
    /// Interaction logic for Adreswpf.xaml
    /// </summary>
    public partial class Adreswpf : Window {
        Bevraging bv;
        private string connectionString = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";
        public Adreswpf() {
            InitializeComponent();
            bv = new Bevraging(connectionString);
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
            SqlCommand cmd = new SqlCommand("Select TOP 1000 * FROM dbo.adres Order by Id ASC", con);
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
                AdresLocatie adl = new AdresLocatie(Int32.Parse(search_txt.Text), 12846.0, 123274.5);
                Adres ab = new Adres(Int32.Parse(id_txt.Text), Int32.Parse(Straat_txt.Text), Huisnr_txt.Text, Busnr_txt.Text, Appnr_txt.Text, Huislbl_txt.Text,
                   adl, Int32.Parse(postcode_txt.Text));

                bv.VoegAdresToe(ab);
                LoadGrid();

                MessageBox.Show("Adres Toegevoegd", "Opgeslaan", MessageBoxButton.OK, MessageBoxImage.Information);
                #region 5

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

                #endregion
            } catch (SqlException ex) {

                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_Update_Click(object sender, RoutedEventArgs e) {
            //con.Open();
            //SqlCommand cmd = new SqlCommand("Update dbo.adres set huisnummer = '" + Huisnr_txt.Text + "', appartementnummer = '" + Appnr_txt.Text + "', busnummer = '" + Busnr_txt.Text + "'" +
            //    " Where id = '" + search_txt.Text + "'", con);
            try {
                AdresLocatie adl = new AdresLocatie(1, 12546.0, 123654.5);
                Adres abc = new Adres(Int32.Parse(id_txt.Text), Int32.Parse(Straat_txt.Text), Huisnr_txt.Text, Busnr_txt.Text, Appnr_txt.Text, Huislbl_txt.Text,
                   adl, Int32.Parse(postcode_txt.Text));
                bv.UpdateAdres(abc);
                LoadGrid();
                //cmd.ExecuteNonQuery();
                MessageBox.Show("Adres gewijzigd", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
            } catch (SqlException ex) {

                MessageBox.Show("Niet gelukt", ex.Message);
            } finally {
                //con.Close();
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
        private void Button_Click_Terug(object sender, RoutedEventArgs e) {
            MainWindow aw = new MainWindow();
            aw.Show();
            this.Close();
        }

    }
}
