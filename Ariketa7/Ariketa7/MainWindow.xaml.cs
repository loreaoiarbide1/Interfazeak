using System;
using System.Windows;

namespace Ariketa7
{
    public partial class MainWindow : Window
    {
        private double oraingoZenbakia = 0;
        private double emaitza = 0;
        private string eragiketa = "";
        private bool zenbakiBerria = true;

        public MainWindow()
        {
            InitializeComponent();
            txtEmaitza.Text = "0";
        }

        private void ZenbakiaGehitu(string zenbakia)
        {
            if (zenbakiBerria)
            {
                txtEmaitza.Text = zenbakia;
                zenbakiBerria = false;
            }
            else
            {
                if (zenbakia == "." && txtEmaitza.Text.Contains("."))
                    return;
                txtEmaitza.Text += zenbakia;
            }
        }

        private void EragiketaGehitu(string op)
        {
            if (string.IsNullOrEmpty(eragiketa))
            {
                emaitza = double.Parse(txtEmaitza.Text);
            }
            else if (!zenbakiBerria)
            {
                EmaitzaKalkulatu();
            }

            eragiketa = op;
            txtEmaitza.Text += " " + op;
            zenbakiBerria = true;
        }

        private void EmaitzaKalkulatu()
        {
            // Testua eragiketa eta zenbakia bereizteko
            string testuaEragiketaGabe = txtEmaitza.Text.Split(' ')[0];
            double oraingoZenbakia = double.Parse(testuaEragiketaGabe);

            double erantzuna = 0;
            switch (eragiketa)
            {
                case "+":
                    erantzuna = emaitza + oraingoZenbakia;
                    break;
                case "-":
                    erantzuna = emaitza - oraingoZenbakia;
                    break;
                case "*":
                    erantzuna = emaitza * oraingoZenbakia;
                    break;
                case "/":
                    if (oraingoZenbakia == 0)
                    {
                        MessageBox.Show("Ezin da 0-z zatitu");
                        return;
                    }
                    erantzuna = emaitza / oraingoZenbakia;
                    break;
            }

            emaitza = erantzuna;
            txtEmaitza.Text = erantzuna.ToString();
            zenbakiBerria = true;
        }

        // Zenbakiak
        private void btnBat_Click(object sender, RoutedEventArgs e) => ZenbakiaGehitu("1");
        private void btnBi_Click(object sender, RoutedEventArgs e) => ZenbakiaGehitu("2");
        private void btnHiru_Click(object sender, RoutedEventArgs e) => ZenbakiaGehitu("3");
        private void btnLau_Click(object sender, RoutedEventArgs e) => ZenbakiaGehitu("4");
        private void btnBost_Click(object sender, RoutedEventArgs e) => ZenbakiaGehitu("5");
        private void btnSei_Click(object sender, RoutedEventArgs e) => ZenbakiaGehitu("6");
        private void btnZazpi_Click(object sender, RoutedEventArgs e) => ZenbakiaGehitu("7");
        private void btnZortzi_Click(object sender, RoutedEventArgs e) => ZenbakiaGehitu("8");
        private void btnBederatzi_Click(object sender, RoutedEventArgs e) => ZenbakiaGehitu("9");
        private void btnZero_Click(object sender, RoutedEventArgs e) => ZenbakiaGehitu("0");
        private void btnKoma_Click(object sender, RoutedEventArgs e) => ZenbakiaGehitu(".");
        
        // Eragiketak
        private void btnZatiketa_Click(object sender, RoutedEventArgs e) => EragiketaGehitu("/");
        private void btnBiderketa_Click(object sender, RoutedEventArgs e) => EragiketaGehitu("*");

        private void btnBatu_Click(object sender, RoutedEventArgs e) => EragiketaGehitu("+");
        private void btnKendu_Click(object sender, RoutedEventArgs e) => EragiketaGehitu("-");
        private void btnPortzentaia_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtEmaitza.Text, out double zenbakia))
            {
                txtEmaitza.Text = (zenbakia / 100).ToString();
                zenbakiBerria = true;
            }
        }

        // Garbitu
        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            emaitza = 0;
            eragiketa = "";
            zenbakiBerria = true;
            txtEmaitza.Text = "0";
        }

        private void btnCE_Click(object sender, RoutedEventArgs e)
        {
            txtEmaitza.Text = "0";
            zenbakiBerria = true;
        }

        // Emaitza kalkulatu
        private void btnBerdin_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(eragiketa))
            {
                EmaitzaKalkulatu();
                eragiketa = "";
            }
        }
    }
}