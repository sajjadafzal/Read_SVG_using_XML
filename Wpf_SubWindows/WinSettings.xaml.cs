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

namespace Wpf_SubWindows
{
    /// <summary>
    /// Interaction logic for WinSettings.xaml
    /// </summary>
    public partial class WinSettings : Window
    {
        Settings mySettings;
        private bool IsChecked;
        public WinSettings(Settings settings)
        {
            InitializeComponent();
            mySettings = settings;
            //IsChecked = mySettings.CheckBoxOneisChecked;
            //this.DataContext = IsChecked;
            //this.CB1.IsChecked = mySettings.CheckBoxOneisChecked;
            //this.CB2.IsChecked = mySettings.CB2;
            //this.CB1.DataContext = mySettings;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            //this.Topmost = true;
        }

        private void btn_ShowOwner_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this.Owner.ToString());
        }
    }
}
