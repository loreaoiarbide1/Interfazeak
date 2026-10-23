using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
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

            // Botoiaren gainetik pasatzean kolorea ez aldatzeko estilo gardena
            Style botoiEstiloa = new Style(typeof(Button));
            ControlTemplate template = new ControlTemplate(typeof(Button));

            // Border bat sortzen dugu atzeko planoko kolorea erabat errespetatzeko
            FrameworkElementFactory borderFactory = new FrameworkElementFactory(typeof(Border));
            borderFactory.Name = "border";
            borderFactory.SetValue(Border.BackgroundProperty, new System.Windows.Data.Binding("Background") { RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent) });
            borderFactory.SetValue(Border.BorderBrushProperty, Brushes.Gray);
            borderFactory.SetValue(Border.BorderThicknessProperty, new Thickness(1));

            // Edukia (Content) ondo zentratuta agertzeko
            FrameworkElementFactory contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenter.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            contentPresenter.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
            borderFactory.AppendChild(contentPresenter);

            template.VisualTree = borderFactory;
            botoiEstiloa.Setters.Add(new Setter(Button.TemplateProperty, template));

            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    Button btn = new Button
                    {
                        Content = $"{r + 1}-{c + 1}",
                        ToolTip = "Libre",
                        Margin = new Thickness(2),
                        Padding = new Thickness(0),
                        FontSize = 11,
                        Background = Brushes.Green,
                        Style = botoiEstiloa, // Hemen aplikatzen da estilo pertsonalizatua
                        Tag = new Point(r, c)
                    };

                    // Gertaerak (Hover eta Klik)
                    btn.Click += EserlekuaKlikatu;
                    btn.MouseEnter += delegate (object sender, MouseEventArgs e)
                    {
                        // Okupatuta badago (gorria) edo hautatuta, kolorea ez da aldatuko
                        if (btn.Background != Brushes.IndianRed && btn.Background != AccentColor)
                        {
                            btn.Background = Brushes.LightSkyBlue;
                        }
                    };
                    btn.MouseLeave += delegate (object sender, MouseEventArgs e)
                    {
                        // Urdin argia bazegoen, berriro berdera bueltatuko du
                        if (btn.Background == Brushes.LightSkyBlue)
                        {
                            btn.Background = Brushes.Green;
                        }
                    };

                    botoiak[r, c] = btn;
                    GridEserlekuak.Children.Add(btn);
                }
            }
        }

        private void EserlekuaKlikatu(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn.Tag is Point p)
                {
                    int r = (int)p.X;
                    int c = (int)p.Y;

                    // Dagoeneko hautatuta badago (urdinez/azentu-kolorez)
                    if (btn.Background == AccentColor)
                    {
                        // Hasierako egoerara bueltatu (okupatuta bazegoen gorrira, bestela berdera)
                        btn.Background = btn.ToolTip?.ToString() == "Okupatuta" ? Brushes.IndianRed : Brushes.Green;
                        SeatUnselected?.Invoke(this, new SeatEventArgs(r, c));
                    }
                    else
                    {
                        // Eserlekua (libre zein okupatua) hautatu ezabatzeko edo erreserbatzeko
                        btn.Background = AccentColor;
                        SeatSelected?.Invoke(this, new SeatEventArgs(r, c));
                    }
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
                botoiak[r, c].Background = Brushes.Green;
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