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

namespace H_PF.Example.Test
{
    /// <summary>
    /// Logique d'interaction pour NumberPicker.xaml
    /// </summary>
    public partial class Test : UserControl
    {
        private Test_DataContext _context;

        public Test()
        {
            InitializeComponent();
            _context = new Test_DataContext();
            this.DataContext = _context;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _context.TextMsg = "Flop ...";
        }
    }
}
