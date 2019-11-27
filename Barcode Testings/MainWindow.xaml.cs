using System;
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
using System.IO;
using ZXing;

namespace Barcode_Testings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_DecodeBarcode_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@"D:\svg\Barcode.tif");
            bitmap.EndInit();

            //MemoryStream mem = new MemoryStream();
            ImageControl.Source = bitmap;
            IBarcodeReader reader = new BarcodeReader();
            int bpp = bitmap.Format.BitsPerPixel;
            int stride = bitmap.PixelWidth * bpp / 8;
            //Image img = new Bitmap("D:\\svg\\BARCODE.tif");
            byte[] imgData =  new byte[bitmap.PixelWidth * bitmap.PixelHeight * bitmap.Format.BitsPerPixel]; 
            bitmap.CopyPixels(imgData, stride, 0);
            //using(MemoryStream ms = new MemoryStream())
            //{
            //    img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            //    imgData =  ms.ToArray();
            //}

            var result = reader.Decode(imgData,bitmap.PixelWidth,bitmap.PixelHeight,RGBLuminanceSource.BitmapFormat.RGB32);
            if (result != null)
            {
                TextBlock.Text = result.Text;
            }
            else
            {
                TextBlock.Text = "Null received";
            }



        }
    }
}
