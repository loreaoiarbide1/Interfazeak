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

namespace Ariketa9
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

        private void btnGehitu_Click(object sender, RoutedEventArgs e)
        {
            var izena = txtLagunBerria.Text?.Trim();
            if (string.IsNullOrWhiteSpace(izena))
            {
                MessageBox.Show("Mesedez, sartu izen bat.", "Errorea", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtLagunBerria.Focus();
                return;
            }

            LBoxLagunak.Items.Add(izena);
            txtLagunBerria.Clear();
            txtLagunBerria.Focus();
        }

        private void btnEzabatu_Click(object sender, RoutedEventArgs e)
        {
            if (LBoxLagunak.SelectedItem == null)
            {
                MessageBox.Show("Ez dago hautatutako elementurik.", "Errorea", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var kentzeko = LBoxLagunak.SelectedItem;
            LBoxLagunak.Items.Remove(kentzeko);

            if (txtHautatutakoLaguna.Text == kentzeko.ToString())
            {
                txtHautatutakoLaguna.Clear();
            }
        }

        private void btnZerrendaGarbitu_Click(object sender, RoutedEventArgs e)
        {
            LBoxLagunak.Items.Clear();
            txtHautatutakoLaguna.Clear();
        }

        private void LBoxLagunak_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (LBoxLagunak.SelectedItem != null)
            {
                txtHautatutakoLaguna.Text = LBoxLagunak.SelectedItem.ToString();
            }
        }
    }
}