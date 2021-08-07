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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace WpfAdresBeheer {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

        }



        private void Btn_Click_Gemeente(object sender, RoutedEventArgs e) {
            Gemeente asd = new Gemeente();
            asd.Show();
            this.Close();
        }

        private void Btn_Click_Adres(object sender, RoutedEventArgs e) {
            Adres ads = new Adres();
            ads.Show();
            this.Close();
        }

        private void Btn_Click_Straat(object sender, RoutedEventArgs e) {
            Straat adst = new Straat();
            adst.Show();
            this.Close();
        }

        private void Btn_Click_Locatie(object sender, RoutedEventArgs e) {
            AdresLocatie adstL = new AdresLocatie();
            adstL.Show();
            this.Close();
        }
    }
}
