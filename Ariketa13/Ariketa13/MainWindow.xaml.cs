using System.Windows;
using System.Windows.Input;

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
            // Gorde funtzionaltasuna
        }

        private void MenuIrten_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // MENUA: EDITATU
        private void MenuEbaki_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(txtEditorea.Text);
            txtEditorea.Clear();
        }

        private void MenuKopiatu_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(txtEditorea.Text);
        }

        private void MenuItsatsi_Click(object sender, RoutedEventArgs e)
        {
            txtEditorea.Text = Clipboard.GetText();
        }

        private void MenuEzabatu_Click(object sender, RoutedEventArgs e)
        {
            txtEditorea.Clear();
        }

        // MENUA: ITURRIA (Letra-tipoa aldatu)
        private void MenuIturria_Arial_Click(object sender, RoutedEventArgs e)
        {
            txtEditorea.FontFamily = new System.Windows.Media.FontFamily("Arial");
        }

        private void MenuIturria_Courier_Click(object sender, RoutedEventArgs e)
        {
            txtEditorea.FontFamily = new System.Windows.Media.FontFamily("Courier New");
        }

        private void MenuIturria_Impact_Click(object sender, RoutedEventArgs e)
        {
            txtEditorea.FontFamily = new System.Windows.Media.FontFamily("Impact");
        }

        private void MenuIturria_Symbol_Click(object sender, RoutedEventArgs e)
        {
            txtEditorea.FontFamily = new System.Windows.Media.FontFamily("Symbol");
        }
    }
}