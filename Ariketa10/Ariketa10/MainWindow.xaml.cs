using System.Windows;

namespace Ariketa10
{
    /// <summary>
    /// Leihoaren erabiltzaile-interfacearen logika
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // ComboBox-ean irudiak gehitu
            ComboboxIrudiaKargatu();

            // Hasieran irudi guztiak ezkutatu
            IrudiGuztiakEzkutatu();
        }

        /// <summary>
        /// ComboBox-aren irudien balioak Items propietatearen bidez kargatzen ditu.
        /// </summary>
        private void ComboboxIrudiaKargatu()
        {
            CmbIrudiak.Items.Add("Aukeratu irudia...");
            CmbIrudiak.Items.Add("Irudia 1");
            CmbIrudiak.Items.Add("Irudia 2");
            CmbIrudiak.Items.Add("Irudia 3");

            // Hasieran lehenengo elementua aukeratu
            CmbIrudiak.SelectedIndex = 0;
        }

        /// <summary>
        /// Irudi guztiak ezkutatzen ditu.
        /// </summary>
        private void IrudiGuztiakEzkutatu()
        {
            Img1.Visibility = Visibility.Hidden;
            Img2.Visibility = Visibility.Hidden;
            Img3.Visibility = Visibility.Hidden;
            Img4.Visibility = Visibility.Hidden;
            Img5.Visibility = Visibility.Hidden;
            Img6.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// ComboBox-aren hautaketa aldatzean irudia erakusten du.
        /// </summary>
        private void CmbIrudiak_SelectionChanged(
            object sender,
            System.Windows.Controls.SelectionChangedEventArgs e)
        {
            IkusgarritasunaAldatu();
        }

        /// <summary>
        /// CheckBox baten egoera aldatzean irudia erakusten edo ezkutatzen du.
        /// </summary>
        private void CbhIrudia_CheckedChanged(object sender, RoutedEventArgs e)
        {
            IkusgarritasunaAldatu();
        }

        /// <summary>
        /// Aukeratutako irudien ikusgarritasuna eguneratzen du.
        /// </summary>
        private void IkusgarritasunaAldatu()
        {
            // Lehenengo, irudi guztiak ezkutatu.
            IrudiGuztiakEzkutatu();

            // ComboBox-etik aukeratutako irudia erakutsi.
            if (CmbIrudiak.SelectedIndex == 1)
            {
                Img1.Visibility = Visibility.Visible;
            }
            else if (CmbIrudiak.SelectedIndex == 2)
            {
                Img2.Visibility = Visibility.Visible;
            }
            else if (CmbIrudiak.SelectedIndex == 3)
            {
                Img3.Visibility = Visibility.Visible;
            }

            // Irudia 4 CheckBox-aren bidez erakutsi.
            if (CbhIrudia4.IsChecked == true)
            {
                Img4.Visibility = Visibility.Visible;
            }

            // Irudia 5 CheckBox-aren bidez erakutsi.
            if (CbhIrudia5.IsChecked == true)
            {
                Img5.Visibility = Visibility.Visible;
            }

            // Irudia 6 CheckBox-aren bidez erakutsi.
            if (CbhIrudia6.IsChecked == true)
            {
                Img6.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Aplikazioa ixten du.
        /// </summary>
        private void BtnIrten_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}