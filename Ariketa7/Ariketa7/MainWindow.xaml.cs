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

namespace Ariketa7
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

        private void btnZazpi_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmaitza.Text == "0")
            {
                txtEmaitza.Text = "7";
            }
            else
            {
                txtEmaitza.Text += "7";
            }

        }

        private void btnZortzi_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmaitza.Text == "0")
            {
                txtEmaitza.Text = "8";
            }
            else
            {
                txtEmaitza.Text += "8";
            }

        }

        private void btnBederatzi_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmaitza.Text == "0")
            {
                txtEmaitza.Text = "9";
            }
            else
            {
                txtEmaitza.Text += "9";
            }
        }

        private void btnBat_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmaitza.Text == "0")
            {
                txtEmaitza.Text = "1";
            }
            else
            {
                txtEmaitza.Text += "1";
            }
        }

        private void btnBi_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmaitza.Text == "0")
            {
                txtEmaitza.Text = "2";
            }
            else
            {
                txtEmaitza.Text += "2";
            }
        }

        private void btnHiru_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmaitza.Text == "0")
            {
                txtEmaitza.Text = "3";
            }
            else
            {
                txtEmaitza.Text += "3";
            }
        }

        private void btnLau_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmaitza.Text == "0")
            {
                txtEmaitza.Text = "4";
            }
            else
            {
                txtEmaitza.Text += "4";
            }
        }

        private void btnBost_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmaitza.Text == "0")
            {
                txtEmaitza.Text = "5";
            }
            else
            {
                txtEmaitza.Text += "5";
            }
        }

        private void btnSei_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmaitza.Text == "0")
            {
                txtEmaitza.Text = "6";
            }
            else
            {
                txtEmaitza.Text += "6";
            }
        }

        private void btnZero_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmaitza.Text == "0")
            {
                txtEmaitza.Text = "0";
            }
            else
            {
                txtEmaitza.Text += "0";
            }
        }

        private void btnBatu_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmaitza.Text == "0")
            {
                txtEmaitza.Text = "+";
            }
            else
            {
                txtEmaitza.Text += "+";
            }
        }

        private void btnKendu_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmaitza.Text == "0")
            {
                txtEmaitza.Text = "-";
            }
            else
            {
                txtEmaitza.Text += "-";
            }
        }

        private void btnBerdin_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmaitza.Text == "0")
            {
                txtEmaitza.Text = "=";
            }
            else
            {
                txtEmaitza.Text += "=";
            }
        }

        private void btnKoma_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmaitza.Text == "0")
            {
                txtEmaitza.Text = ".";
            }
            else
            {
                txtEmaitza.Text += ".";
            }
        }

        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            txtEmaitza.Text = "0";

        }

        private void btnZatiketa_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmaitza.Text == "0")
            {
                txtEmaitza.Text = "/";
            }
            else
            {
                txtEmaitza.Text += "/";
            }

        }

        private void btnBiderketa_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmaitza.Text == "0")
            {
                txtEmaitza.Text = "*";
            }
            else
            {
                txtEmaitza.Text += "*";
            }

        }
    }
}