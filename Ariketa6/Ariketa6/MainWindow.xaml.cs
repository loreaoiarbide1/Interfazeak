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

namespace Ariketa6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Kontrolatzen dugu Enter tekla sakatzean hurrengo TextBox-era pasatzeko
            txtTestua.KeyDown += TxtTestua_KeyDown;
            txtTestua2.KeyDown += TxtTestua_KeyDown;
            txtTestua3.KeyDown += TxtTestua_KeyDown;
        }

        private void TxtTestua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true; 
                TextBox oraingoa = sender as TextBox;

                if (oraingoa == txtTestua)
                {
                    txtTestua2.Text = txtTestua.Text;
                    txtTestua.Clear();
                    txtTestua2.Focus();
                }
                else if (oraingoa == txtTestua2)
                {
                    txtTestua3.Text = txtTestua2.Text;
                    txtTestua2.Clear();
                    txtTestua3.Focus();
                }
                else if (oraingoa == txtTestua3)
                {
                    // Hurrengo TextBox-a ez dagoenez, lehenengora itzuli
                    txtTestua.Text = txtTestua3.Text;
                    txtTestua3.Clear();
                    txtTestua.Focus();
                }
            }
        }

        private void btnGarbitu_Click(object sender, RoutedEventArgs e)
        {
            txtTestua.Clear();
            txtTestua2.Clear();
            txtTestua3.Clear();

        }

        private void btnIrten_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
    }
}