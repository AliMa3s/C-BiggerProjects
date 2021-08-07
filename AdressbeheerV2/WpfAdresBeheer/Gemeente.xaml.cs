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

namespace WpfAdresBeheer {
    /// <summary>
    /// Interaction logic for Gemeente.xaml
    /// </summary>
    public partial class Gemeente : Window {
        public Gemeente() {
            InitializeComponent();
            LoadGrid();
        }

        public void ClearVelden() {
            niscode_txt.Clear();
            gemeente_txt.Clear();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True");

        private void btnClear_Click(object sender, RoutedEventArgs e) {
            ClearVelden();
        }
        public void LoadGrid() {
            SqlCommand cmd = new SqlCommand("Select TOP 1000 * FROM dbo.gemeente", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }
        public bool isValid() {
            if (niscode_txt.Text == string.Empty) {
                MessageBox.Show("Niscode is leeg", " ", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (gemeente_txt.Text == string.Empty) {
                MessageBox.Show("Gemeentenaam is leeg", " ", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void Btn_Insert_Click(object sender, RoutedEventArgs e) {
            try {

                if (isValid()) {
                    //public Adres(int id, string huisNummer, string busnummer, string appNummer, string huisNummerLabel)
                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.gemeente VALUES(@Niscode, @gemeentenaam)", con);




                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Niscode", niscode_txt.Text);
                    cmd.Parameters.AddWithValue("@gemeentenaam", gemeente_txt.Text);

                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                    LoadGrid();
                    MessageBox.Show("Gemeente Toegevoegd", "Opgeslaan", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            } catch (SqlException ex) {

                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_VerwijderGem_Click(object sender, RoutedEventArgs e) {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from dbo.gemeente where Niscode = " + niscode_txt.Text + " ", con);
            try {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Gemeente is verwijdered", "Verwijderd", MessageBoxButton.OK, MessageBoxImage.Information);
                con.Close();
                LoadGrid();
                con.Close();
            } catch (SqlException ex) {

                MessageBox.Show("Niet Verwijderd " + ex.Message);
            } finally {
                con.Close();
            }
        }



        private void Btn_Update_Click(object sender, RoutedEventArgs e) {
            con.Open();
            SqlCommand cmd = new SqlCommand("Update dbo.gemeente set gemeentenaam = '" + gemeente_txt.Text + "'  Where Niscode = '" + niscode_txt.Text + "'", con);
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

        private void Button_Click_Terug(object sender, RoutedEventArgs e) {
            MainWindow aw = new MainWindow();
            aw.Show();
            this.Close();
        }

    }
}
