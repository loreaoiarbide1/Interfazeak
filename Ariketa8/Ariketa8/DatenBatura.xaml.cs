using System;
using System.Windows;
using System.Globalization;

namespace Ariketa8
{
    public partial class DatenBatura : Window
    {
        public DateTime DataHasierakoa { get; set; }
        public DateTime EmaitzaBatura { get; set; }
        public int HilabeteKopurua { get; set; }
        private DateTime Sartutakodata;

        public DatenBatura()
        {
            InitializeComponent();
        }

        private void btnOnartu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtHasierakoa.Text))
                {
                    ErroreaErakutsi("Mesedez, sartu hasierako data (dd/MM/yyyy formatuan).");
                    return;
                }

                CultureInfo culture = CultureInfo.InvariantCulture;
                if (!DateTime.TryParseExact(txtHasierakoa.Text, "dd/MM/yyyy", culture, DateTimeStyles.None, out DateTime hasierakoa))
                {
                    ErroreaErakutsi("Dataren formatua ez da zuzena. Erabili dd/MM/yyyy formatua.\nAdibidez: 23/09/2026");
                    return;
                }

                Sartutakodata = hasierakoa;
                DataHasierakoa = hasierakoa;

                panel1HasierakoDataEskatu.Visibility = Visibility.Hidden;
                panel2HilabeteakEskatu.Visibility = Visibility.Visible;
                lblSartutakoData.Content = "Data sartu: " + hasierakoa.ToString("dd/MM/yyyy");
                txtHilabeteak.Clear();
                txtHilabeteak.Focus();
            }
            catch (Exception ex)
            {
                ErroreaErakutsi("Errore bat gertatu da: " + ex.Message);
            }
        }

        private void btnOnartu2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtHilabeteak.Text))
                {
                    ErroreaErakutsi("Mesedez, sartu hilabete kopurua.");
                    return;
                }

                if (!int.TryParse(txtHilabeteak.Text, out int hilabeteak))
                {
                    ErroreaErakutsi("Hilabete kopurua zenbaki bat izan behar da.");
                    return;
                }

                DateTime emaitza = Sartutakodata.AddMonths(hilabeteak);
                EmaitzaBatura = emaitza;
                HilabeteKopurua = hilabeteak;

                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                ErroreaErakutsi("Errore bat gertatu da: " + ex.Message);
            }
        }

        private void btnAtzera_Click(object sender, RoutedEventArgs e)
        {
            panel2HilabeteakEskatu.Visibility = Visibility.Hidden;
            panel1HasierakoDataEskatu.Visibility = Visibility.Visible;
            txtHilabeteak.Clear();
            txtHasierakoa.Focus();
        }

        private void btnUtzi_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void ErroreaErakutsi(string mezua)
        {
            MessageBox.Show(mezua, "Errorea", MessageBoxButton.OK, MessageBoxImage.Error);

            if (panel1HasierakoDataEskatu.Visibility == Visibility.Visible)
            {
                txtHasierakoa.Clear();
                txtHasierakoa.Focus();
            }
            else if (panel2HilabeteakEskatu.Visibility == Visibility.Visible)
            {
                txtHilabeteak.Clear();
                txtHilabeteak.Focus();
            }
        }
    }
}
