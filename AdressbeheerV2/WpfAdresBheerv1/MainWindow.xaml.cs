using ClassLibrary1;
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

namespace WpfAdresBheerv1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Btn_Click_Gemeente(object sender, RoutedEventArgs e) {
            Gemeentewpf gem = new Gemeentewpf();
            gem.Show();
            this.Close();
        }

        private void Btn_Click_Adres(object sender, RoutedEventArgs e) {
            Adreswpf ads = new Adreswpf();
            ads.Show();
            this.Close();
        }

        private void Btn_Click_Straat(object sender, RoutedEventArgs e) {
            Straatwpf adst = new Straatwpf();
            adst.Show();
            this.Close();
        }

        private void Btn_Click_Locatie(object sender, RoutedEventArgs e) {
            Adreslocatiewpf adstL = new Adreslocatiewpf();
            adstL.Show();
            this.Close();
        }

    }
}
