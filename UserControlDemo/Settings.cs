using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace UserControlDemo
{
    public class SliderControlSettings : Settings
    {
        int _value;
        public string Label { get; set; }
        public int Minimun { get; set; } = 0;
        public int Maximum { get; set; } = 100;
        public int PropertyValue
        {
            get
            {
                return _value;
            }

            set
            {
                if ((value <= Maximum) && (value >= Minimun))
                {
                    _value = value;
                    if (_value == 50)
                    {
                        MessageBox.Show(50.ToString());
                    }
                    RaisePropertyChanged("PropertyValue");
                }
            }
        }

        public SliderControlSettings(string label,int minimum, int maximum, int value)
        {
            Label = label;
            Minimun = minimum;
            Maximum = maximum;
            PropertyValue = value;
        }
    }
    public class Settings : INotifyPropertyChanged
    {
        public PropertyChangedEventHandler propertyChanged;
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                propertyChanged += value;
                //throw new NotImplementedException();
            }

            remove
            {
                propertyChanged -= value;
                //throw new NotImplementedException();
            }
        }

        public void RaisePropertyChanged(string propertyName)
        {
            if (this.propertyChanged != null)
            {
                this.propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
