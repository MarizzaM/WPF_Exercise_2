using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Exercise_2
{
    class Number : INotifyPropertyChanged
    {
        private int number;

        public int NumberValue {
            get {
                return number;
            }
            set {
                this.number = value;
                OnPropertyChanged("NumberValue");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
