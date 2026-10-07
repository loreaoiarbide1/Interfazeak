
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
            cmbLehentasuna.SelectedItem = Lehentasuna.Ertaina;
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
            // BALIDAZIOAK
            if (string.IsNullOrWhiteSpace(txtIzenburua.Text))
            {
                MessageBox.Show("Izenburua ezin da hutsik egon.", "Balidazio-errorea", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtIzenburua.Focus();
                return;
            }

            if (!dpMugaEguna.SelectedDate.HasValue)
            {
                MessageBox.Show("Mesedez, hautatu azken eguna.", "Balidazio-errorea", MessageBoxButton.OK, MessageBoxImage.Warning);
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