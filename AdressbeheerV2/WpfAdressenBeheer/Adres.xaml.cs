using System;
using System.Collections.Generic;
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
using System.Data;
using System.Data.SqlClient;

namespace WpfAdresBeheer {
    /// <summary>
    /// Interaction logic for Adres.xaml
    /// </summary>
    public partial class Adres : Window {
        SqlConnection scl = new SqlConnection(@"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True");




        public Adres() {
            InitializeComponent();
            string connectionString = @"Data Source=LAPTOP-6SGVUNSR\SQLEXPRESS;Initial Catalog=SqlAdres;Integrated Security=True";
            SqlConnection scl = new SqlConnection(connectionString);
            string query = "SELECT TOP (1000) [id],[straatID],[huisnummer],[appartementnummer],[busnummer],[huisnummerlabel],[adreslocatieID],[postcode]FROM dbo.adres";
            SqlCommand cmd = scl.CreateCommand();
            scl.Open();
            cmd.CommandText = query;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            datagrid.DataContext = dt;
            scl.Close();
        }
        private void btn_Open_Main(object sender, RoutedEventArgs e) {
            MainWindow aw = new MainWindow();
            aw.Show();
            this.Close();
        }
    }
}
