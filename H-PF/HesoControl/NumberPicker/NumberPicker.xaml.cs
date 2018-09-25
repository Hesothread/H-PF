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

        public NumberPicker()
        {
            InitializeComponent();
            _context = new NumberPicker_DataContext();
            this.DataContext = _context;
        }
    }
}
