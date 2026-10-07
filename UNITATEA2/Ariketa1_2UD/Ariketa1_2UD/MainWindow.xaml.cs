using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace Ariketa1_2UD
{
    public partial class MainWindow : Window
    {
        // ObservableCollection interfazea automatikoki eguneratzeko
        private ObservableCollection<Ataza> _atazak = new ObservableCollection<Ataza>();

        // Bide-izena erlatiboa izateko eta beti karpeta berean gordetzeko:
        private readonly string _xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "atazak.xml");

        public MainWindow()
        {
            InitializeComponent();
            dgAtazak.ItemsSource = _atazak;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Leihoa kargatzen denean automatikoki irakurtzen da XML fitxategia
            KargatuXML();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            // Leihoa ixtean berriro gordetzen dira datuak
            GordeXML();
        }

        // --- XML KARGATU ---
        private void KargatuXML()
        {
            if (!File.Exists(_xmlPath)) return;

            try
            {
                XDocument doc = XDocument.Load(_xmlPath);
                var atazakXml = doc.Descendants("Ataza");

                _atazak.Clear();

                foreach (var x in atazakXml)
                {
                    // Lehentasuna Enum-era bihurtu
                    Enum.TryParse(x.Element("Lehentasuna")?.Value, out Lehentasuna leh);

                    // Data parsing
                    DateTime.TryParse(x.Element("AzkenEguna")?.Value, out DateTime muga);
                    if (muga == DateTime.MinValue) muga = DateTime.Today;

                    // Id parsing
                    int.TryParse(x.Attribute("id")?.Value, out int id);

                    // Egoera
                    bool eginda = x.Element("Egoera")?.Value == "Eginda";

                    _atazak.Add(new Ataza
                    {
                        Id = id,
                        Izenburua = x.Element("Izenburua")?.Value ?? "",
                        Lehentasuna = leh,
                        MugaEguna = muga,
                        Eginda = eginda
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errorea XML-a kargatzean: {ex.Message}", "Errorea", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // --- XML GORDE ---
        private void GordeXML()
        {
            try
            {
                string directory = Path.GetDirectoryName(_xmlPath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                XDocument doc = new XDocument(
                    new XElement("Atazak",
                        _atazak.Select(a => new XElement("Ataza",
                            new XAttribute("id", a.Id),
                            new XElement("Izenburua", a.Izenburua ?? ""),
                            new XElement("Lehentasuna", a.Lehentasuna.ToString()),
                            new XElement("AzkenEguna", a.MugaEguna.ToString("yyyy-MM-dd")),
                            new XElement("Egoera", a.Eginda ? "Eginda" : "Egin gabe")
                        ))
                    )
                );

                doc.Save(_xmlPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errorea XML gordetzean: {ex.Message}", "Errorea", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // --- BOTOIAK ETA GERTAKARIAK ---
        private void btnBerria_Click(object sender, RoutedEventArgs e)
        {
            AtazaLeihoa leihoa = new AtazaLeihoa();
            leihoa.Owner = this;

            if (leihoa.ShowDialog() == true)
            {
                Ataza atazaBerria = leihoa.AtazaAukeratua;
                atazaBerria.Id = _atazak.Any() ? _atazak.Max(a => a.Id) + 1 : 1;

                _atazak.Add(atazaBerria);
                GordeXML(); // Zuzenean gordetzen dugu XMLan berria gehitzean
            }
        }

        private void btnEditatu_Click(object sender, RoutedEventArgs e)
        {
            if (dgAtazak.SelectedItem is Ataza aukeratutakoa)
            {
                AtazaLeihoa leihoa = new AtazaLeihoa(aukeratutakoa);
                leihoa.Owner = this;

                if (leihoa.ShowDialog() == true)
                {
                    dgAtazak.Items.Refresh();
                    GordeXML(); // Eguneraketa gordetzen da
                }
            }
            else
            {
                MessageBox.Show("Mesedez, hautatu ataza bat editatzeko.", "Informazioa", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void dgAtazak_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgAtazak.SelectedItem != null)
            {
                btnEditatu_Click(sender, e);
            }
        }

        private void btnEzabatu_Click(object sender, RoutedEventArgs e)
        {
            if (dgAtazak.SelectedItem is Ataza aukeratutakoa)
            {
                MessageBoxResult emaitza = MessageBox.Show("Ziur ezabatu nahi duzu ataza hau?", "Ezabatu", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (emaitza == MessageBoxResult.Yes)
                {
                    _atazak.Remove(aukeratutakoa);
                    GordeXML();
                }
            }
            else
            {
                MessageBox.Show("Ez dago atazarik hautatuta.", "Informazioa", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnIrten_Click(object sender, RoutedEventArgs e)
        {
            GordeXML();
            Close();
        }
    }
}