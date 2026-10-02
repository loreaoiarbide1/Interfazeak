using System.Text;
using System.Text.RegularExpressions;
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
            TxtNAN.PreviewTextInput += TxtNAN_PreviewTextInput;
            DataObject.AddPastingHandler(TxtNAN, TxtNAN_PasteHandler);
        }

        private void TxtNAN_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Zenbakiak eta letrak baino ez ditu onartzen
            if (!char.IsLetterOrDigit(e.Text, 0))
            {
                e.Handled = true;
                return;
            }

            // Ez du 9 karakteretik gehiago onartzen
            if (TxtNAN.Text.Length >= 9)
            {
                e.Handled = true;
            }
        }

        private void TxtNAN_PasteHandler(object sender, DataObjectPastingEventArgs e)
        {
            // Edukia zein baliozkoa ez den pegatzea debekatzen du
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string text = (string)e.DataObject.GetData(typeof(string));
                if (!NANBaliozkoa(text))
                {
                    e.CancelCommand();
                }
            }
        }

        private bool NANBaliozkoa(string nan)
        {
            // Baliozkoa: 8 zenbaki + 1 letra (guztira 9 karaktere)
            return Regex.IsMatch(nan, @"^\d{8}[a-zA-Z]$");
        }

        private void BtnOnartu_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtIzena.Text) || string.IsNullOrWhiteSpace(TxtAbizena1.Text) || string.IsNullOrWhiteSpace(TxtAbizena2.Text) || string.IsNullOrWhiteSpace(TxtNAN.Text))
            {
                MessageBox.Show("Mesedez, bete datu guztiak.");
                return;
            }

            if (!NANBaliozkoa(TxtNAN.Text))
            {
                MessageBox.Show("NAN ez da baliozkoa. Mesedez, sartu 8 zenbaki eta 1 letra.");
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

            if (!NANBaliozkoa(TxtNAN.Text))
            {
                MessageBox.Show("NAN ez da baliozkoa. Mesedez, sartu 8 zenbaki eta letra 1.");
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