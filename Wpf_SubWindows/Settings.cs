using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Wpf_SubWindows
{
    public class Settings : INotifyPropertyChanged
    {
        private bool _CB1_Check;
        private bool _CB2_Check;
        public bool CB1_Check
        {
            get
            {
                return _CB1_Check;
            }
            set
            {
                if (_CB1_Check != value)
                {
                    _CB1_Check = value;
                    // this.propertyChanged(this, new PropertyChangedEventArgs("CB1_Check")); //to notify an incode change to ui

                }
            }
        }
        public bool CB2_Check
        {
            get
            {
                return _CB2_Check;
            }
            set
            {
                if (_CB2_Check != value)
                {
                    _CB2_Check = value;
                    //this.propertyChanged(this, new PropertyChangedEventArgs("CB2_Check")); //to notify an incode change to ui
                }
            }
        }
        public Settings()
        {

        }
        private PropertyChangedEventHandler propertyChanged;
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                //throw new NotImplementedException();
                this.propertyChanged += value;
            }

            remove
            {
                //throw new NotImplementedException();
                this.propertyChanged -= value;
            }
        }

        //private void RaisePropertyChanged(string propertyName)
        //{
        //    if (this.propertyChanged != null)
        //    {
        //        this.propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

    }
}
