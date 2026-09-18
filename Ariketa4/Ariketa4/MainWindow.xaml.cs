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

namespace Ariketa4
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

        private void btnIrten_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void btnOnartu_Click(object sender, RoutedEventArgs e)
        {
            string erabiltzailea = txtErabiltzailea.Text;
            string pasahitza = pwdPasahitza.Password;
            if (erabiltzailea == "admin" && pasahitza == "admin")
            {
                MessageBox.Show("Ongi etorri, " + erabiltzailea + "!");
            }
            else
            {
                MessageBox.Show("Erabiltzaile edo pasahitz okerra.");
            }

        }

        private void btnGarbitu_Click(object sender, RoutedEventArgs e)
        {
            txtErabiltzailea.Clear();
            pwdPasahitza.Clear();
        }
    }
}