using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Wpf_SubWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WinSettings winSettings;
        private Settings settings;
        public MainWindow()
        {
            InitializeComponent();
            settings = new Settings();            
        }

        private void btn_NewWindow_Click(object sender, RoutedEventArgs e)
        {
            if (winSettings == null)
            {
                winSettings = new WinSettings(settings);
                winSettings.Closed += delegate { winSettings = null; };
                winSettings.Owner = this;
                winSettings.ShowDialog();
            }
            //if (winSettings.IsLoaded)
            
        }
    }
}

public class Settings : DependencyObject,INotifyPropertyChanged
{
    private bool _CB1_Check;
    public bool CB1_Check 
    { 
        get 
        {
            return _CB1_Check;
        } 
        set 
        {
            _CB1_Check = value;
        }
    }
    public Settings()
    {

    }

    event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
    {
        add
        {
            throw new NotImplementedException();
        }

        remove
        {
            throw new NotImplementedException();
        }
    }
}
