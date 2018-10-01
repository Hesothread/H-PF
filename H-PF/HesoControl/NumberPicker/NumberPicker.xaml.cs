using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace H_PF.HesoControl.NumberPicker
{
    /// <summary>
    /// Logique d'interaction pour NumberPicker.xaml
    /// </summary>
    public partial class NumberPicker : UserControl
    {
        private NumberPicker_DataContext _context;

        // DependencyProperties

        public int MinValue
        {
            get { return (int)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(int), typeof(NumberPicker), new PropertyMetadata(0));

        public int MaxValue
        {
            get { return (int)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(int), typeof(NumberPicker), new PropertyMetadata(2147483647));

        public Brush CenterBackground
        {
            get { return (Brush)GetValue(CenterBackgroundProperty); }
            set { SetValue(CenterBackgroundProperty, value); }
        }

        public static readonly DependencyProperty CenterBackgroundProperty =
            DependencyProperty.Register("CenterBackground", typeof(Brush), typeof(NumberPicker), new PropertyMetadata(Brushes.White));

        public Brush ButtonBackground
        {
            get { return (Brush)GetValue(ButtonBackgroundProperty); }
            set { SetValue(ButtonBackgroundProperty, value); }
        }

        public static readonly DependencyProperty ButtonBackgroundProperty =
            DependencyProperty.Register("ButtonBackground", typeof(Brush), typeof(NumberPicker), new PropertyMetadata(Brushes.LightGray));

        public Brush CenterForeground
        {
            get { return (Brush)GetValue(CenterForegroundProperty); }
            set { SetValue(CenterForegroundProperty, value); }
        }

        public static readonly DependencyProperty CenterForegroundProperty =
            DependencyProperty.Register("CenterForeground", typeof(Brush), typeof(NumberPicker), new PropertyMetadata(Brushes.Black));

        public Brush ButtonForeground
        {
            get { return (Brush)GetValue(ButtonForegroundProperty); }
            set { SetValue(ButtonForegroundProperty, value); }
        }

        public static readonly DependencyProperty ButtonForegroundProperty =
            DependencyProperty.Register("ButtonForeground", typeof(Brush), typeof(NumberPicker), new PropertyMetadata(Brushes.Black));

        public Brush CenterBorderBrush
        {
            get { return (Brush)GetValue(CenterBorderBrushProperty); }
            set { SetValue(CenterBorderBrushProperty, value); }
        }

        public static readonly DependencyProperty CenterBorderBrushProperty =
            DependencyProperty.Register("CenterBorderBrush", typeof(Brush), typeof(NumberPicker), new PropertyMetadata(Brushes.LightGray));

        public Brush ButtonBorderBrush
        {
            get { return (Brush)GetValue(ButtonBorderBrushProperty); }
            set { SetValue(ButtonBorderBrushProperty, value); }
        }

        public static readonly DependencyProperty ButtonBorderBrushProperty =
            DependencyProperty.Register("ButtonBorderBrush", typeof(Brush), typeof(NumberPicker), new PropertyMetadata(Brushes.Gray));

        // DependencyProperties

        public NumberPicker()
        {
            InitializeComponent();
            _context = new NumberPicker_DataContext();
            this.DataContext = _context;
        }

        private void More_Click(object sender, RoutedEventArgs e)
        {
            if (_context.Number < MaxValue)
                _context.Number += 1;
        }

        private void Less_Click(object sender, RoutedEventArgs e)
        {
            if (_context.Number > MinValue)
                _context.Number -= 1;
        }
    }
}
