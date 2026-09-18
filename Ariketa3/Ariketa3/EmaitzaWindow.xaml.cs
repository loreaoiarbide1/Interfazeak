using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ariketa3
{
    /// <summary>
    /// Interaction logic for EmaitzaWindow.xaml
    /// </summary>
    public partial class EmaitzaWindow : Window
    {
        public EmaitzaWindow(double emaitza)
        {
            InitializeComponent();

            txtEmaitza.Text = emaitza.ToString("F2");
        }

        private void btnIrten_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
