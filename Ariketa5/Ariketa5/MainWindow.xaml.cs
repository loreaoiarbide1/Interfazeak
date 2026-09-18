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

namespace Ariketa5
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

        private void btnComicSans_Click(object sender, RoutedEventArgs e)
        {
            if (txtTestua != null)
            {
                txtTestua.FontFamily = new FontFamily("Comic Sans MS");
            }

        }

        private void btnLodia_Click(object sender, RoutedEventArgs e)
        {
            if (txtTestua != null)
            {
                txtTestua.FontWeight = FontWeights.Bold;
            }

        }

        private void btnMarratua_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTamainaGehiago_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCourier_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEtzana_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAzpimarratua_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTamainaGutxiago_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnHautatu_Click(object sender, RoutedEventArgs e)
        {


        }

        private void btnIrten_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
    }
}