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

namespace Ariketa5
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

        private TextRange LortuTartea()
        {
            if (txtTestua.Selection != null && !txtTestua.Selection.IsEmpty)
                return new TextRange(txtTestua.Selection.Start, txtTestua.Selection.End);

            return new TextRange(txtTestua.Document.ContentStart, txtTestua.Document.ContentEnd);
        }

        private void btnComicSans_Click(object sender, RoutedEventArgs e)
        {
            var tartea = LortuTartea();
            tartea.ApplyPropertyValue(TextElement.FontFamilyProperty, new FontFamily("Comic Sans MS"));
        }

        private void btnLodia_Click(object sender, RoutedEventArgs e)
        {
            var tartea = LortuTartea();
            object unekoa = tartea.GetPropertyValue(TextElement.FontWeightProperty);
            if (unekoa == DependencyProperty.UnsetValue || !unekoa.Equals(FontWeights.Bold))
                tartea.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
            else
                tartea.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Normal);
        }

        private void btnMarratua_Click(object sender, RoutedEventArgs e)
        {
            // Marratua -> itzulkorra ez-zuzena
            var tartea = LortuTartea();
            object dekorazioak = tartea.GetPropertyValue(Inline.TextDecorationsProperty);
            bool marratua = false;
            if (dekorazioak is TextDecorationCollection tdc)
            {
                foreach (var d in tdc)
                {
                    if (d.Location == TextDecorationLocation.Strikethrough)
                    {
                        marratua = true;
                        break;
                    }
                }
            }

            if (!marratua)
            {
                var marra = new TextDecorationCollection { TextDecorations.Strikethrough[0] };
                tartea.ApplyPropertyValue(Inline.TextDecorationsProperty, marra);
            }
            else
            {
                // kendu dekorazioak
                tartea.ApplyPropertyValue(Inline.TextDecorationsProperty, null);
            }
        }

        private void btnTamainaGehiago_Click(object sender, RoutedEventArgs e)
        {
            var tartea = LortuTartea();
            object tamaiaObj = tartea.GetPropertyValue(TextElement.FontSizeProperty);
            double tamaina = (tamaiaObj == DependencyProperty.UnsetValue) ? 12.0 : (double)tamaiaObj;
            tartea.ApplyPropertyValue(TextElement.FontSizeProperty, tamaina + 2.0);
        }

        private void btnCourier_Click(object sender, RoutedEventArgs e)
        {
            var tartea = LortuTartea();
            tartea.ApplyPropertyValue(TextElement.FontFamilyProperty, new FontFamily("Courier New"));
        }

        private void btnEtzana_Click(object sender, RoutedEventArgs e)
        {
            var tartea = LortuTartea();
            object unekoa = tartea.GetPropertyValue(TextElement.FontStyleProperty);
            if (unekoa == DependencyProperty.UnsetValue || !unekoa.Equals(FontStyles.Italic))
                tartea.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Italic);
            else
                tartea.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Normal);
        }

        private void btnAzpimarratua_Click(object sender, RoutedEventArgs e)
        {
            // Azpimarratua -> itzulkorra azpi-zuzena
            var tartea = LortuTartea();
            object dekorazioak = tartea.GetPropertyValue(Inline.TextDecorationsProperty);
            bool azpimarratua = false;
            if (dekorazioak is TextDecorationCollection tdc)
            {
                foreach (var d in tdc)
                {
                    if (d.Location == TextDecorationLocation.Underline)
                    {
                        azpimarratua = true;
                        break;
                    }
                }
            }

            if (!azpimarratua)
            {
                tartea.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            }
            else
            {
                // kendu dekorazioak
                tartea.ApplyPropertyValue(Inline.TextDecorationsProperty, null);
            }
        }

        private void btnTamainaGutxiago_Click(object sender, RoutedEventArgs e)
        {
            var tartea = LortuTartea();
            object tamaiaObj = tartea.GetPropertyValue(TextElement.FontSizeProperty);
            double tamaina = (tamaiaObj == DependencyProperty.UnsetValue) ? 12.0 : (double)tamaiaObj;
            double tamainaBerria = tamaina - 2.0;
            if (tamainaBerria < 6.0) tamainaBerria = 6.0;
            tartea.ApplyPropertyValue(TextElement.FontSizeProperty, tamainaBerria);
        }

        private void btnHautatu_Click(object sender, RoutedEventArgs e)
        {
            string hautatu = txtTestua.Selection.Text ?? string.Empty;
            int luzera = hautatu.Length;
            // erakutsi mezua behean
            lblMezua.Text = $"Hautatutakoa ({luzera} karaktere): \"{hautatu}\"";
        }

        private void btnIrten_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}