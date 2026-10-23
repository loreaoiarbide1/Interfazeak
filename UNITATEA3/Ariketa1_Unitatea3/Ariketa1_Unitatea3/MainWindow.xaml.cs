using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace Ariketa1_Unitatea3
{
    public partial class MainWindow : Window
    {
        private string fitxategia = "erreserbak.json";
        private List<Erreserba> erreserbaGuztiak = new List<Erreserba>();

        // Hautatutako eserlekuaren koordenatuak eta uneko garraioa
        private int hautatutakoErrenkada = -1;
        private int hautatutakoZutabea = -1;
        private string unekoGarraioa = "Autobusa";

        public MainWindow()
        {
            InitializeComponent();

            // Gaurko data ezartzen dugu hasierako balio gisa DatePicker-ean
            DpErreserbaData.SelectedDate = DateTime.Today;

            GertaerakHarpidetu();
            KargatuErreserbakDiskora();
        }

        private void GertaerakHarpidetu()
        {
            BusMap.SeatSelected += (s, e) => HautatuEserlekua(e.Row, e.Column);
            TrainMap.SeatSelected += (s, e) => HautatuEserlekua(e.Row, e.Column);
            PlaneMap.SeatSelected += (s, e) => HautatuEserlekua(e.Row, e.Column);

            BusMap.SeatUnselected += (s, e) => GarbituHautapena();
            TrainMap.SeatUnselected += (s, e) => GarbituHautapena();
            PlaneMap.SeatUnselected += (s, e) => GarbituHautapena();
        }

        private void HautatuEserlekua(int r, int c)
        {
            hautatutakoErrenkada = r;
            hautatutakoZutabea = c;
        }

        private void GarbituHautapena()
        {
            hautatutakoErrenkada = -1;
            hautatutakoZutabea = -1;
        }

        private void TabGarraioak_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TabGarraioak.SelectedItem is TabItem tab)
            {
                unekoGarraioa = tab.Header.ToString();
                GarbituHautapena();
            }
        }

        // Data aldatzen den bakoitzean erreserbak iragazteko exekutatzen da
        private void DpErreserbaData_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            AktualizatuMapak();
        }

        private void BtnErreserbatu_Click(object sender, RoutedEventArgs e)
        {
            // BALIDAZIOA: Data etorkizunekoa den ala ez egiaztatu
            if (DpErreserbaData.SelectedDate == null || DpErreserbaData.SelectedDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Errorea: Erreserba-data ezin da iraganekoa izan. Mesedez, hautatu etorkizuneko data bat.", "Data baliogabea", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (hautatutakoErrenkada == -1 || hautatutakoZutabea == -1)
            {
                MessageBox.Show("Mesedez, hautatu eserleku bat mapan.", "Eserlekua falta da", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Erreserba berria sortu
            var berria = new Erreserba
            {
                GarraioMota = unekoGarraioa,
                Errenkada = hautatutakoErrenkada,
                Zutabea = hautatutakoZutabea,
                Erabiltzailea = "Erabiltzailea",
                Data = DpErreserbaData.SelectedDate.Value
            };

            erreserbaGuztiak.Add(berria);
            GordeErreserbakDiskora();

            // Interfazea eguneratu data horren arabera
            AktualizatuMapak();

            MessageBox.Show("Erreserba arrakastaz burutu da!", "Ondo", MessageBoxButton.OK, MessageBoxImage.Information);
            GarbituHautapena();
        }

        private void BtnEzabatu_Click(object sender, RoutedEventArgs e)
        {
            if (hautatutakoErrenkada == -1 || hautatutakoZutabea == -1)
            {
                MessageBox.Show("Mesedez, hautatu bertan behera utzi nahi duzun eserlekua (gorria).", "Oharra", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            DateTime hautatutakoData = DpErreserbaData.SelectedDate ?? DateTime.Today;

            // Begiratu ea badagoen erreserbarik hautatutako eserleku eta data horretan
            bool badagoErreserba = erreserbaGuztiak.Exists(x => x.GarraioMota == unekoGarraioa &&
                                                              x.Errenkada == hautatutakoErrenkada &&
                                                              x.Zutabea == hautatutakoZutabea &&
                                                              x.Data.Date == hautatutakoData.Date);

            if (!badagoErreserba)
            {
                MessageBox.Show("Hautatutako eserlekua ez dago erreserbatuta data honetan.", "Oharra", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Zerrendatik kendu
            erreserbaGuztiak.RemoveAll(x => x.GarraioMota == unekoGarraioa &&
                                           x.Errenkada == hautatutakoErrenkada &&
                                           x.Zutabea == hautatutakoZutabea &&
                                           x.Data.Date == hautatutakoData.Date);

            // Fitxategian gorde eta mapak berritu (eserlekua berriro gris/libre geratuko da)
            GordeErreserbakDiskora();
            AktualizatuMapak();

            MessageBox.Show("Erreserba bertan behera utzi da eta eserlekua berriro libre dago.", "Ezabatuta", MessageBoxButton.OK, MessageBoxImage.Information);
            GarbituHautapena();
        }

        private void GordeErreserbakDiskora()
        {
            try
            {
                var aukerak = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(erreserbaGuztiak, aukerak);
                File.WriteAllText(fitxategia, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errorea datuak gordetzean: {ex.Message}");
            }
        }

        private void KargatuErreserbakDiskora()
        {
            if (File.Exists(fitxategia))
            {
                try
                {
                    string json = File.ReadAllText(fitxategia);
                    erreserbaGuztiak = JsonSerializer.Deserialize<List<Erreserba>>(json) ?? new List<Erreserba>();
                    AktualizatuMapak();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Errorea datuak kargatzean: {ex.Message}");
                }
            }
        }

        private void AktualizatuMapak()
        {
            // 1. Mapak berriro hasieratu (eserleku guztiak gris argiz uzteko)
            BusMap.InitializeMap();
            TrainMap.InitializeMap();
            PlaneMap.InitializeMap();

            DateTime hautatutakoData = DpErreserbaData.SelectedDate ?? DateTime.Today;

            // 2. Data horretako erreserbak soilik markatu gorriz
            foreach (var r in erreserbaGuztiak)
            {
                if (r.Data.Date == hautatutakoData.Date)
                {
                    if (r.GarraioMota == "Autobusa")
                    {
                        BusMap.OkupatuEserlekua(r.Errenkada, r.Zutabea);
                    }
                    else if (r.GarraioMota == "Trena")
                    {
                        TrainMap.OkupatuEserlekua(r.Errenkada, r.Zutabea);
                    }
                    else if (r.GarraioMota == "Hegazkina")
                    {
                        PlaneMap.OkupatuEserlekua(r.Errenkada, r.Zutabea);
                    }
                }
            }
        }
    }
}