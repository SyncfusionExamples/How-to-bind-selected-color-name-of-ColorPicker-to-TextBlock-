using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ColorPickerColorName
{
    class ViewModel :INotifyPropertyChanged
    {
        private Color _color = Colors.Green;
        public Color Colorprop
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                OnPropertyChanged("Colorprop");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
    }
}
