using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace EsaldiakKateatzea
{
    public partial class MainWindow : Window
    {
        private List<string> esaldiak = new List<string>();

        public MainWindow()
        {
            InitializeComponent();

            // Hasierakoan: lehen botoia soilik dago gaituta
            btnEsaldia2.IsEnabled = false;
            btnEsaldia3.IsEnabled = false;
            btnEsaldia4.IsEnabled = false;
            btnEsaldia5.IsEnabled = false;
            btnBatu.IsEnabled = false;
        }

        // Metodo lagungarria: gordetzen du testua, garbitzen du textbox-a,
        // desgaitzen du uneko botoia eta gaitzen du hurrengoa
        private void GordetuEtaAurrera(Button oraingoa, Button hurrengoa)
        {
            // Balidazioa TextBox-a hutsik dagoen edo ez
            if (string.IsNullOrWhiteSpace(txtEsaldia.Text))
            {
                MessageBox.Show("Mesedez, idatzi esaldia aurrera jarraitu aurretik", "Errorea", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Edukia gordetzen du eta TextBox-a garbitzen du
            esaldiak.Add(txtEsaldia.Text);
            txtEsaldia.Clear();

            oraingoa.IsEnabled = false;
            if (hurrengoa != null)
                hurrengoa.IsEnabled = true;
        }

        private void btnEsaldia1_Click(object sender, RoutedEventArgs e)
        {
            GordetuEtaAurrera(btnEsaldia1, btnEsaldia2);
        }

        private void btnEsaldia2_Click(object sender, RoutedEventArgs e)
        {
            GordetuEtaAurrera(btnEsaldia2, btnEsaldia3);
        }

        private void btnEsaldia3_Click(object sender, RoutedEventArgs e)
        {
            GordetuEtaAurrera(btnEsaldia3, btnEsaldia4);
        }

        private void btnEsaldia4_Click(object sender, RoutedEventArgs e)
        {
            GordetuEtaAurrera(btnEsaldia4, btnEsaldia5);
        }

        private void btnEsaldia5_Click(object sender, RoutedEventArgs e)
        {
            GordetuEtaAurrera(btnEsaldia5, null);

            btnBatu.IsEnabled = true; 
        }

        private void btnBatu_Click(object sender, RoutedEventArgs e)
        {
            // Konektatzen ditu gordetako esaldi guztiak
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < esaldiak.Count; i++)
            {
                if (i > 0) sb.Append(" ");
                sb.Append(esaldiak[i]);
            }
            MessageBox.Show(sb.ToString(), "Batu diren esaldiak");
        }

        private void btnGarbitu_Click(object sender, RoutedEventArgs e)
        {
            esaldiak.Clear();
            txtEsaldia.Clear();

            btnEsaldia1.IsEnabled = true;
            btnEsaldia2.IsEnabled = false;
            btnEsaldia3.IsEnabled = false;
            btnEsaldia4.IsEnabled = false;
            btnEsaldia5.IsEnabled = false;
            btnBatu.IsEnabled = false;
        }

        private void btnIrten_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}