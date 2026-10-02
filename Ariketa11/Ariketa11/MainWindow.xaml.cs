using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ariketa11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnOnartu_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtIzena.Text) || string.IsNullOrWhiteSpace(TxtAbizena1.Text) || string.IsNullOrWhiteSpace(TxtAbizena2.Text) || string.IsNullOrWhiteSpace(TxtNAN.Text))
            {
                MessageBox.Show("Mesedez, bete datu guztiak.");
                return;
            }
            DatuGlobalak.Izena = TxtIzena.Text;
            DatuGlobalak.Abizena1 = TxtAbizena1.Text;
            DatuGlobalak.Abizena2 = TxtAbizena2.Text;
            DatuGlobalak.NAN = TxtNAN.Text;
            MessageBox.Show("Datuak ondo gorde dira.");
        }

        private void BtnKargatuErakutsi_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtIzena.Text) || string.IsNullOrWhiteSpace(TxtAbizena1.Text) || string.IsNullOrWhiteSpace(TxtAbizena2.Text) || string.IsNullOrWhiteSpace(TxtNAN.Text))
            {
                MessageBox.Show("Mesedez, bete datu guztiak.");
                return;
            }

            // Datuak gordetzen dira klase estatikoan
            DatuGlobalak.Izena = TxtIzena.Text;
            DatuGlobalak.Abizena1 = TxtAbizena1.Text;
            DatuGlobalak.Abizena2 = TxtAbizena2.Text;
            DatuGlobalak.NAN = TxtNAN.Text;

            // DatuakBistaratu leihoa erakusten da
            DatuakBistaratu leihoa = new DatuakBistaratu();
            leihoa.Show();
        }

        private void BtnIrten_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}