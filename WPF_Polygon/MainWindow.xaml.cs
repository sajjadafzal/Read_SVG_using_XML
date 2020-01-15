using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace WPF_Polygon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            List<FileListItem> mylist = new List<FileListItem>();
            mylist.Add(new FileListItem("File 1", FileStatus.Unrecognized));
            mylist.Add(new FileListItem("File 2", FileStatus.Unprocessed));
            mylist.Add(new FileListItem("File 3", FileStatus.Unprocessed));
            mylist.Add(new FileListItem("File 4", FileStatus.OK));
            mylist.Add(new FileListItem("File 5", FileStatus.OK));
            mylist.Add(new FileListItem("File 6", FileStatus.OK));
            mylist.Add(new FileListItem("File 7", FileStatus.Unrecognized));
            mylist.Add(new FileListItem("File 8", FileStatus.Unrecognized));
            mylist.Add(new FileListItem("File 9", FileStatus.Unrecognized));
            mylist.Add(new FileListItem("File 10", FileStatus.Check));
            mylist.Add(new FileListItem("File 11", FileStatus.Check));
            mylist.Add(new FileListItem("File 12", FileStatus.Check));

            myListBox.ItemsSource = mylist;
            
            //Polygon myPolygon = new Polygon();
            //myPolygon.Stroke = System.Windows.Media.Brushes.Black;
            //myPolygon.Fill = System.Windows.Media.Brushes.LightSeaGreen;
            //myPolygon.StrokeThickness = 2;
            //myPolygon.HorizontalAlignment = HorizontalAlignment.Left;
            //myPolygon.VerticalAlignment = VerticalAlignment.Center;
            //System.Windows.Point Point1 = new System.Windows.Point(1, 100);
            //System.Windows.Point Point2 = new System.Windows.Point(10, 80);
            //System.Windows.Point Point3 = new System.Windows.Point(50, 50);
            //PointCollection myPointCollection = new PointCollection();
            //myPointCollection.Add(Point1);
            //myPointCollection.Add(Point2);
            //myPointCollection.Add(Point3);
            //myPolygon.Points = myPointCollection;
            //myGrid.Children.Add(myPolygon);
        }
    }

    
    public class FileListItem
    {
        public string FileName { get; set; }
        public FileStatus status { get; set; }

        public FileListItem(string filename, FileStatus stats = FileStatus.Unprocessed)
        {
            FileName = filename;
            status = stats;
        }
    }

    public enum FileStatus
    {
        Unprocessed,
        OK,
        Check,
        Unrecognized,
    }
}
