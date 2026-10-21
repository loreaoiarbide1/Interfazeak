using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Ariketa1_UD3
{
    public partial class GelaxkaKontrola : UserControl
    {
        private bool okupaturik = false;
        public GelaxkaKontrola()
        {
            InitializeComponent();
            gelaxkaGrid.MouseEnter += SaguaSartu;
            gelaxkaGrid.MouseLeave += SaguaIrten;
            gelaxkaGrid.MouseLeftButtonDown += GelaxkaKlik;
        }
        private void SaguaSartu(object sender, MouseEventArgs e)
        {
            if (!okupaturik) gelaxkaGrid.Background = Brushes.Yellow;
        }
        private void SaguaIrten(object sender, MouseEventArgs e)
        {
            if (!okupaturik) gelaxkaGrid.Background = Brushes.Green;
        }
        private void GelaxkaKlik(object sender, MouseButtonEventArgs e)
        {
            if (!okupaturik)
            {
                okupaturik = true;
                gelaxkaGrid.Background = Brushes.Red;
                gelaxkaLabel.Content = "okupaturik";
            }
            else
            {
                okupaturik = false;
                gelaxkaGrid.Background = Brushes.Green;
                gelaxkaLabel.Content = "hutsik";
            }
        }
    }
}