using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H_PF.Example.Test
{
    class Test_DataContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _textMsg = "eeeeeeet !!!";

        public string TextMsg
        {
            get { return _textMsg; }
            set
            {
                _textMsg = value;
                OnPropertyChanged("TextMsg");
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
