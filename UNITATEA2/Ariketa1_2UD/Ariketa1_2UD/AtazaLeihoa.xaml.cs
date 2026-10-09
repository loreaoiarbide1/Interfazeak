
using System;
using System.Windows;

namespace Ariketa1_2UD
{
    public partial class AtazaLeihoa : Window
    {
        public Ataza AtazaAukeratua { get; private set; }

        // Sortzeko eraikitzailea (Berria)
        public AtazaLeihoa()
        {
            InitializeComponent();
            cmbLehentasuna.ItemsSource = Enum.GetValues(typeof(Lehentasuna));
            cmbLehentasuna.SelectedItem = Lehentasuna.Baxua;

            // Egutegian gaurko data baino lehenagoko egunak desaktibatuta hautatu ezin izateko
            dpMugaEguna.DisplayDateStart = DateTime.Today;
            dpMugaEguna.SelectedDate = DateTime.Today;
        }

        // Editatzeko eraikitzailea (Editatu)
        public AtazaLeihoa(Ataza ataza) : this()
        {
            AtazaAukeratua = ataza;
            txtIzenburua.Text = ataza.Izenburua;
            cmbLehentasuna.SelectedItem = ataza.Lehentasuna;
            dpMugaEguna.SelectedDate = ataza.MugaEguna;
            chkEginda.IsChecked = ataza.Eginda;
        }

        private void btnGorde_Click(object sender, RoutedEventArgs e)
        {
            // Izenburua ezin da hutsik egon
            if (string.IsNullOrWhiteSpace(txtIzenburua.Text))
            {
                MessageBox.Show("Izenburua ezin da hutsik egon.", "Balidazio-errorea", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtIzenburua.Focus();
                return;
            }

            // Data hautatuta egon behar da
            if (!dpMugaEguna.SelectedDate.HasValue)
            {
                MessageBox.Show("Mesedez, hautatu azken eguna.", "Balidazio-errorea", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Muga-eguna gaur edo ondorengoa izan behar da (muga-eguna ≥ gaur)
            if (dpMugaEguna.SelectedDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Muga-egunak gaurkoa edo ondorengoa izan behar du.", "Balidazio-errorea", MessageBoxButton.OK, MessageBoxImage.Warning);
                dpMugaEguna.Focus();
                return;
            }

            // Datuak gorde
            if (AtazaAukeratua == null)
            {
                AtazaAukeratua = new Ataza();
            }

            AtazaAukeratua.Izenburua = txtIzenburua.Text.Trim();
            AtazaAukeratua.Lehentasuna = (Lehentasuna)cmbLehentasuna.SelectedItem;
            AtazaAukeratua.MugaEguna = dpMugaEguna.SelectedDate.Value;
            AtazaAukeratua.Eginda = chkEginda.IsChecked ?? false;

            DialogResult = true;
        }
    }
}