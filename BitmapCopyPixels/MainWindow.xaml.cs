using System;
using System.Collections.Generic;
using System.IO;
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
using ZXing;

namespace BitmapCopyPixels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BitmapImage bitmap;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_DecodeBarcode_Click(object sender, RoutedEventArgs e)
        {
            bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@"D:\svg\Image.tif");
            bitmap.EndInit();

            //MemoryStream mem = new MemoryStream();
            ImageControl.Source = bitmap;
            //IBarcodeReader reader = new BarcodeReader();
           

            //using(MemoryStream ms = new MemoryStream())
            //{
            //    img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            //    imgData =  ms.ToArray();
            //}

            //BitmapImage bim = new BitmapImage();


            
        }

        private void btn_CopyPixels_Click(object sender, RoutedEventArgs e)
        {
            int bpp = bitmap.Format.BitsPerPixel;
            int stride = (bitmap.PixelWidth * bpp + 7) / 8;
            int bytesPerPixel = bpp / 8;
            int areaWidth = (int)(bitmap.PixelWidth / 2);
            int areaStride = (areaWidth + (areaWidth % 4)) * bytesPerPixel;
            Int32Rect area = new Int32Rect(0, 0, (int)(bitmap.PixelWidth / 2), bitmap.PixelHeight);
            //byte[] arry = new byte[imgData.Length];
            byte[] imgData = new byte[areaStride * area.Height * bytesPerPixel];
            bitmap.CopyPixels(area,imgData, areaStride, 0);
            //BitmapSource BS = BitmapSource.Create(bitmap.PixelWidth, bitmap.PixelHeight, bitmap.DpiX, bitmap.DpiY, bitmap.Format, bitmap.Palette, imgData, stride);
            BitmapSource BS = BitmapSource.Create(area.Width, area.Height, bitmap.DpiX, bitmap.DpiY, bitmap.Format, bitmap.Palette, imgData, areaStride);
            //Encode Output Image from Array
            TiffBitmapEncoder encoder = new TiffBitmapEncoder();
            MemoryStream memoryStream = new MemoryStream();


            encoder.Frames.Add(BitmapFrame.Create(BS));
            encoder.Save(memoryStream);

            BitmapImage tempImg = new BitmapImage();
            memoryStream.Position = 0;
            tempImg.BeginInit();
            tempImg.StreamSource = new MemoryStream(memoryStream.ToArray()); //new MemoryStream(memoryStream.ToArray());
            tempImg.EndInit();

            memoryStream.Close();
            ImageControl2.Source = tempImg;
        }
    }
}
