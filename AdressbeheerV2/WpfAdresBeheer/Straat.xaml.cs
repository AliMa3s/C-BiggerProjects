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
    /// Interaction logic for Straat.xaml
    /// </summary>
    public partial class Straat : Window {
        public Straat() {
            InitializeComponent();
            LoadGrid();
        }
        public void ClearVelden() {
            niscode_txt.Clear();
            straat_txt.Clear();
            id_txt.Clear();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True");

        private void btnClear_Click(object sender, RoutedEventArgs e) {
            ClearVelden();
        }


        public bool isValid() {
            if (niscode_txt.Text == string.Empty) {
                MessageBox.Show("Niscode is leeg", " ", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (straat_txt.Text == string.Empty) {
                MessageBox.Show("Straatnaam is leeg", " ", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (id_txt.Text == string.Empty) {
                MessageBox.Show("Id is leeg", " ", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void Btn_Insert_Click(object sender, RoutedEventArgs e) {
            try {

                if (isValid()) {


                    //public Adres(int id, string huisNummer, string busnummer, string appNummer, string huisNummerLabel)
                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.straat VALUES(@id, @straatnaam,  @Niscode)", con);




                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Niscode", niscode_txt.Text);
                    cmd.Parameters.AddWithValue("@straatnaam", straat_txt.Text);
                    cmd.Parameters.AddWithValue("@id", id_txt.Text);

                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                    LoadGrid();
                    MessageBox.Show("Straat Toegevoegd", "Opgeslaan", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            } catch (SqlException ex) {

                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_VerwijderStraat_Click(object sender, RoutedEventArgs e) {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from dbo.straat where id = " + id_txt.Text + " ", con);
            try {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Straat is verwijdered", "Verwijderd", MessageBoxButton.OK, MessageBoxImage.Information);
                con.Close();
                LoadGrid();
                con.Close();
            } catch (SqlException ex) {

                MessageBox.Show("Niet Verwijderd " + ex.Message);
            } finally {
                con.Close();
            }
        }

        public void LoadGrid() {
            SqlCommand cmd = new SqlCommand("Select TOP 1000 * FROM dbo.straat", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }

        private void Btn_Update_Click(object sender, RoutedEventArgs e) {
            con.Open();
            SqlCommand cmd = new SqlCommand("Update dbo.straat set straatnaam = '" + straat_txt.Text + "'  Where id = '" + id_txt.Text + "'", con);
            try {

                cmd.ExecuteNonQuery();
                MessageBox.Show("Straat gewijzigd", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
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
