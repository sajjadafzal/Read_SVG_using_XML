using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserControlDemo.UserControls
{
    /// <summary>
    /// Interaction logic for SliderControl.xaml
    /// </summary>
    public partial class SliderControl : UserControl
    {
        public SliderControl()
        {
            InitializeComponent();
            //(this.Content as FrameworkElement).DataContext = this;
            //this.DataContext = this;
        }

        public int PropertyValue
        {
            get { return (int)GetValue(PropertyValueProperty); }
            set 
            { 
                SetValue(PropertyValueProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for PropertyValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PropertyValueProperty =
            DependencyProperty.Register("PropertyValue", typeof(int), typeof(SliderControl), new FrameworkPropertyMetadata(default(int),FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public double DecimalValue
        {
            get { return (int)GetValue(DecimalValueProperty); }
            set
            {
                SetValue(DecimalValueProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for PropertyValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DecimalValueProperty =
            DependencyProperty.Register("DecimalValue", typeof(double), typeof(SliderControl), new FrameworkPropertyMetadata(default(double), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        public bool UseDecimal
        {
            get { return (bool)GetValue(UseDecimalProperty); }
            set { SetValue(UseDecimalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UseDecimal.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UseDecimalProperty =
            DependencyProperty.Register("UseDecimal", typeof(bool), typeof(SliderControl), new PropertyMetadata(default(bool)));


        public int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Minimum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(int), typeof(SliderControl), new PropertyMetadata(0));



        public int Maximum
        {
            get { return (int)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Maximum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(int), typeof(SliderControl), new PropertyMetadata(0));


        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(SliderControl));


        //public event PropertyChangedEventHandler PropertyChanged;

        //void SetValueDp(DependencyProperty property, object value, [System.Runtime.CompilerServices.CallerMemberName] string p = null)
        //{
        //    SetValue(property, value);
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, new PropertyChangedEventArgs(p));
        //}
    }

    public class DecimalValueConverter : IValueConverter
    {
        public DecimalValueConverter()
        {
            
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //if (IsDecimal)
            //{
                //return Math.Round((int)value / 100.0, 2);
            //}
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
