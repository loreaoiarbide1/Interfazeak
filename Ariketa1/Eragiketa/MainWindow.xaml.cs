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

namespace Eragiketa
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

        private void btnKalkulatu_Click(object sender, RoutedEventArgs e)
        {
            ClearErrors();

            bool baliozkoa = true;

            if (string.IsNullOrWhiteSpace(txtLehengoZenbakia.Text))
            {
                errLehengoZenbakia.Visibility = Visibility.Visible;
                baliozkoa = false;
            }

            if (string.IsNullOrWhiteSpace(txtBigarrenZenbakia.Text))
            {
                errBigarrenZenbakia.Visibility = Visibility.Visible;
                baliozkoa = false;
            }

            if (string.IsNullOrWhiteSpace(txtHirugarrenZenbakia.Text))
            {
                errHirugarrenZenbakia.Visibility = Visibility.Visible;
                baliozkoa = false;
            }

            if (string.IsNullOrWhiteSpace(txtLaugarrenZenbakia.Text))
            {
                errLaugarrenZenbakia.Visibility = Visibility.Visible;
                baliozkoa = false;
            }

            if (!baliozkoa)
            {
                
                return;
            }
          
            if (!double.TryParse(txtLehengoZenbakia.Text, out double lehengoZenbakia))
            {
                errLehengoZenbakia.Text = "Sartu baliozko zenbaki bat.";
                errLehengoZenbakia.Visibility = Visibility.Visible;
                return;
            }

            if (!double.TryParse(txtBigarrenZenbakia.Text, out double bigarrenZenbakia))
            {
                errBigarrenZenbakia.Text = "Sartu baliozko zenbaki bat.";
                errBigarrenZenbakia.Visibility = Visibility.Visible;
                return;
            }

            if (!double.TryParse(txtHirugarrenZenbakia.Text, out double hirugarrenZenbakia))
            {
                errHirugarrenZenbakia.Text = "Sartu baliozko zenbaki bat.";
                errHirugarrenZenbakia.Visibility = Visibility.Visible;
                return;
            }

            if (!double.TryParse(txtLaugarrenZenbakia.Text, out double laugarrenZenbakia))
            {
                errLaugarrenZenbakia.Text = "Sartu baliozko zenbaki bat.";
                errLaugarrenZenbakia.Visibility = Visibility.Visible;
                return;
            }

            double emaitza = (lehengoZenbakia + bigarrenZenbakia + hirugarrenZenbakia + laugarrenZenbakia) / 4;
            txtEmaitza.Text = emaitza.ToString();
        }

        private void btnGarbitu_Click(object sender, RoutedEventArgs e)
        {
            txtLehengoZenbakia.Clear();
            txtBigarrenZenbakia.Clear();
            txtHirugarrenZenbakia.Clear();
            txtLaugarrenZenbakia.Clear();
            txtEmaitza.Clear();

            ClearErrors();

            txtLehengoZenbakia.Focus();
        }

        private void txtZenbakiak_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Blokeatu karaktere ez-numerikoak eta puntu bakarra
            if (!char.IsDigit(e.Text[0]) && e.Text[0] != '.')
            {
                e.Handled = true;
                return;
            }

            // Baimendu puntu bakarra
            if (e.Text[0] == '.' && txt.Text.Contains('.'))
            {
                e.Handled = true;
            }
        }

        private void btnIrten_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ClearErrors()
        {
            errLehengoZenbakia.Text = "Derrigorrezkoa / Sartu baliozko zenbaki bat.";
            errLehengoZenbakia.Visibility = Visibility.Collapsed;

            errBigarrenZenbakia.Text = "Derrigorrezkoa / Sartu baliozko zenbaki bat.";
            errBigarrenZenbakia.Visibility = Visibility.Collapsed;

            errHirugarrenZenbakia.Text = "Derrigorrezkoa / Sartu baliozko zenbaki bat.";
            errHirugarrenZenbakia.Visibility = Visibility.Collapsed;

            errLaugarrenZenbakia.Text = "Derrigorrezkoa / Sartu baliozko zenbaki bat.";
            errLaugarrenZenbakia.Visibility = Visibility.Collapsed;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender == txtLehengoZenbakia)
            {
                errLehengoZenbakia.Visibility = Visibility.Collapsed;
                errLehengoZenbakia.Text = "Derrigorrezkoa / Sartu baliozko zenbaki bat.";
            }
            else if (sender == txtBigarrenZenbakia)
            {
                errBigarrenZenbakia.Visibility = Visibility.Collapsed;
                errBigarrenZenbakia.Text = "Derrigorrezkoa / Sartu baliozko zenbaki bat.";
            }
            else if (sender == txtHirugarrenZenbakia)
            {
                errHirugarrenZenbakia.Visibility = Visibility.Collapsed;
                errHirugarrenZenbakia.Text = "Derrigorrezkoa / Sartu baliozko zenbaki bat.";
            }
            else if (sender == txtLaugarrenZenbakia)
            {
                errLaugarrenZenbakia.Visibility = Visibility.Collapsed;
                errLaugarrenZenbakia.Text = "Derrigorrezkoa / Sartu baliozko zenbaki bat.";
            }
        }
    }
}