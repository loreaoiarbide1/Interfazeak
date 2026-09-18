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
            UpdateValidation();
        }

        private void btnIrten_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void btnOnartu_Click(object sender, RoutedEventArgs e)
        {
            
           if (!btnOnartu.IsEnabled)
            {
                txtError.Visibility = Visibility.Visible;
                return;
            }

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
            UpdateValidation();
        }

        
        private void InputChanged(object sender, RoutedEventArgs e)
        {
            UpdateValidation();
        }

        private void UpdateValidation()
        {
            bool hasUser = !string.IsNullOrWhiteSpace(txtErabiltzailea.Text);
            bool hasPass = !string.IsNullOrWhiteSpace(pwdPasahitza.Password);

            btnOnartu.IsEnabled = hasUser && hasPass;
            txtError.Visibility = btnOnartu.IsEnabled ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}