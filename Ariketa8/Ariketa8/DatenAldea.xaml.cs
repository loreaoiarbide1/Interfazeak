using System;
using System.Windows;
using System.Globalization;

namespace Ariketa8
{
    public partial class DatenAldea : Window
    {
        public int EmaitzaEgunak { get; set; }
        public DateTime DataHasierakoa { get; set; }
        public DateTime DataAmaierakoa { get; set; }
        private DateTime hasierakoa;

        public DatenAldea()
        {
            InitializeComponent();
        }

        private void btnAurrera_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtHasierakoa.Text))
                {
                    ErroreaErakutsi("Mesedez, sartu hasierako data (dd/MM/yyyy formatuan).");
                    return;
                }

                CultureInfo culture = CultureInfo.InvariantCulture;
                if (!DateTime.TryParseExact(txtHasierakoa.Text, "dd/MM/yyyy", culture, DateTimeStyles.None, out DateTime hasiera))
                {
                    ErroreaErakutsi("Dataren formatua ez da zuzena. Erabili dd/MM/yyyy formatua.\nAdibidez: 23/09/2026");
                    return;
                }

                hasierakoa = hasiera;

                panel1HasierakoDataEskatu.Visibility = Visibility.Hidden;
                panel2HilabeteakEskatu.Visibility = Visibility.Visible;
                lblDataHasierakoa.Content = "Hasierako data: " + hasierakoa.ToString("dd/MM/yyyy");
                txtAmaierakoa.Clear();
                txtAmaierakoa.Focus();
            }
            catch (Exception ex)
            {
                ErroreaErakutsi("Errore bat gertatu da: " + ex.Message);
            }
        }

        private void btnOnartu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtAmaierakoa.Text))
                {
                    ErroreaErakutsi("Mesedez, sartu amaierako data (dd/MM/yyyy formatuan).");
                    return;
                }

                CultureInfo culture = CultureInfo.InvariantCulture;
                if (!DateTime.TryParseExact(txtAmaierakoa.Text, "dd/MM/yyyy", culture, DateTimeStyles.None, out DateTime amaiera))
                {
                    ErroreaErakutsi("Dataren formatua ez da zuzena. Erabili dd/MM/yyyy formatua.\nAdibidez: 23/09/2026");
                    return;
                }

                if (hasierakoa > amaiera)
                {
                    ErroreaErakutsi("Hasierako data amaierako data baino lehenagoa izan behar da.");
                    return;
                }

                TimeSpan aldea = amaiera - hasierakoa;

                DataHasierakoa = hasierakoa;
                DataAmaierakoa = amaiera;
                EmaitzaEgunak = aldea.Days;

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
            txtAmaierakoa.Clear();
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
                txtAmaierakoa.Clear();
                txtAmaierakoa.Focus();
            }
        }
    }
}