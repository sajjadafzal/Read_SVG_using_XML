﻿using System;
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

namespace UserControlDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SliderControlSettings sliderControlSettings;
        public winSettings myWinSettings;
        public MainWindow()
        {
            InitializeComponent();
            sliderControlSettings = new SliderControlSettings("Threshold", 0, 2, 30,0.1,true, 1.2)
            {
                UseDecimal = true
            };


        }

        private void btn_NewWindow_Click(object sender, RoutedEventArgs e)
        {
            if (myWinSettings == null)
            {
                myWinSettings = new winSettings(sliderControlSettings);
                myWinSettings.Closed += delegate { myWinSettings = null; };
                myWinSettings.Owner = this;
                myWinSettings.ShowDialog();
            }
        }
    }
}
