using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ariketa1_Unitatea3
{
    public partial class SeatMapControl : UserControl
    {
        public event EventHandler<SeatEventArgs> SeatSelected;
        public event EventHandler<SeatEventArgs> SeatUnselected;

        public static readonly DependencyProperty RowsProperty =
            DependencyProperty.Register("Rows", typeof(int), typeof(SeatMapControl), new PropertyMetadata(5, OnGridSizeChanged));

        public static readonly DependencyProperty ColumnsProperty =
            DependencyProperty.Register("Columns", typeof(int), typeof(SeatMapControl), new PropertyMetadata(4, OnGridSizeChanged));

        public static readonly DependencyProperty AccentColorProperty =
            DependencyProperty.Register("AccentColor", typeof(Brush), typeof(SeatMapControl), new PropertyMetadata(Brushes.DodgerBlue));

        public int Rows
        {
            get => (int)GetValue(RowsProperty);
            set => SetValue(RowsProperty, value);
        }

        public int Columns
        {
            get => (int)GetValue(ColumnsProperty);
            set => SetValue(ColumnsProperty, value);
        }

        public Brush AccentColor
        {
            get => (Brush)GetValue(AccentColorProperty);
            set => SetValue(AccentColorProperty, value);
        }

        private Button[,] botoiak;

        public SeatMapControl()
        {
            InitializeComponent();
            InitializeMap();
        }

        private static void OnGridSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SeatMapControl control)
            {
                control.InitializeMap();
            }
        }

        public void InitializeMap()
        {
            GridEserlekuak.Rows = Rows;
            GridEserlekuak.Columns = Columns;
            GridEserlekuak.Children.Clear();

            botoiak = new Button[Rows, Columns];

            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    Button btn = new Button
                    {
                        Content = $"{r + 1}-{c + 1}", // Zenbakia bakarrik, garbi ikusteko
                        ToolTip = "Libre",            // Sagua gainean jartzean egoera ikusteko
                        Margin = new Thickness(2),
                        Padding = new Thickness(0),
                        FontSize = 11,
                        Background = Brushes.LightGray,
                        Tag = new Point(r, c)
                    };

                    // Gertaerak (Hover eta Klik)
                    btn.Click += Eserlekua_Click;
                    btn.MouseEnter += (s, e) => {
                        if (btn.Background != Brushes.IndianRed && btn.Background != AccentColor)
                            btn.Background = Brushes.LightSkyBlue;
                    };
                    btn.MouseLeave += (s, e) => {
                        if (btn.Background == Brushes.LightSkyBlue)
                            btn.Background = Brushes.LightGray;
                    };

                    botoiak[r, c] = btn;
                    GridEserlekuak.Children.Add(btn);
                }
            }
        }

        private void Eserlekua_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is Point p)
            {
                int r = (int)p.X;
                int c = (int)p.Y;

                // Okupatuta badago ezin da hautatu
                if (btn.Background == Brushes.IndianRed) return;

                if (btn.Background == AccentColor)
                {
                    // Deshautatu
                    btn.Background = Brushes.LightGray;
                    btn.ToolTip = "Libre";
                    SeatUnselected?.Invoke(this, new SeatEventArgs(r, c));
                }
                else
                {
                    // Hautatu
                    btn.Background = AccentColor;
                    btn.ToolTip = "Hautatuta";
                    SeatSelected?.Invoke(this, new SeatEventArgs(r, c));
                }
            }
        }

        // Metodo publikoa eserlekua okupatuta jartzeko
        public void OkupatuEserlekua(int r, int c)
        {
            if (botoiak != null && r >= 0 && r < Rows && c >= 0 && c < Columns)
            {
                botoiak[r, c].Background = Brushes.IndianRed; // Kolore gorria
                botoiak[r, c].Foreground = Brushes.White;   // Letra zuria
                botoiak[r, c].ToolTip = "Okupatuta";       // Tooltip-ean abisua
            }
        }

        public void AskatuEserlekua(int r, int c)
        {
            if (botoiak != null && r >= 0 && r < Rows && c >= 0 && c < Columns)
            {
                botoiak[r, c].Background = Brushes.LightGray;
                botoiak[r, c].Foreground = Brushes.Black;
                botoiak[r, c].ToolTip = "Libre";
            }
        }
    }

    public class SeatEventArgs : EventArgs
    {
        public int Row { get; }
        public int Column { get; }

        public SeatEventArgs(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}