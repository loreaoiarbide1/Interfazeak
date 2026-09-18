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
            double lehengoZenbakia = double.Parse(txtLehengoZenbakia.Text);
            double bigarrenZenbakia = double.Parse(txtBigarrenZenbakia.Text);
            double hirugarrenZenbakia = double.Parse(txtHirugarrenZenbakia.Text);
            double laugarrenZenbakia = double.Parse(txtLaugarrenZenbakia.Text);
            double emaitza = (lehengoZenbakia + bigarrenZenbakia + hirugarrenZenbakia + laugarrenZenbakia)/4;
            txtEmaitza.Text = emaitza.ToString();


        }

        private void btnGarbitu_Click(object sender, RoutedEventArgs e)
        {
            txtLehengoZenbakia.Clear();
            txtBigarrenZenbakia.Clear();
            txtHirugarrenZenbakia.Clear();
            txtLaugarrenZenbakia.Clear();
            txtEmaitza.Clear();

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
    }
}

