using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H_PF.HesoControl.NumberPicker
{
    class NumberPicker_DataContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int? _number;

        public int? Number
        {
            get { return _number; }
            set
            {
                _number = value;
                OnPropertyChanged("Number");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
