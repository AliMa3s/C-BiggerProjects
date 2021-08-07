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

namespace WpfAdresBeheer {
    /// <summary>
    /// Interaction logic for Gemeente.xaml
    /// </summary>
    public partial class Gemeente : Window {
        public Gemeente() {
            InitializeComponent();
        }
        private void btn_Open_Main(object sender, RoutedEventArgs e) {
            MainWindow aw = new MainWindow();
            aw.Show();
            this.Close();
        }
    }
}
