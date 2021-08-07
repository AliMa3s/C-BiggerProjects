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

namespace WpfAdresBeheer {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void btn_Open_Adres(object sender, RoutedEventArgs e) {
            Adres aw = new Adres();
            aw.Show();
            this.Close();
        }

        private void btn_Open_Gemeente(object sender, RoutedEventArgs e) {
            Gemeente aw = new Gemeente();
            aw.Show();
            this.Close();
        }

        private void btn_Open_Straat(object sender, RoutedEventArgs e) {
            Straat aw = new Straat();
            aw.Show();
            this.Close();
        }
        private void btn_Open_AdresLocatie(object sender, RoutedEventArgs e) {
            AdresLocatie aw = new AdresLocatie();
            aw.Show();
            this.Close();
        }
    }


}
