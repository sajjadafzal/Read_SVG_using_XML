using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UserControlDemo
{
    /// <summary>
    /// Interaction logic for winSettings.xaml
    /// </summary>
    public partial class winSettings : Window
    {
        public winSettings(SliderControlSettings settings)
        {
            InitializeComponent();
            //this.DataContext = settings;           
            ThresholdSliderControl.DataContext = settings;
            ThresholdSliderControl2.DataContext = settings;
            //ThresholdSliderControl2.DataContext = settings;
        }
    }
}
