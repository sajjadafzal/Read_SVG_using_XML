using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace UserControlDemo
{
    public class SliderControlSettings : Settings
    {
        
        public string Label { get; set; }
        public int Minimun { get; set; } = 0;
        public int Maximum { get; set; } = 100;
        public bool UseDecimal { get; set; } = false;

        int _value;
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
        double _decimalValue;
        public double DecimalValue
        {
            get
            {
                return _decimalValue;
            }

            set
            {
                if ((value <= Maximum) && (value >= Minimun))
                {
                    _decimalValue = Math.Round(value,2);
                    RaisePropertyChanged("DecimalValue");
                }
            }
        }

        public double TickFrequency { get; set; }
        public bool IsSnapToTickEnabled { get; set; }
        public SliderControlSettings(string label,int minimum, int maximum, int value, double tickFrequency = 5, bool isSnapToTickEnabled = true, double decimalValue = 0.0)
        {
            Label = label;
            Minimun = minimum;
            Maximum = maximum;
            PropertyValue = value;
            DecimalValue = decimalValue;
            TickFrequency = tickFrequency;
            IsSnapToTickEnabled = isSnapToTickEnabled;
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
