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

namespace Ariketa8
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

        private void btnGarbitu_Click(object sender, RoutedEventArgs e)
        {
            txtDataOrain.Clear();
            txtDataGaur.Clear();
            txtDataGaurkoOrdua.Clear();
            txtDatenBatura.Clear();
            txtDatenAldea.Clear();
        }

        private void btnIrten_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        } 
        
        private void btnExekutatu_Click(object sender, RoutedEventArgs e)
        {
            DateTime dataOrain = DateTime.Now;
            txtDataOrain.Text = dataOrain.ToString("dd/MM/yyyy HH:mm:ss");
            
            DateTime dataGaur = new DateTime(dataOrain.Year, dataOrain.Month, dataOrain.Day);
            txtDataGaur.Text = dataGaur.ToString("dd/MM/yyyy");
            
            txtDataGaurkoOrdua.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void txtDatenBatura_MouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            try
            {
                DatenBatura leihoa = new DatenBatura();
                leihoa.Owner = this;
                if (leihoa.ShowDialog() == true)
                {
                    string emaitza = $"Hasierako data: {leihoa.DataHasierakoa:dd/MM/yyyy}\n" +
                                       $"Gehitutako hilabeteak: {leihoa.HilabeteKopurua}\n" +
                                       $"Data berria: {leihoa.EmaitzaBatura:dd/MM/yyyy}";
                    txtDatenBatura.Text = emaitza;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea: " + ex.Message, "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtDatenAldea_MouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            try
            {
                DatenAldea leihoa = new DatenAldea();
                leihoa.Owner = this;
                if (leihoa.ShowDialog() == true)
                {
                    string emaitza = $"Hasierako data: {leihoa.DataHasierakoa:dd/MM/yyyy}\n" +
                                       $"Amaierako data: {leihoa.DataAmaierakoa:dd/MM/yyyy}\n" +
                                       $"Aldea: {leihoa.EmaitzaEgunak} egun";
                    txtDatenAldea.Text = emaitza;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea: " + ex.Message, "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}