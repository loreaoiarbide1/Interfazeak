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

namespace Ariketa3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int zenb1, zenb2, zenb3, zenb4;
        private int oraingoZenbakia = 1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnHurrengoa_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtZenbakia.Text))
            {
                MessageBox.Show("Mesedez, zenbakia sartu", "Errorea", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (int.TryParse(txtZenbakia.Text, out int zenbakia))
            {
                ZenbakiaGorde(zenbakia);

                if (oraingoZenbakia < 4)
                {
                    oraingoZenbakia++;
                    PantailaKargatu();
                }
                else
                {
                    EmaitzaErakutsi();
                }
            }
            else
            {
                MessageBox.Show("Zenbaki baliogarria sartu behar da", "Errorea", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ZenbakiaGorde(int zenbakia)
        {
            switch (oraingoZenbakia)
            {
                case 1:
                    zenb1 = zenbakia;
                    break;
                case 2:
                    zenb2 = zenbakia;
                    break;
                case 3:
                    zenb3 = zenbakia;
                    break;
                case 4:
                    zenb4 = zenbakia;
                    break;
            }
        }

        private void PantailaKargatu()
        {
            lblZenbakia.Content = $"{oraingoZenbakia}. zenbakia";
            txtZenbakia.Clear();
            txtZenbakia.Focus();
        }

        private void EmaitzaErakutsi()
        {
            double emaitza = (zenb1 + (zenb1 * zenb2) + (zenb2 * zenb3) + (zenb3 * zenb4)) / 4.0;

            EmaitzaWindow lehioEmaitza = new EmaitzaWindow(emaitza);
            lehioEmaitza.Show();
            this.Close();
        }

        private void btnGarbitu_Click(object sender, RoutedEventArgs e)
        {
            oraingoZenbakia = 1;
            zenb1 = zenb2 = zenb3 = zenb4 = 0;
            PantailaKargatu();
            btnGarbitu.Visibility = Visibility.Collapsed;
            btnHurrengoa.Visibility = Visibility.Visible;
        }

        private void btnIrten_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
    }
}