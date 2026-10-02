using System.Windows;

namespace Ariketa11
{
    public partial class DatuakBistaratu : Window
    {
        public DatuakBistaratu()
        {
            InitializeComponent();
            KargatuDatuak();
        }

        private void KargatuDatuak()
        {
            TxtBIzena.Text = DatuGlobalak.Izena;
            TxtBAbizena1.Text = DatuGlobalak.Abizena1;
            TxtBAbizena2.Text = DatuGlobalak.Abizena2;
            TxtBNAN.Text = DatuGlobalak.NAN;
        }

        private void BtnIrten_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}