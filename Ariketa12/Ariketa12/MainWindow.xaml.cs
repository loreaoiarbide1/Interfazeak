using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ariketa12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Prezioak konstanteak
        private const decimal Gosaria = 3m;
        private const decimal Bazkaria = 9m;
        private const decimal Afaria = 15.5m;
        private const decimal Km = 0.25m;
        private const decimal Bidaia_ordua = 18m;
        private const decimal Lanordua = 42m;

        public MainWindow()
        {
            InitializeComponent();
            OsatuKontrolak();
            EnlazarEventuak();
        }

        private void OsatuKontrolak()
        {
            // Kalkuluak - TextBox-ak (irakurgai)
            TxtDietakPrezioa.Text = "0,00 €";
            TxtBidaiakPrezioa.Text = "0,00 €";
            TxtLanaPrezioa.Text = "0,00 €";
            TxtPrezioaGuztira.Text = "0,00 €";
        }

        private void EnlazarEventuak()
        {
            // CheckBox-ak
            chkGosaria.Checked += (s, e) => Kalkulatu();
            chkGosaria.Unchecked += (s, e) => Kalkulatu();
            chkBazkaria.Checked += (s, e) => Kalkulatu();
            chkBazkaria.Unchecked += (s, e) => Kalkulatu();
            chkAfaria.Checked += (s, e) => Kalkulatu();
            chkAfaria.Unchecked += (s, e) => Kalkulatu();

            // TextBox-ak - KeyDown Intro teklaren arabera
            txtKm.KeyDown += TextBox_KeyDown;
            txtBidaiaOrdua.KeyDown += TextBox_KeyDown;
            txtLanaOrdua.KeyDown += TextBox_KeyDown;

            // TextBox-ak - PreviewTextInput (Balidazioa zenbakiak bakarrik onartu)
            txtKm.PreviewTextInput += TextBox_PreviewTextInput;
            txtBidaiaOrdua.PreviewTextInput += TextBox_PreviewTextInput;
            txtLanaOrdua.PreviewTextInput += TextBox_PreviewTextInput;

            // TextBox-ak - TextChanged
            txtKm.TextChanged += (s, e) => Kalkulatu();
            txtBidaiaOrdua.TextChanged += (s, e) => Kalkulatu();
            txtLanaOrdua.TextChanged += (s, e) => Kalkulatu();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                // Mugitu fokusa hurrengo kontrolera
                if (sender is TextBox textBox)
                {
                    textBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                }
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Bakarrik dezimalak eta puntu bat onartu
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void Kalkulatu()
        {
            try
            {
                // Dietak kalkulatu
                decimal dietakPrezioa = 0m;
                if (chkGosaria.IsChecked == true)
                {

                    dietakPrezioa += Gosaria;
                }
                if (chkBazkaria.IsChecked == true)
                    dietakPrezioa += Bazkaria;
                if (chkAfaria.IsChecked == true)
                    dietakPrezioa += Afaria;

                TxtDietakPrezioa.Text = dietakPrezioa.ToString("0.00 €");

                // Bidaiak kalkulatu
                decimal bidaiakPrezioa = 0m;
                if (decimal.TryParse(txtKm.Text, out decimal kmKopurua))
                    bidaiakPrezioa += kmKopurua * Km;

                if (decimal.TryParse(txtBidaiaOrdua.Text, out decimal bidaiaOrdua))
                    bidaiakPrezioa += bidaiaOrdua * Bidaia_ordua;

                TxtBidaiakPrezioa.Text = bidaiakPrezioa.ToString("0.00 €");

                // Lana kalkulatu
                decimal lanaPrezioa = 0m;
                if (decimal.TryParse(txtLanaOrdua.Text, out decimal lanaOrdua))
                    lanaPrezioa = lanaOrdua * Lanordua;

                TxtLanaPrezioa.Text = lanaPrezioa.ToString("0.00 €");

                // Guztira
                decimal guztira = dietakPrezioa + bidaiakPrezioa + lanaPrezioa;
                TxtPrezioaGuztira.Text = guztira.ToString("0.00 €");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Akats bat gertatu da: {ex.Message}", "Errorea", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnGarbitu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                chkGosaria.IsChecked    =   false;
                chkBazkaria.IsChecked   =   false;
                chkAfaria.IsChecked     =   false;

                txtKm.Clear();
                txtBidaiaOrdua.Clear();
                txtLanaOrdua.Clear();

                TxtDietakPrezioa.Text   =   "0,00 €";
                TxtBidaiakPrezioa.Text  =   "0,00 €";
                TxtLanaPrezioa.Text     =   "0,00 €";
                TxtPrezioaGuztira.Text  =   "0,00 €";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Akats bat gertatu da garbitzerakoan: {ex.Message}", "Errorea", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnIrten_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Akats bat gertatu da irteterakoan: {ex.Message}", "Errorea", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}