using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Ariketa13
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Atazo-sarerak erregistratu
            CommandBinding ebakiBinding = new CommandBinding(ApplicationCommands.Cut);
            ebakiBinding.Executed += (s, e) => MenuEbaki_Click(null, null);
            this.CommandBindings.Add(ebakiBinding);

            CommandBinding kopiBinding = new CommandBinding(ApplicationCommands.Copy);
            kopiBinding.Executed += (s, e) => MenuKopiatu_Click(null, null);
            this.CommandBindings.Add(kopiBinding);

            CommandBinding itsasBinding = new CommandBinding(ApplicationCommands.Paste);
            itsasBinding.Executed += (s, e) => MenuItsatsi_Click(null, null);
            this.CommandBindings.Add(itsasBinding);
        }

        // MENUA: ARTXIBATZEA
        private void MenuIreki_Click(object sender, RoutedEventArgs e)
        {
            // Ireki funtzionaltasuna
        }

        private void MenuGorde_Click(object sender, RoutedEventArgs e)
        {
            // Balidazioa: testu-koadroa hutsik dagoen egiaztatu
            if (string.IsNullOrWhiteSpace(txtEditorea.Document.Blocks.Count == 0 ? "" : new TextRange(txtEditorea.Document.ContentStart, txtEditorea.Document.ContentEnd).Text))
            {
                MessageBox.Show("Errorea: Mesedez, idatzi zerbait gorde aurretik.", "Akats", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void MenuIrten_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // MENUA: EDITATU
        private void MenuEbaki_Click(object sender, RoutedEventArgs e)
        {
            if (txtEditorea.Selection.IsEmpty)
            {
                // Hala bada testu osoa moztu
                Clipboard.SetText(new TextRange(txtEditorea.Document.ContentStart, txtEditorea.Document.ContentEnd).Text);
                txtEditorea.Document.Blocks.Clear();
            }
            else
            {
                // Bestela hautaturiko testua moztu
                Clipboard.SetText(txtEditorea.Selection.Text);
                txtEditorea.Selection.Text = string.Empty;
            }
        }

        private void MenuKopiatu_Click(object sender, RoutedEventArgs e)
        {
            if (txtEditorea.Selection.IsEmpty)
            {
                // Testu osoa kopiatu
                Clipboard.SetText(new TextRange(txtEditorea.Document.ContentStart, txtEditorea.Document.ContentEnd).Text);
            }
            else
            {
                // Hautaturiko testua kopiatu
                Clipboard.SetText(txtEditorea.Selection.Text);
            }
        }

        private void MenuItsatsi_Click(object sender, RoutedEventArgs e)
        {
            string clipboardText = Clipboard.GetText();

            if (!txtEditorea.Selection.IsEmpty)
            {
                // Hautaturiko testua ordeztu
                txtEditorea.Selection.Text = clipboardText;
            }
            else
            {
                // Kurtsorearen posizioan txertatu
                txtEditorea.CaretPosition.InsertTextInRun(clipboardText);
            }
        }

        private void MenuEzabatu_Click(object sender, RoutedEventArgs e)
        {
            txtEditorea.Document.Blocks.Clear();
        }

        // MENUA: ITURRIA (Letra-mota aldatu)
        private void MenuIturria_Arial_Click(object sender, RoutedEventArgs e)
        {
            AldaraziIturria("Arial");
        }

        private void MenuIturria_Courier_Click(object sender, RoutedEventArgs e)
        {
            AldaraziIturria("Courier New");
        }

        private void MenuIturria_Impact_Click(object sender, RoutedEventArgs e)
        {
            AldaraziIturria("Impact");
        }

        private void MenuIturria_Symbol_Click(object sender, RoutedEventArgs e)
        {
            AldaraziIturria("Symbol");
        }

        private void AldaraziIturria(string iturriaIzena)
        {
            if (txtEditorea.Selection.IsEmpty)
            {
                // Ez badago hautaketarik, dokumentuaren iturria guztia aldatu
                txtEditorea.Selection.Select(txtEditorea.Document.ContentStart, txtEditorea.Document.ContentEnd);
                txtEditorea.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, new FontFamily(iturriaIzena));
                txtEditorea.CaretPosition = txtEditorea.Document.ContentEnd;
            }
            else
            {
                // Hautaturiko testua soilik aldatu
                txtEditorea.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, new FontFamily(iturriaIzena));
            }
        }
    }
}